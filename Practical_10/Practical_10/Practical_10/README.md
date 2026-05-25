# Practical 10 

This document describes the objectives for each test in the practical set and how they are implemented in this project. It explains which files implement each requirement, how to verify behavior, and notes/recommendations observed during review.

## Contents
- `Controllers\HomeController.cs` — entry point that returns the home view.
- `Views\Home\Index.cshtml` — navigation page linking to each test.
- `Controllers\Test3\Test3Controller.cs` and `Views\Test3\Index.cshtml` — OutputCache demo (Test 3).
- `Controllers\Test4\Test4Controller.cs` and `Filters\MyExceptionFilter.cs` — Exception filter demo (Test 4).
- (Referenced) `Employee` and `Test2` controllers — linked from the home view; not found in the inspected files.

---

## Practical Tests and Implementation

### Test 1 — Route / URL parameter demo
- Objective: Accept a string from the URL (e.g., `/Employee/Mark`) and display it on a page.
- Implementation status in this workspace:
  - The home view contains an ActionLink to `Employee`, but no `Employee` controller file was found in the inspected set.
  - Expected implementation (if present): a controller named `EmployeeController` with an action like `public ActionResult Index(string id)` or `public ActionResult Index(string name)` and a route configured so that the URL segment is passed as that parameter (either via attribute routing or a custom route in route config).
- How to verify (expected):
  - Navigate to `/Employee/Mark` and confirm the page shows `Mark`.
  - If attribute routing is used: `[Route("Employee/{name}")]` on the action, or register a route with `routes.MapRoute(...)` mapping the segment to the action parameter.

### Test 2 — ActionResult types demo
- Objective: Demonstrate multiple ActionResult types (`ContentResult`, `FileContentResult`, `EmptyResult`, `JavaScriptResult`, `JsonResult`, etc.).
- Implementation status in this workspace:
  - The home view links to a controller named `Test2`, but no `Test2Controller` file was found in the inspected set.
  - Expected implementation (if present): a `Test2Controller` with separate actions returning different ActionResult types, e.g.:
    - `ContentResult` — return plain text
    - `FileContentResult` — return a file byte array
    - `EmptyResult` — return nothing
    - `JavaScriptResult` — return executable JavaScript
    - `JsonResult` — return JSON data
- How to verify (expected):
  - Open each action URL (e.g., `/Test2/ContentDemo`) and confirm the response type and content match the expected ActionResult.

### Test 3 — OutputCache demo (cached for 5 minutes)
- Objective: Show output caching for 5 minutes; action should return the current date/time as a string and remain constant for the cache duration.
- Files:
  - `Controllers\Test3\Test3Controller.cs` — `Index()` action decorated with `[OutputCache(Duration = 300)]`. It sets `ViewBag.Time = DateTime.Now.ToString()` and returns the view.
  - `Views\Test3\Index.cshtml` — renders the timestamp.
- Behavior:
  - The `Index` action computes the current time and the output is cached for 300 seconds (5 minutes). During that interval, the same timestamp should be shown on repeated requests.
- Note / Recommendation:
  - The view uses `@ViewBag.time` (lowercase `time`) while the controller sets `ViewBag.Time` (capital `T`). This mismatch prevents the timestamp from displaying. Change the view to `@ViewBag.Time` to fix.

### Test 4 — ExceptionFilter demo
- Objective: Demonstrate an exception filter handling a Divide by Zero exception.
- Files:
  - `Controllers\Test4\Test4Controller.cs` — `Index()` action intentionally divides by zero.
  - `Filters\MyExceptionFilter.cs` — implements `IExceptionFilter`; `OnException` returns a `ContentResult` with the error message and sets `ExceptionHandled = true`.
- Behavior:
  - When navigating to the Test 4 action, the exception filter intercepts the exception and returns a plain text response like: `Error Occurred :Attempted to divide by zero.`

---

## How to test the practical quickly
1. Run the web project and open the home page (root). Use the navigation buttons to access each test (or navigate directly by URL).
2. Test 3:
   - Open `/Test3/Index` multiple times within 5 minutes; the displayed timestamp should remain the same (after fixing the ViewBag casing).
3. Test 4:
   - Open `/Test4/Index`; the page should display the filter-provided error message instead of a server error page.
4. Test 1 & Test 2:
   - If the `EmployeeController` and `Test2Controller` are present elsewhere in the solution, navigate to their sample URLs (e.g., `/Employee/Mark` and the Test2 action URLs) to verify behavior. If not present, add controllers as described above.

---

## Observations and recommendations
- Fix the `ViewBag` casing in `Views\Test3\Index.cshtml` to display cached time.
- Confirm presence of `EmployeeController` and `Test2Controller` files; if missing, add them to complete Tests 1 and 2 according to the objectives.
- `MyExceptionFilter` returns a simple `ContentResult` for clarity; consider returning a friendly view for production use.

