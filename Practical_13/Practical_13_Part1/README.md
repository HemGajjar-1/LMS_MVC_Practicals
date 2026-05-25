# Practical 13 - Part 1 

This document describes the project structure and the purpose of each important file in the `Practical_13_Part1` ASP.NET MVC application.

## Project Files
- `App_Start\RouteConfig.cs`  
  Configures MVC routing. The default route maps to `Employee/Index`.

- `Web.config`  
  Application configuration. Holds compilation settings, assembly binding redirects, and the `MyConnection` connection string (default: `Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Practical13DB;Integrated Security=True`).

- `Migrations\Configuration.cs`  
  Entity Framework migrations configuration. Controls automatic migrations and contains the `Seed` method for seeding the database.

- `Migrations\202605121125160_InitialCreate1.cs`  
  An EF Code-First migration that creates the initial database schema for the application.

- `Models\`  
  - `Employee` model — represents employee data (properties, validation attributes).  
  - `EmployeeDbContext` — EF `DbContext` that exposes `DbSet<Employee>` and configures the model.

- `Controllers\EmployeeController.cs`  
  Implements CRUD actions (Index, Create, Edit, Delete, Details) and interacts with `EmployeeDbContext`.

- `Views\Employee\Index.cshtml`  
  Displays a list of employees with links to create, edit, view, and delete records.

- `Views\Employee\Create.cshtml`  
  Form to add a new employee.

- `Views\Employee\Edit.cshtml`  
  Form to edit an existing employee.

- `Views\Employee\Delete.cshtml`  
  Confirmation page to delete an employee.

- `Views\Shared\_Layout.cshtml`  
  Site layout (HTML head, navigation, scripts/styles) used by views.

- `Views\Shared\_ValidationScriptsPartial.cshtml` (if present)  
  Loads client-side validation scripts (unobtrusive validation).

- `packages.config` / NuGet package references  
  Lists packages used by the project (Entity Framework, Microsoft.AspNet.Mvc, etc.).

- `Global.asax` (or `Global.asax.cs`)  
  Application entry points where `RouteConfig.RegisterRoutes` is invoked and application-level events are handled.

## Notes  
- Database changes are managed via EF migrations: create migrations with `Add-Migration <Name>` and apply with `Update-Database`.  
- Seed data can be added in `Migrations\Configuration.cs::Seed`.
