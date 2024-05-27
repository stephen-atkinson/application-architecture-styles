# recipes-api-base-build

## Entity Framework

- Database Provider - SQLite
- Database Name - donutshop.db

### CLI Commands

#### N-Layer

- Add Migration - dotnet ef migrations add Initial --project DonutShop.DAL --startup-project DonutShop.Web.Api -o Migrations
- Create/Update Database - dotnet ef database update --project DonutShop.DAL --startup-project DonutShop.Web.Api

#### Clean

- Add Migration - dotnet ef migrations add Initial --project DonutShop.Infrastructure --startup-project DonutShop.Api -o Database/Migrations
- Create/Update Database - dotnet ef database update --project DonutShop.Infrastructure --startup-project DonutShop.Api
