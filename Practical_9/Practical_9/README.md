# Practical 9 — MVC Hello World & JavaScript Interaction

Project: `Practical_9`  

## Objective
This practical contains three tests demonstrating basic ASP.NET MVC views, client-side DOM manipulation (JavaScript/jQuery) and a unit test asserting controller output.

## Summary of Tests
- Test 1: Display a static "Hello World" string from a view.
- Test 2: Build a web page that prints "Hello World" into a label and allows styling (bold, italic, underline, reset) using JavaScript only.
- Test 3: Return "Hello World" from a controller via `ViewBag` and verify it using a unit test.

---

## Implementation details

### Test 1
- View: `Views/Test1/Index.cshtml`
- Behavior: Static markup displays "Hello World".
- Key lines:
  - `<h2>Hello World</h2>`

Purpose: simple view-only rendering (no controller logic required).

### Test 2
- View: `Views/Test2/Index.cshtml`
  - Contains a label `id="mylabel"` and five buttons:
    - `PRINT TEXT` (`id="button1"`)
    - `BOLD` (`id="button2"`)
    - `ITALIC` (`id="button3"`)
    - `UNDERLINE` (`id="button4"`)
    - `RESET` (`id="button5"`)
  - jQuery included via CDN and a local script reference: `~/Scripts/MyScript.js`
- Client script: `Scripts/MyScript.js`
  - Implements the required features using jQuery:
    - `#button1` sets `#mylabel` text to `"Hello World"`.
    - `#button2` sets `font-weight: bold`.
    - `#button3` sets `font-style: italic`.
    - `#button4` sets `text-decoration: underline`.
    - `#button5` resets style properties to normal.
- Notes:
  - All behavior is client-side; no additional server round-trips are used.
  - jQuery is used for concise DOM selection and CSS manipulation.

### Test 3
- Controller: `Controllers/Test3Controller.cs`
  - `Index()` action sets `ViewBag.hello = "Hello World";` and returns the view.
- View: `Views/Test3/Index.cshtml`
  - Renders the controller-provided string: `<h1>@ViewBag.hello</h1>`
- Unit test: `Practical_9.Tests/Test3ControllerTests.cs`
  - Uses xUnit.
  - Instantiates `Test3Controller`, invokes `Index()`, and asserts:
    - Result is not null.
    - `result.ViewBag.hello` equals `"Hello World"`.

---

## Files changed / created (important)
- `Views/Test1/Index.cshtml` — static Hello World view.
- `Views/Test2/Index.cshtml` — buttons and target label for Test 2.
- `Scripts/MyScript.js` — JavaScript implementation of button behaviors.
- `Controllers/Test3Controller.cs` — sets `ViewBag.hello`.
- `Views/Test3/Index.cshtml` — displays `ViewBag.hello`.
- `Practical_9.Tests/Test3ControllerTests.cs` — xUnit test for Test 3.

---

## How to run
1. Open the solution in Visual Studio 2026.
2. Ensure the startup project is `Practical_9` and target framework is .NET Framework 4.7.2.
3. Build the solution.
4. Run the web app (F5 or __Start Debugging__).
5. Navigate to the routes:
   - `/Test1` — verify "Hello World" displays.
   - `/Test2` — use the buttons to print and style the text (client-side).
   - `/Test3` — verify the controller-supplied "Hello World" displays.
6. Run unit tests via the __Test Explorer__ (or __Run All Tests__). Confirm the xUnit test `CheckHelloWorld` passes.

---
