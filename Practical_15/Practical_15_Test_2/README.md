# Practical 15 (Part 2) — MVC Form Authentication

Project: `Practical_15_Test_2`  

## Objective
Create an ASP.NET MVC application that implements form-based authentication and uses a database table to validate users.

## High-level implementation
- Authentication: ASP.NET Forms Authentication (configured in `Web.config`).
- Login flow: User submits credentials in the `Login` view → `AccountController.Login` posts the model → `AccountService.ValidateUser` → `AccountRepository.ValidateUser` queries the database → on success `FormsAuthentication.SetAuthCookie` is called.
- Authorization: Anonymous users are denied globally (redirect to login) via `Web.config` `<authorization><deny users="?" /></authorization>`.

## Important files / responsibilities
- `Web.config`
  - Sets `<authentication mode="Forms">` and `loginUrl="~/Account/Login"`.
  - Declares `<authorization><deny users="?" /></authorization>` so unauthenticated requests are redirected.
  - Contains connection string named `DbConnection` pointing to `Practical15Test2Db`.
- `Global.asax.cs`
  - Registers areas, routes, filters and bundles.
- `Controllers/AccountController.cs`
  - `Login()` GET returns login view.
  - `Login(User user)` POST validates user and, if valid, calls `FormsAuthentication.SetAuthCookie(user.UserName, false)` then redirects to `Home/Index`.
  - `Logout()` signs out via `FormsAuthentication.SignOut()` and redirects to login.
- `Models/Service/AccountService.cs`
  - Simple service layer that calls the repository: `ValidateUser(User user)`.
- `Models/Repository/AccountRepository.cs`
  - Connects to DB using `ConfigurationManager.ConnectionStrings["DbConnection"]`.
  - Runs parameterized SQL to check user existence:
    - Query: `SELECT COUNT(*) FROM Users WHERE UserName=@UserName AND Password=@Password`
- `Models/Entities/User.cs`
  - POCO with `UserName` and `Password` properties.
- `Views/Account/Login.cshtml`
  - Form with fields bound to `User.UserName` and `User.Password`.
- `Views/Shared/_Layout.cshtml`
  - Project layout and page shell.

## Database schema
Create a database named `Practical15Test2Db` (or update the `DbConnection` connection string in `Web.config`).

SQL to create the `Users` table and insert a sample user (the repository validates plaintext passwords):
