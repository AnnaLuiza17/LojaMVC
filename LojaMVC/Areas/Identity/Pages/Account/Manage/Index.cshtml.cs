#nullable disable

using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LojaMVC.Data;   // Certifique-se de que é o seu namespace do DbContext
using LojaMVC.Models; // Certifique-se de que é o seu namespace do modelo Cliente

namespace LojaMVC.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly LojaContext _context;

        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            LojaContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "O nome completo é obrigatório.")]
            [Display(Name = "Nome Completo")]
            public string NomeCompleto { get; set; }

            [Required(ErrorMessage = "A idade é obrigatória.")]
            [Range(18, 120, ErrorMessage = "A idade deve ser no mínimo 18 anos.")]
            [Display(Name = "Idade")]
            public int Idade { get; set; }

            [Phone(ErrorMessage = "Número de telefone inválido.")]
            [Display(Name = "Telefone")]
            public string PhoneNumber { get; set; }
        }

        private async Task LoadAsync(IdentityUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            // Busca os dados vinculados na tabela Cliente
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Email == user.Email);

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                NomeCompleto = cliente?.Nome ?? "",
                Idade = cliente?.Idade ?? 0
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Não foi possível carregar o usuário com ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Não foi possível carregar o usuário com ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            // Atualiza telefone no Identity
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Erro ao tentar atualizar o número de telefone.";
                    return RedirectToPage();
                }
            }

            // Atualiza Nome e Idade na tabela Cliente
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Email == user.Email);
            if (cliente != null)
            {
                cliente.Nome = Input.NomeCompleto;
                cliente.Idade = Input.Idade;
                _context.Clientes.Update(cliente);
                await _context.SaveChangesAsync();
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Seu perfil foi atualizado com sucesso!";
            return RedirectToPage();
        }
    }
}