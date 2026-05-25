# Practical 13 Part 2 — Project Structure

## Top-level folders & purpose
- `Controllers/` — MVC controllers: handle requests, coordinate services/repositories, and return views or redirects.
- `Models/` — Domain entities, data access (EF `DbContext`), DTOs, repositories, and services.
- `Views/` — Razor views for UI (organized per controller).
- `Migrations/` — Entity Framework migrations configuration.
- `App_Start/` — MVC startup configuration (routing, etc.).
- `Web.config` — Application configuration (connection strings, system.web settings).

## Files (workspace open files)

- `Practical_13_Part2\Controllers\EmployeeController.cs`  
  Controller that handles CRUD actions for `Employee` entities (Index, Create, Edit, Delete). Uses services/repositories to perform data operations and returns appropriate views.

- `Practical_13_Part2\Controllers\DesignationController.cs`  
  Controller that handles CRUD actions for `Designation` entities and coordinates views for creating, editing, listing, and deleting designations.

- `Practical_13_Part2\Models\Data\AppDbContext.cs`  
  Entity Framework `DbContext` containing `DbSet<Employee>` and `DbSet<Designation>`. Responsible for DB access and EF model configuration.

- `Practical_13_Part2\Models\Entity\Employee.cs`  
  Domain/entity class that models an employee record (properties like `Id`, `FirstName`, `LastName`, `DOB`, `Salary`, `DesignationId`, navigation property to `Designation`, etc.).

- `Practical_13_Part2\Models\Entity\Designation.cs`  
  Domain/entity class that models a designation/job title (properties like `Id`, `Name`, possibly navigation collection of `Employees`).

- `Practical_13_Part2\Models\Repository\EmployeeRepository.cs`  
  Data access class encapsulating EF operations for `Employee` (shown in workspace). Provides methods:
  - `GetAll()` — returns all employees (includes `Designation` via eager load),
  - `GetById(int id)` — find by primary key,
  - `Add(Employee emp)` — insert,
  - `Update(Employee emp)` — update selected fields,
  - `Delete(int id)` — remove employee.

- `Practical_13_Part2\Models\Repository\DesignationRepository.cs`  
  Repository for `Designation` entity: CRUD operations (list, get by id, add, update, delete) used by `DesignationService` and controllers.

- `Practical_13_Part2\Models\Service\EmployeeService.cs`  
  Business/service layer for `Employee` operations. Orchestrates validation, mapping between DTOs and entities, and calls `EmployeeRepository`.

- `Practical_13_Part2\Models\Service\DesignationService.cs`  
  Business/service layer for `Designation` operations. Uses `DesignationRepository` and supplies data to controllers/views.

- `Practical_13_Part2\Models\DTOs\EmployeeDto.cs`  
  Data Transfer Object used to return employee data to views or API endpoints (likely flattened, includes designation name).

- `Practical_13_Part2\Models\DTOs\EmployeeFormDto.cs`  
  DTO used for create/edit forms — contains form fields, validation attributes, and lists needed by the view (e.g., designations select list).

- `Practical_13_Part2\Models\DTOs\DesignationDto.cs`  
  DTO for `Designation` used for transfers between layers or to views.

- `Practical_13_Part2\Views\Home\Index.cshtml`  
  Home page Razor view. Likely the landing page for the app.

- `Practical_13_Part2\Views\_ViewStart.cshtml`  
  Common Razor startup file that sets a default layout for views.

- `Practical_13_Part2\Views\Shared\_Layout.cshtml`  
  Shared layout used by pages (header, footer, navigation, script/style includes).

- Views for `Employee` (CRUD pages):
  - `Practical_13_Part2\Views\Employee\Index.cshtml` — List all employees.
  - `Practical_13_Part2\Views\Employee\Create.cshtml` — Form to create an employee.
  - `Practical_13_Part2\Views\Employee\Edit.cshtml` — Form to edit an existing employee.
  - `Practical_13_Part2\Views\Employee\Delete.cshtml` — Confirmation page to delete an employee.

- Views for `Designation` (CRUD pages):
  - `Practical_13_Part2\Views\Designation\Index.cshtml` — List all designations.
  - `Practical_13_Part2\Views\Designation\Create.cshtml` — Form to create a designation.
  - `Practical_13_Part2\Views\Designation\Edit.cshtml` — Form to edit a designation.
  - `Practical_13_Part2\Views\Designation\Delete.cshtml` — Confirmation page to delete a designation.

- `Practical_13_Part2\App_Start\RouteConfig.cs`  
  Configures MVC routes (default route, possibly area routes). Controls how URLs map to controllers/actions.

- `Practical_13_Part2\Migrations\Configuration.cs`  
  EF migrations configuration (seed data, migrations settings).

- `Practical_13_Part2\Web.config`  
  Application configuration file: connection strings, authentication, compilation settings, and other runtime configuration.

## Notes / conventions
- The repository-service-controller pattern is used:
  - `Repository` classes perform low-level EF operations.
  - `Service` classes encapsulate business logic and use repositories.
  - `Controller` classes call services and return views.
- `DTOs` are used to decouple domain entities from view models and forms.
- Views are standard Razor `.cshtml` pages following convention-based routing.

If you want, I can:
- Generate a `README.md` file in the project root with this content, or
	- Expand any section with examples of controller-to-service flow, DTO mappings, or add a quick run/setup guide.
