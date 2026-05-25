# Practical: Test 3 — Employee & Designation (ADO.NET MVC)

Overview
- Purpose: Implement database objects and ADO.NET-based MVC operations for `Designation` and `Employee` per the Test 3 specification.

Repository layout (suggested)
- `Sql/` — SQL scripts (create tables, view, indexes, SPs, sample data).
- `WebApp/` — ASP.NET MVC project targeting `.NET Framework 4.8.1`
  - `Controllers/` — controller actions that call repository methods
  - `Models/` — `Designation`, `Employee` POCOs
  - `Repositories/` — ADO.NET data access (SqlConnection, SqlCommand)
  - `Views/` — Razor views for insert/list operations
- `README.md` — this file

Database schema (SQL Server)
- `Designation`:
  - `Id` INT IDENTITY PRIMARY KEY NOT NULL
  - `Designation` NVARCHAR(50) NOT NULL
- `Employee`:
  - `Id` INT IDENTITY PRIMARY KEY NOT NULL
  - `FirstName` NVARCHAR(50) NOT NULL
  - `MiddleName` NVARCHAR(50) NULL
  - `LastName` NVARCHAR(50) NOT NULL
  - `DOB` DATE NOT NULL
  - `MobileNumber` NVARCHAR(10) NOT NULL
  - `Address` NVARCHAR(100) NULL
  - `Salary` DECIMAL(18,2) NOT NULL
  - `DesignationId` INT NULL (FK → `Designation.Id`)

Key SQL scripts (save in `Sql/`)
- `create_tables.sql` — creates `Designation` and `Employee` with FK.
- `sample_inserts.sql` — inserts sample `Designation` and `Employee` rows.
- `create_view.sql` — creates `vw_EmployeeDetails` returning EmployeeId, FirstName, MiddleName, LastName, Designation, DOB, MobileNumber, Address, Salary.
- `sp_InsertDesignation.sql` — stored proc to insert a designation and return new Id.
- `sp_InsertEmployee.sql` — stored proc to insert an employee and return new Id.
- `sp_GetEmployeesByDOB.sql` — returns employees with Designation ordered by DOB.
- `sp_GetEmployeesByDesignation.sql` — accepts `@DesignationId` and returns employees ordered by FirstName.
- `create_index.sql` — creates non-clustered index `IX_Employee_DesignationId` on `Employee(DesignationId)`.

Essential queries to verify
- Count employees by designation:
  SELECT d.Designation, COUNT(e.Id) AS EmployeeCount
  FROM Designation d LEFT JOIN Employee e ON e.DesignationId = d.Id
  GROUP BY d.Designation;
- Employee full name with designation:
  SELECT e.FirstName, e.MiddleName, e.LastName, d.Designation
  FROM Employee e LEFT JOIN Designation d ON e.DesignationId = d.Id;
- Designations with > 1 employee:
  SELECT d.Designation FROM Designation d JOIN Employee e ON e.DesignationId = d.Id
  GROUP BY d.Designation HAVING COUNT(e.Id) > 1;
- Employee with maximum salary:
  SELECT TOP 1 e.*, d.Designation FROM Employee e LEFT JOIN Designation d ON e.DesignationId = d.Id
  ORDER BY e.Salary DESC;

ADO.NET + MVC implementation notes
- Connection string: add to `Web.config`
  <connectionStrings>
    <add name="DefaultConnection" connectionString="Server=.;Database=YourDb;Trusted_Connection=True;" providerName="System.Data.SqlClient" />
  </connectionStrings>
- Use repository classes to wrap ADO.NET calls. Always:
  - Use `using` for `SqlConnection`, `SqlCommand`, `SqlDataReader`.
  - Use parameterized commands (`SqlParameter`) and `CommandType.StoredProcedure` for SPs.
  - Return typed POCOs from repository methods.
- Example repo patterns:
  - `InsertDesignation(string name)` → call `sp_InsertDesignation` → `ExecuteScalar()` for new Id.
  - `InsertEmployee(Employee e)` → call `sp_InsertEmployee` with parameters → `ExecuteScalar()`.
  - `GetEmployeesByDob()` → call `sp_GetEmployeesByDOB` → `ExecuteReader()` map rows to `Employee` model.

Controller & Views
- Controllers call repository methods and return Views or JSON.
- Validate user input before calling DB.
- Use simple Razor views to display lists (from `vw_EmployeeDetails` or stored procs) and forms for inserts.

Build & run (Visual Studio 2026)
1. Create database and run scripts in `Sql/` (order: create_tables → create_index → create_view → stored procedures → sample_inserts).
2. Open solution in Visual Studio 2026.
3. Ensure project targets `.NET Framework 4.8.1`.
4. Update connection string in `Web.config`.
5. Use __Build > Rebuild Solution__, then run with __Debug > Start Debugging__.
6. Use UI to insert and list records, or verify queries in SQL Server Management Studio.

Verification checklist
- `vw_EmployeeDetails` returns requested columns.
- `sp_InsertDesignation` and `sp_InsertEmployee` insert rows and return new Ids.
- `sp_GetEmployeesByDOB` and `sp_GetEmployeesByDesignation` return correctly ordered records.
- `IX_Employee_DesignationId` exists.
- Queries for counts, designation filtering (>1 employee), and max salary return expected results.

Best practices & notes
- Always use parameterized commands to prevent SQL injection.
- Keep DB logic in stored procedures where appropriate for this practical.
- Encapsulate ADO.NET access in repositories for testability.
- Add unit/integration tests that run against a test database if required.

Files to include in repository
- `Sql/create_tables.sql`
- `Sql/create_view.sql`
- `Sql/create_index.sql`
- `Sql/sp_InsertDesignation.sql`
- `Sql/sp_InsertEmployee.sql`
- `Sql/sp_GetEmployeesByDOB.sql`
- `Sql/sp_GetEmployeesByDesignation.sql`
- `Sql/sample_inserts.sql`
- `WebApp/Models/Designation.cs`
- `WebApp/Models/Employee.cs`
- `WebApp/Repositories/EmployeeRepository.cs`
- `WebApp/Controllers/EmployeeController.cs`
- `README.md` (this file)

Contact / further work
- Add XML documentation on public APIs and `CONTRIBUTING.md` if handing off the project.
- Consider adding migrations or versioned SQL scripts for repeatable database setup.