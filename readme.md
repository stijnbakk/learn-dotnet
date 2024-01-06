# Learning Dotnet

## Projects

- Late december - `/december-2023-experiments`
- Early january - `/MyFirstCrudApp` - Attempt at creating a Blazor app, abandoned
- Early january - `/MyFirstMvcApp` - My attempt at tutorial from [DotNetMastery](https://www.youtube.com/watch?v=AopeJjkcRvU) first half
- Early january - `/MyFirstTodoApp` - Simple app, created by myself, CRUD, with HTMX and Alpine, but without authentication

## Useful resources

## Useful tutorials

- [ ] (in progress) [DotNetMastery - Introduction to ASP.NET Core MVC (.NET 8)](https://www.youtube.com/watch?v=AopeJjkcRvU)

## Notes & learnings

- Model --data--> Controller --view-->
- Views are simple HTML
- SQL notes:
  - Base user is `sa`, should be in connection string
  - Setup SQL server via Docker, via Azure Data Studio
  - SQL server in VScode cannot be connected whily applying migrations or database update
  - On Mac use `dotnet ef migrations add SomeMigrationTitle` and `dotnet ef database update` to apply migrations
-

### Setting up SQL server on Mac

```bash
docker run -d --name sql_server -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=1234%Password' -p 1433:1433 mcr.microsoft.com/mssql/server:2019-latest
```

### Setting up the database

### Useful snippets

#### Required packages for CRUD via SQL server

```xml
// ProjectName.csproj
<ItemGroup>
  <PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.0" />
  <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.0" />
  <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.0">
    <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    <PrivateAssets>all</PrivateAssets>
  </PackageReference>
</ItemGroup>
```

#### Connection string for SQL server (localhost)

```json
// appsettings.json
"ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=MyFirstTodoApp;Trusted_Connection=False;TrustServerCertificate=True;User=sa;Password=1234%Password"
  }
```

#### Setting up database

In `/Data/ApplicationDbContext.cs`

```cs
// Data/ApplicationDbContext.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyProjectName.Models;

namespace MyProjectName.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}

```

#### Linking database to the application

Order in which to setup, then build the application is important. If adding services after build, database will not be connected, migrations will fail.

```cs
// Program.cs
using Microsoft.EntityFrameworkCore;
using MyFirstTodoApp.Data;

// Builder first
var builder = WebApplication.CreateBuilder(args);

// Then add services
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Thirdly, build the app
var app = builder.Build();

# ....
```

#### Setting up model in database

Terminal

```bash
dotnet ef migrations add <MigrationTitle>
# upon success
dotnet ef database update
```

#### Building a model

Add `using System.ComponentModel;` and `using System.ComponentModel.DataAnnotations;` in order to use things like

```cs
[Required]
[DisplayName("Task title")]
[MaxLength(30)]
```
