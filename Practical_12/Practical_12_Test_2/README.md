# Practical 12 — Part 2 (Employee Management)

Summary
-------
This is a small ASP.NET MVC application (targeting .NET Framework 4.8.1) that demonstrates a simple layered implementation for managing `Employee` records using ADO.NET. It shows basic listing, inserting and a few aggregate/filtered queries (total salary, DOB filter, count of NULL middle names).

Project layout (key files)
--------------------------
- `Practical_12_Test_2\Models\Entity\Employee.cs` — POCO model with validation attributes.
- `Practical_12_Test_2\Models\Repository\EmployeeRepository.cs` — ADO.NET repository: direct SQL commands for CRUD-like operations and queries.
- `Practical_12_Test_2\Models\Service\EmployeeService.cs` — Thin service layer forwarding calls to the repository.
- `Practical_12_Test_2\Controllers\EmployeeController.cs` — MVC controller exposing actions used by the UI.
- `Practical_12_Test_2\Views\Employee\Index.cshtml` — Main view: displays employee list, query buttons and an insert form.
- `Practical_12_Test_2\Views\Shared\_Layout.cshtml` — Application layout (bootstrap bundles and header).
- `Practical_12_Test_2\Web.config` — Contains the `DefaultConnection` connection string and target framework settings.

Model
-----
`Employee` contains:
- `Id` (int)
- `FirstName`, `MiddleName`, `LastName` (strings) — `FirstName` and `LastName` are required and limited to 50 chars; regex enforces alphabetic input.
- `DOB` (DateTime) — required.
- `MobileNumber` (string) — required, exactly 10 digits (validated by regex and length).
- `Address` (string) — optional, up to 100 chars.
- `Salary` (decimal) — required.

Repository (data access)
------------------------
`EmployeeRepository` uses `ConfigurationManager.ConnectionStrings["DefaultConnection"]` from `Web.config`. Implemented methods:
- `GetAll()` — returns all rows from `EMPLOYEE`.
- `Insert(Employee emp)` — inserts a record using parameterized SQL.
- `TotalSalary()` — returns SUM(SALARY).
- `BelowDate()` — returns rows with `DOB < 2000-01-01`.
- `MiddleNameCount()` — counts rows where `MIDDLENAME IS NULL`.

Notes:
- Data access uses parameterized queries (prevents SQL injection).
- There is no explicit exception handling or async usage.
- `ExecuteScalar()` results are cast directly — consider null checks for robustness.

Service layer
-------------
`EmployeeService` is a simple pass-through to `EmployeeRepository`. It keeps business logic centralized if needed later.

Controller and actions
----------------------
`EmployeeController`:
- `Index()` — GET: returns the list view (`Index`) with all employees.
- `Create(Employee emp)` — POST: inserts and redirects to `Index`. (Note: it does not currently check `ModelState.IsValid`.)
- `TotalSalary()` — sets `ViewBag.TotalSalary` then returns `Index` with all employees.
- `BelowDate()` — returns `Index` with filtered list (DOB < 2000).
- `MiddleNameCount()` — sets `ViewBag.MiddleNameCount` and returns `Index`.

Views / UI
----------
`Index.cshtml`:
- Displays a table of employees.
- Shows `TotalSalary` and `MiddleNameCount` via `ViewBag` when available.
- Provides action links that call the controller actions.
- Contains a form (`Html.BeginForm("Create","Employee", FormMethod.Post)`) to insert an employee.
- Uses `Html.ValidationMessage` helpers; server-side validation requires controller to check `ModelState` for full effect.

Database
--------
The repository expects a table named `EMPLOYEE` with columns matching the `Employee` model. Example schema (recommended):
