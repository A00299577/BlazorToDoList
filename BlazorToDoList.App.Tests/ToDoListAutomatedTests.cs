using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;

[TestFixture]
public class ToDoListAutomatedTests
{
    private IWebDriver _driver;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
    }

    [Test, Order(1)]
    public void OpenBrowserTest()
    {
        // Navigate to the Blazor Todo List application
        _driver.Navigate().GoToUrl("http://localhost:14475/todo");
        _driver.Manage().Window.Maximize();
        Thread.Sleep(2000);

        // Verify the application loaded by checking for page title
        var pageTitle = _driver.Title;
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("BlazorApp1", pageTitle);
    }

    [Test, Order(2)]
    public void InputToDoItemTest()
    {
        _driver.Navigate().GoToUrl("http://localhost:14475/todo");
        _driver.Manage().Window.Maximize();
        Thread.Sleep(2000);

        // Find the input textbox element by tagname
        var inputField = _driver.FindElement(By.TagName("input"));
        Thread.Sleep(2000);

        // Provide input data
        inputField.SendKeys("Test Todo Item 1");
        Thread.Sleep(2000);

        // Verify that the text is entered correctly
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Test Todo Item 1", inputField.GetAttribute("value"));
    }

    [Test, Order(3)]
    public void CreateToDoItemTest()
    {
        _driver.Navigate().GoToUrl("http://localhost:14475/todo");
        _driver.Manage().Window.Maximize();
        Thread.Sleep(2000);

        // Find the input field and provide input
        var inputField = _driver.FindElement(By.TagName("input"));
        Thread.Sleep(2000);

        inputField.SendKeys("Test Todo Item 2");
        Thread.Sleep(3000);

        // Find and click the "Create" button
        var createButton = _driver.FindElement(By.XPath("//button[contains(text(), 'Create')]"));
        createButton.Click();
        Thread.Sleep(2000);

        // Verify the new Todo item appears by value in the tag
        var tdElement = _driver.FindElement(By.XPath("//td[text()='Test Todo Item 2']"));
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Test Todo Item 2", tdElement.Text);
    }

    [Test, Order(4)]
    public void DeleteToDoItemTest()
    {
        _driver.Navigate().GoToUrl("http://localhost:14475/todo");
        _driver.Manage().Window.Maximize();
        Thread.Sleep(2000);

        // Find and click the "Delete" button for the created item
        var deleteButton = _driver.FindElement(By.XPath("//i[contains(@class, 'oi-trash')]"));
        deleteButton.Click();
        Thread.Sleep(2000);
    }

    [TearDown]
    public void TearDown()
    {
        // Close the browser after each test
        _driver.Quit();
    }
}
