Practical 11 — Project structure
===============================

This file describes the project layout and the role of each file. It focuses on structure and responsibilities.

Top-level folders
- `App_Start` — application bootstrap/configuration (routing, etc.).
- `Controllers` — request handlers that coordinate UI and business logic.
- `Models` — domain types, in-memory data, repository and service layers.
  - `Entity` — domain entities.
  - `Data` — simple in-memory data store.
  - `Repository` — data-access operations over the store.
  - `Service` — business/service layer used by controllers.
- `Views` — UI templates organized per feature.
  - `Shared` — site-wide layout and shared view components.
  - `Home` — home page views.
  - `Person` — views and partials for the Person feature.

Key files and responsibilities
- `App_Start/RouteConfig.cs`
  - Configures URL routing and default route mapping (controller/action/id).

- `Controllers/PersonController.cs`
  - Implements CRUD endpoints for `Person`:
    - `Index` — list persons.
    - `Create` (GET/POST) — show form and add a new person.
    - `Edit` (GET/POST) — show form and update a person.
    - `Delete` (GET/POST) — show confirmation and delete a person.
  - Delegates data operations to the `PersonService`.

- `Models/Entity/Person.cs`
  - Domain model for a person with `Id`, `Name`, `DOB`, and `Address` properties.

- `Models/Data/PersonData.cs`
  - Holds the in-memory storage: a static `List<Person>` used as the data store for the practical.

- `Models/Repository/PersonRepository.cs`
  - Encapsulates data access against the in-memory store:
    - `GetAll()`, `GetById(int)`, `Add(Person)`, `Update(Person)`, `Delete(int)`.

- `Models/Service/PersonService.cs`
  - Business/service layer that exposes operations to controllers and forwards calls to the repository:
    - `GetAllPersons()`, `GetPerson(int)`, `AddPerson(Person)`, `UpdatePerson(Person)`, `DeletePerson(int)`.

- `Views/Shared/_Layout.cshtml`
  - Global layout template (page chrome, scripts, styles) used by views to provide consistent UI.

- `Views/Home/Index.cshtml`
  - Minimal home page view.

- `Views/Person/Index.cshtml`
  - Presents a table of all persons with action links for Create, Edit and Delete.

- `Views/Person/Create.cshtml`
  - Page rendering the creation form; includes the `_PersonForm` partial.

- `Views/Person/Edit.cshtml`
  - Page rendering the edit form for an existing person; includes the `_PersonForm` partial.

- `Views/Person/Delete.cshtml`
  - Page that presents delete confirmation; includes the `_Delete` partial.

- `Views/Person/_PersonForm.cshtml` (partial)
  - Reusable form partial used by Create and Edit for `Name`, `DOB`, `Address` fields and the submit button.

- `Views/Person/_Delete.cshtml` (partial)
  - Reusable delete-confirmation partial that shows person details in read-only form and submits the delete.

Design notes
- The project follows a simple layered flow: Controllers → Services → Repositories → Data.
- `PersonData` provides an in-memory list so the repository operates without external storage, keeping data logic isolated from UI and controllers.
- Views are organized per feature and reuse partials to reduce duplication.

Place this file at the project root as `README.md`.