# Practical_11 - Project Structure

Overview
- ASP.NET MVC application 
- Simple CRUD example around a `Person` entity with a repository, service, controllers and Razor views.
- Default route directs to the `Person` controller `Index` action.

Project structure and purpose of key files
- `Global.asax.cs`
  - Application entry point. Hooks start-up logic and registers routing / other application-level events.

- `App_Start\RouteConfig.cs`
  - Registers MVC routes. The default route is configured to `Person/Index`:
    - `url: "{controller}/{action}/{id}"`
    - `defaults: new { controller = "Person", action = "Index", id = UrlParameter.Optional }`

- `Models\Entity\Person.cs`
  - Domain/entity model for a person. Contains properties that represent the `Person` data (e.g., Id, Name, etc.).

- `Models\Data\Data.cs`
  - Data layer configuration or in-memory data holder (e.g., DbContext wrapper or static seed data). Central place where application data is persisted/seeded.

- `Models\Repository\PersonRepository.cs`
  - Data access implementation for `Person`. Encapsulates CRUD operations and persistence concerns (reads/writes to `Data`/DbContext).

- `Models\Service\PersonService.cs`
  - Business logic layer. Uses the repository to perform operations, applies validation or business rules, and exposes higher-level methods for controllers.

- `Controllers\PersonController.cs`
  - Controller responsible for `Person`-related endpoints (Index, Create, Edit, Delete). Orchestrates calls to `PersonService` and returns views or redirects.

- `Controllers\HomeController.cs`
  - Typical home controller. Usually provides the application landing page or simple informational actions (e.g., `Index`).

- `Views\Shared\_Layout.cshtml`
  - Shared layout for Razor views (HTML shell, navigation, scripts, common styling).

- `Views\Home\Index.cshtml`
  - View for `HomeController`'s index action (landing page content).

- `Views\Person\Index.cshtml`
  - Lists people (main listing view for the `Person` entity).

- `Views\Person\Create.cshtml`
  - Form view to create a new `Person`.

- `Views\Person\Edit.cshtml`
  - Form view to edit an existing `Person`.

- `Views\Person\Delete.cshtml`
  - Confirmation view for deleting a `Person`.

How to run
- Open the `Practical_11` solution in Visual Studio 2026.
- Build the project and run (F5). The app defaults to the `Person` index page.

Notes
- If you want more detail (file contents, model properties, or diagram), I can generate a more detailed README or an architecture diagram.