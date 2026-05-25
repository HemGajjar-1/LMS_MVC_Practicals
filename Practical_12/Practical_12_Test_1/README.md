# Practical 12 — Part 1 (Employee CRUD & Bulk Operations)

Project: `Practical_12_Test_1`  
Target framework: .NET Framework 4.8.1

## Overview
This ASP.NET MVC application demonstrates a simple layered implementation for managing `Employee` records using ADO.NET. It includes:
- A model with data annotations for validation.
- A repository that performs raw SQL operations.
- A service layer that exposes repository functionality.
- A controller that handles requests and model binding.
- A Razor view for listing, inserting, and performing bulk operations.

Default route sends users to `EmployeeController.Index`.

## Project structure (key files)
- `Controllers/EmployeeController.cs` — MVC controller; actions:
  - `Index()` -> displays all employees.
  - `Create(Employee emp)` [HttpPost] -> inserts a new employee (validates `ModelState`).
  - `UpdateFirstName()` -> updates first name for `Id = 1`.
  - `UpdateMiddleName()` -> updates middle names for all rows.
  - `DeleteLessThanTwo()` -> deletes rows where `Id < 2`.
  - `DeleteAll()` -> truncates the `EMPLOYEE` table.

- `Models/Entity/Employee.cs` — domain model with validation attributes:
  - `FirstName`, `LastName` required; regex-only letters.
  - `MiddleName` optional.
  - `DOB` required (DateTime).
  - `MobileNumber` required, exactly 10 numeric characters.
  - `Address` optional.

- `Models/Repository/EmployeeRepository.cs` — data access using `System.Data.SqlClient`. Methods:
  - `GetAll()` — `SELECT * FROM employee`, maps `SqlDataReader` to `Employee`.
  - `Insert(Employee emp)` — parameterized `INSERT` (uses `AddWithValue`).
  - `UpdateFirstName()` — `UPDATE EMPLOYEE SET FIRSTNAME = 'SQLPerson' WHERE ID=1`.
  - `UpdateMiddleName()` — `UPDATE EMPLOYEE SET MIDDLENAME = 'I'`.
  - `DeleteLessThanTwo()` — `DELETE FROM EMPLOYEE WHERE ID<2`.
  - `DeleteAll()` — `TRUNCATE TABLE EMPLOYEE`.

- `Models/Service/EmployeeService.cs` — thin service wrapper that calls repository methods.

- `Views/Employee/Index.cshtml` — single view that:
  - Renders the `List<Employee>` (table).
  - Provides a form to create a new employee (`Html.BeginForm("Create","Employee", FormMethod.Post)`).
  - Displays buttons/ActionLinks for bulk operations with JavaScript `confirm(...)`.

- `Views/Shared/_Layout.cshtml` — Bootstrap-based layout (title and main container).

- `App_Start/RouteConfig.cs` — sets default route to `{controller=Employee}/{action=Index}`.

- `Web.config` — connection string entry:
  - `connectionStrings -> DBConnection` points to local SQL Server instance `Practical12Db`.

## Database (expected)
This project expects a SQL Server database `Practical12Db` with an `EMPLOYEE` table. Example DDL:
