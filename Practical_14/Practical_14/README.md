# Practical 14 — Project Structure

This README describes the project layout and the purpose of each file present in the workspace. The application is a simple ASP.NET MVC (targeting .NET Framework 4.7.2) CRUD and list UI for `Employee` records with paging and search.

## High-level architecture
- Presentation: `Views` + `Controllers` (MVC).
- Application logic: `Models/Service` (service layer with DTO translation).
- Data access: `Models/Repository` (repository using an EF ObjectContext/DbContext).
- Data model: `Models/Data` (Entity Framework generated model classes and .edmx).
- Routing/config: files under project root and `App_Start`.

## Files and purpose

- `Practical_14\App_Start\RouteConfig.cs`  
  Defines application routes. The default route maps to `EmployeeController.Index`.

- `Practical_14\Global.asax.cs`  
  Application startup: registers areas, global filters, routes and bundles.

- `Practical_14\Web.config`  
  Application-level configuration (connection strings, compilation, authentication, etc).

- `Practical_14\Views\Web.config`  
  Views-specific configuration (view compilation and namespaces).

- `Practical_14\Properties\AssemblyInfo.cs`  
  Assembly metadata (title, version, company, etc).

- `Practical_14\Views\_ViewStart.cshtml`  
  View start file (typically sets the default layout for Razor views).

- `Practical_14\Views\Shared\_Layout.cshtml`  
  Shared layout (master page) used by views for common UI chrome.

Controllers
- `Practical_14\Controllers\EmployeeController.cs`  
  MVC controller for Employees. Uses `EmployeeService` to provide actions:
  `Index` (paging), `Search` (AJAX partial), `Create`, `Edit`, `Delete` (GET + POST flows).

Services
- `Practical_14\Models\Service\EmployeeService.cs`  
  Application/service layer. Converts EF entities to DTOs and implements:
  get-all, get-by-id, add, update, delete, search, and paging logic. Calls the repository.

Repository / Data access
- `Practical_14\Models\Repository\EmployeeRepository.cs`  
  Encapsulates EF data access (`Practical14DbEntities`). Implements CRUD, search, paged queries, and count.

Data model (EF)
- `Practical_14\Models\Data\EmployeeModel.edmx`  
  EF model definition (designer file). Auto-generates `EmployeeModel.*` files.

- `Practical_14\Models\Data\EmployeeModel.cs`  
  Auto-generated EF code (partial classes / context definitions).

- `Practical_14\Models\Data\EmployeeModel.Context.cs`  
  EF context wrapper (generated) — runtime entry point for DB access (`Practical14DbEntities`).

- `Practical_14\Models\Data\EmployeeModel.Designer.cs`, `.tt` files  
  T4 templates and designer-generated code for EF entities.

- `Practical_14\Models\Data\Employee.cs`  
  EF POCO/entity for `Employee` (Id, Name, DOB, Age).

DTOs
- `Practical_14\Models\DTOs\EmployeeDto.cs`  
  Data transfer object used between controller/views and service layer.

- `Practical_14\Models\DTOs\EmployeeListDto.cs`  
  DTO for paginated employee lists (list, current page, total pages).

Views (Employee)
- `Practical_14\Views\Employee\Index.cshtml`  
  Main list view. Renders `EmployeeListDto`, shows paging controls, search box and includes the partial list. Contains client-side JS to call `Search` via AJAX.

- `Practical_14\Views\Employee\_EmployeeList.cshtml`  
  Partial that renders the table of `EmployeeDto` rows and action links (Edit/Delete).

- `Practical_14\Views\Employee\Create.cshtml`  
  Form to create a new employee (POSTs to `EmployeeController.Create`).

- `Practical_14\Views\Employee\Edit.cshtml`  
  Edit form (similar to Create) — updates an existing record.

- `Practical_14\Views\Employee\Delete.cshtml`  
  Delete confirmation view.

Other
- `Practical_14\Models\Data\EmployeeModel.Context.tt` / `EmployeeModel.tt`  
  T4 template files used to generate EF classes.

## How it fits together (call flow)
1. Browser -> route -> `EmployeeController` action.
2. Controller calls `EmployeeService` to perform operations and map EF entities to DTOs.
3. `EmployeeService` calls `EmployeeRepository` which uses `Practical14DbEntities` (EF) to query/update the database.
4. Controller returns a `View` (Razor) populated with DTOs; views render HTML and use AJAX for search.

If you want, I can create the `README.md` file in the project root with this content.
