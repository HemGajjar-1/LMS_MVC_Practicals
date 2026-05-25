# Practical 15 — Test 1: Windows Authentication (ASP.NET MVC, .NET Framework 4.8.1)

## Practical objective (as given)
Create an MVC Project that implements Windows Authentication. Create tables in the database as required.

This report-style README documents the implementation, design decisions, configuration, database objects, run/verification steps, and recommendations for hardening and extension.

---

## Executive summary
This solution is a minimal ASP.NET MVC application that demonstrates how to:
- Authenticate users using Windows Authentication.
- Capture the authenticated identity on the server.
- Persist a login event to a SQL Server database (`UserLog` table).
- Display the authenticated username in the view.

The project is implemented on `.NET Framework 4.8.1` and uses Integrated Security to access SQL Server. The sample is intentionally small to focus on the authentication→persistence→presentation workflow required by the practical.

---

## Environment & prerequisites
- Visual Studio with ASP.NET Web Development workload.
- .NET Framework 4.8.1 (project targets this TFM).
- SQL Server (local or remote) reachable from the development machine and configured for Windows Authentication.
- The executing Windows account (or application pool identity when using IIS) must have INSERT rights on the target `UserLog` table.
- To debug with Windows Authentication in Visual Studio, adjust the project debug settings as described below.

When we reference Visual Studio settings, use these names exactly in the IDE:
- __Project Properties > Web__
- __Windows Authentication__
- __Anonymous Authentication__

---

## Project layout (files examined)
- `Practical_15_Test_1\Controllers\HomeController.cs`  
  - Implements action `Index`. Reads `User.Identity.Name`, inserts a record into `UserLog` using the `DbConnection` connection string, sets `ViewBag.UserName`, and returns the `Index` view.

- `Practical_15_Test_1\Views\Home\Index.cshtml`  
  - Razor view used by `HomeController.Index`. Renders a simple UI showing the logged-in Windows username from `ViewBag.UserName`.

- `Practical_15_Test_1\Views\Shared\_Layout.cshtml`  
  - Shared layout for application pages. Contains CSS/JS bundles, top navigation, and the `@RenderBody()` placeholder.

- `Practical_15_Test_1\Web.config`  
  - Application configuration including:
    - `<compilation debug="true" targetFramework="4.8.1" />`
    - `<httpRuntime targetFramework="4.8.1" />`
    - Windows Authentication (`<authentication mode="Windows" />`) and authorization denying anonymous users
    - Connection string `DbConnection` (currently configured for a local SQLExpress instance with Integrated Security)
    - Assembly binding redirects and code provider configuration

---

## Implementation details — request flow & code walkthrough

1. Authentication
   - Windows Authentication is enabled for the application (`<authentication mode="Windows" />` in `Web.config`) and anonymous users are denied (`<authorization><deny users="?" /></authorization>`). When a user hits the site, the browser negotiates credentials using the current Windows identity.

2. Controller behavior
   - `HomeController.Index`:
     - Reads the authenticated username:
       - `string userName = User.Identity.Name;`
     - Reads connection string:
       - `ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString`
     - Opens a `SqlConnection`, creates a parameterized `SqlCommand`:
       - Query: `INSERT INTO UserLog(UserName, LoginDate) VALUES(@UserName, GETDATE())`
       - Parameter: `@UserName` bound via `cmd.Parameters.AddWithValue("@UserName", userName)`
     - Executes the command synchronously, assigns `ViewBag.UserName = userName`, and returns the `Index` view.

3. View rendering
   - `Index.cshtml` displays a title and the text `Logged In User: @ViewBag.UserName` inside the shared layout.

---

## Database schema (required objects)
Create the `UserLog` table used in the practical. Example script:
