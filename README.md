# 🛒 LojaMVC

Sistema desenvolvido em **ASP.NET Core MVC** utilizando a linguagem **C#**, o padrão arquitetural **Model-View-Controller (MVC)** e a infraestrutura do **ASP.NET Core Identity** para gerenciamento de autenticação e autorização de usuários.

O projeto tem como objetivo demonstrar a implementação de um sistema completo para gerenciamento de loja, integrando controle de produtos, categorias, autenticação de usuários, testes automatizados e persistência de dados com **Entity Framework Core**.

---

## 📋 Tecnologias Utilizadas

- C#
- .NET
- ASP.NET Core MVC
- ASP.NET Core Identity
- SQL Server
- Entity Framework Core
- Bootstrap 5
- Bootstrap Icons
- jQuery
- xUnit / NUnit (Testes Automatizados)

---

## 📦 Pacotes Utilizados

O projeto utiliza os seguintes pacotes do Entity Framework Core e ecossistema .NET:

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.EntityFrameworkCore.Design
- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Microsoft.VisualStudio.Web.CodeGeneration.Design

---

## 🗄 Banco de Dados

O banco de dados foi desenvolvido utilizando o **SQL Server**.

A criação e a evolução da estrutura do banco foram realizadas através da abordagem **Code First**, utilizando **Migrations** do Entity Framework Core.

---

## 🚀 Funcionalidades

- Autenticação e Autorização de Usuários (Login, Registro e Gerenciamento de Conta via Identity)
- Cadastro e gerenciamento de Produtos e Categorias (CRUD)
- Consulta detalhada dos produtos e catálogo da loja
- Projeto dedicado para testes automatizados (`LojaMVCTests`)
- Interface limpa e totalmente responsiva

---

## 🎨 Interface

A interface foi desenvolvida utilizando:

- Bootstrap 5
- Bootstrap Icons
- Razor Views
- jQuery

---

# 📷 Telas do Sistema

## Tela Inicial

![Tela Inicial](LojaMVC/pagina-inicial.png.png)

---

## Cadastro / Login

![Login](LojaMVC/login.png.png)

---

![Cadastro](LojaMVC/cadastro.png.png)

---

## Gerenciamento de Produtos

![Produtos](LojaMVC/produto.png.png)

---

## Gerenciamento de Clientes

![Clientes](LojaMVC/cliente.png.png)

# ▶️ Como Executar o Projeto

## Clone o repositório

```bash
git clone [https://github.com/AnnaLuiza17/LojaMVC.git]
```

## Abra a solução

Abra o projeto utilizando o **Visual Studio 2022**.

## Configure a conexão

Edite o arquivo:

```
LojaMVC/appsettings.json
```

Configurando a string de conexão para o seu SQL Server.

## Execute as Migrations

No Console do Gerenciador de Pacotes execute:

```powershell
Update-Database
```

Ou utilize o .NET CLI:

```bash
dotnet ef database update --project LojaMVC
```

## Execute os Testes Automatizados (Opcional)

```
dotnet test
```

## Execute o projeto

Pressione **F5** ou clique em **Iniciar** no Visual Studio.

---

# 📂 Estrutura do Projeto

```
LojaMVC
│
├── LojaMVC/
│   ├── Areas/
│   │   └── Identity/
│   │       └── Pages/
│   ├── Controllers/
│   ├── Data/
│   ├── Migrations/
│   ├── Models/
│   ├── Properties/
│   ├── Views/
│   ├── wwwroot/
│   ├── LojaMVC.csproj
│   ├── Program.cs
│   ├── appsettings.Development.json
│   └── appsettings.json
│
├── LojaMVCTests/
├── .gitattributes
└── .gitignore
```

---

# 💻 Desenvolvido com

- ASP.NET Core MVC
- C#
- ASP.NET Core Identity
- SQL Server
- Entity Framework Core
- Bootstrap
- jQuery

---

# 👨‍💻 Autores

### Desenvolvedor

**Anna Luíza Watanabe**

### Professor

**Wallace Oliveira dos Santos**
