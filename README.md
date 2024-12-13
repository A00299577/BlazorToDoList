# Blazor To-Do List

This example project creates a [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/client) application and uses it to create and manage a To-Do list of items.  This project is used in the following blog posts:


### [Using Blazor to Build a Client-Side Single-Page App with .NET Core](https://exceptionnotfound.net/using-blazor-to-build-a-client-side-single-page-app-with-net-core/)

### Testing Types and Methods
#### Types
 - Unit Testing
 - Automated UI Testing
#### Methods
 - XUnit - Unit Test Cases
 - Selenium - Automated UI Test Cases


# To-Do List Test Cases

This document outlines the test cases for verifying the functionality of the To-Do List application.

### Unit Test Cases


| **Test Case**         | **Steps**                                                                                              | **Expected Result**                                          |
|-----------------------|--------------------------------------------------------------------------------------------------------|--------------------------------------------------------------|
| **CreateItemTest**     | 1. Call `Get()` and check if "Test Item" exists, if it does, delete it.                                  | "Test Item" is deleted if it exists.                         |
|                       | 2. Call `Add("Test Item", Checkbox = false)`.                                                            | "Test Item" is added with checkbox unchecked.                |
|                       | 3. Call `Get()`.                                                                                         | List of items is retrieved.                                  |
|                       | 4. Iterate over the results of `Get()` and see if "Test Item" exists.                                    | "Test Item" should exist in the results.                     |
| **DeleteItemTest**     | 1. Call `CreateItemTest()`.                                                                               | "Test Item" is created.                                      |
|                       | 2. Iterate over the results of `Get()` and see if "Test Item" exists.                                    | "Test Item" should exist in the results.                     |
|                       | 3. Call `Delete()`.                                                                                        | "Test Item" is deleted.                                      |
|                       | 4. Call `Get()`.                                                                                         | List of items is retrieved.                                  |
|                       | 5. Iterate over the results of `Get()` and see if "Test Item" DOES NOT exist.                            | "Test Item" should not exist in the results.                 |
| **ToggleTest**         | 1. Call `CreateItemTest()`.                                                                               | "Test Item" is created.                                      |
|                       | 2. Call `Get()`.                                                                                         | List of items is retrieved.                                  |
|                       | 3. Iterate over the results of `Get()` and see if "Test Item" exists AND IT IS NOT CHECKED.              | "Test Item" exists and is unchecked.                         |
|                       | 4. Call `Toggle()`.                                                                                       | The checkbox for "Test Item" is toggled (checked).           |
|                       | 5. Call `Get()`.                                                                                         | List of items is retrieved.                                  |
|                       | 6. Iterate over the results of `Get()` and see if "Test Item" exists AND IT IS CHECKED.                  | "Test Item" exists and is checked.                           |
|                       | 7. Call `DeleteItemTest()`.                                                                               | "Test Item" is deleted.                                      |
| **UnToggleTest**       | 1. Call `CreateItemTest()`.                                                                               | "Test Item" is created.                                      |
|                       | 2. Call `Get()`.                                                                                         | List of items is retrieved.                                  |
|                       | 3. Iterate over the results of `Get()` and see if "Test Item" exists AND IT IS NOT CHECKED.              | "Test Item" exists and is unchecked.                         |
|                       | 4. Call `Toggle()`.                                                                                       | The checkbox for "Test Item" is toggled (checked).           |
|                       | 5. Call `Get()`.                                                                                         | List of items is retrieved.                                  |
|                       | 6. Iterate over the results of `Get()` and see if "Test Item" exists AND IT IS CHECKED.                  | "Test Item" exists and is checked.                           |
|                       | 7. Call `DeleteItemTest()`.                                                                               | "Test Item" is deleted.                                      |
|                       | 8. Call `Get()`.                                                                                         | List of items is retrieved.                                  |
|                       | 9. Iterate over the results of `Get()` and see if "Test Item" exists AND IT IS NOT CHECKED.              | "Test Item" exists and is unchecked again.                   |
| **EmptyToDoListTest**  | 1. Call `EmptyToDoList()`.                                                                                | The to-do list is emptied.                                   |
|                       | 2. Call `Get()`.                                                                                         | The list should be empty.                                    |
|                       | 3. Iterate over the results of `Get()` and check that no items exist.                                    | No items should exist in the list.                           |
| **GetByIDTest**        | 1. Call `CreateItemTest()`.                                                                               | "Test Item" is created.                                      |
|                       | 2. Call `GetByID(id)` where `id` is the ID of the "Test Item".                                           | The item returned should be the "Test Item" with the correct ID. |
|                       | 3. Check that the returned item matches the "Test Item" details.                                          | The returned item should have the correct name and checkbox status. |
|                       | 4. Call `DeleteItemTest()`.                                                                               | "Test Item" is deleted.                                      |

### Automated UI Test Cases


| **Test Case**              | **Steps**                                                                                              | **Expected Result**                                          |
|----------------------------|--------------------------------------------------------------------------------------------------------|--------------------------------------------------------------|
| **OpenBrowserTest**         | 1. Navigate to `http://localhost:14475/todo`.                                                          | The application is loaded successfully.                      |
|                            | 2. Maximize the browser window.                                                                        | Browser is maximized.                                        |
|                            | 3. Verify the application is loaded by checking the page title.                                         | Page title is "BlazorApp1".                                 |
| **InputToDoItemTest**       | 1. Navigate to `http://localhost:14475/todo`.                                                          | The application is loaded successfully.                      |
|                            | 2. Maximize the browser window.                                                                        | Browser is maximized.                                        |
|                            | 3. Find the input textbox element by its tag name.                                                     | Input textbox is located.                                    |
|                            | 4. Enter "Test Todo Item 1" into the input field.                                                      | Input is entered successfully.                               |
|                            | 5. Verify the entered text matches the expected value.                                                 | Input field contains "Test Todo Item 1".                    |
| **CreateToDoItemTest**      | 1. Navigate to `http://localhost:14475/todo`.                                                          | The application is loaded successfully.                      |
|                            | 2. Maximize the browser window.                                                                        | Browser is maximized.                                        |
|                            | 3. Find the input textbox element by its tag name and enter "Test Todo Item 2".                        | Input is entered successfully.                               |
|                            | 4. Find and click the "Create" button.                                                                 | Todo item is created.                                        |
|                            | 5. Verify the new Todo item appears in the list.                                                       | Item "Test Todo Item 2" is displayed in the table.          |
| **DeleteToDoItemTest**      | 1. Navigate to `http://localhost:14475/todo`.                                                          | The application is loaded successfully.                      |
|                            | 2. Maximize the browser window.                                                                        | Browser is maximized.                                        |
|                            | 3. Find and click the "Delete" button for the created Todo item.                                       | Item is deleted.                                             |
|                            | 4. Verify the Todo item no longer appears in the list.                                                 | Item "Test Todo Item 2" is removed from the table.           |



