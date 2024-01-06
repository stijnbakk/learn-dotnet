# My first MVC .NET app

## Sources & learning:

- Tutorial: https://youtu.be/AopeJjkcRvU

## Learning notes

- Model --data--> Controller --view-->
- Views are simple HTML
- SQL notes:
  - Base user is `sa`, should be in connection string
  - Setup SQL server via Docker, via Azure Data Studio
  - SQL server in VScode cannot be connected whily applying migrations or database update
  - On Mac use `dotnet ef migrations add SomeMigrationTitle` and `dotnet ef database update` to apply migrations
-
