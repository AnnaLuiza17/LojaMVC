using LojaMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LojaMVC.Data
{
    public class LojaContext: IdentityDbContext
    {
        public LojaContext(DbContextOptions<LojaContext> options):base(options) 
        { 

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
