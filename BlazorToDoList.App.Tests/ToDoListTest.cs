namespace BlazorToDoList.Tests
{
    using BlazorToDoList.App.Models;
    using BlazorToDoList.App.Services;
    using Microsoft.Extensions.DependencyInjection;
    using Moq;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
        using System.Diagnostics;
        using System.Linq;
    using Xunit;

    public class ToDoListTest
    {
        private Mock<IFileService> _mockFileService;
        private IToDoService _toDoService;
        private List<ToDoItem> _testData;


        //public void ReadJson() {
        //    var json = File.ReadAllText(@"C:\Users\MuraliGanta\Desktop\code\BlazorToDoList\BlazorToDoList.App.Tests\bin\Debug\net8.0\sample-data\todoitems.json");
        //    _testData = JsonConvert.DeserializeObject<List<ToDoItem>>(json);
        //}  
        public ToDoListTest()
        {
            var serviveProvider = new ServiceCollection()
                .AddScoped<IToDoService, ToDoService>()
                .AddScoped<IFileService, FileService>()
                .BuildServiceProvider();
                
            var fileService = serviveProvider.GetService<IFileService>();


            _testData = new List<ToDoItem>();
            _mockFileService = new Mock<IFileService>();

            _mockFileService.Setup(x => x.ReadFromFile()).Returns(JsonConvert.SerializeObject(_testData));
            _mockFileService.Setup(x => x.SaveToFile(It.IsAny<List<ToDoItem>>())).Callback<List<ToDoItem>>(x => _testData = x);
            
            _toDoService = new ToDoService(_mockFileService.Object);
            
        }     

        [Fact]
        public void CreateItemTest()
        {
            
            //Arrange
             var testDescription = "Test Item";

            // Act
            var existingItems = _toDoService.Get();
             var existingItem = existingItems.FirstOrDefault(x => x.Description == testDescription);
            if (existingItem != null)
            {
                _toDoService.Delete(existingItem.ID);
            }

            var newItem = new ToDoItem
            {
                ID = Guid.NewGuid(),
                Description = testDescription,
                IsComplete = false,
                DateCreated = DateTime.Now
            };
            _toDoService.Add(newItem);

            var itemsAfterAdd = _toDoService.Get();

            // Assert
            Assert.Contains(itemsAfterAdd, x => x.Description == testDescription);
        }

        // [Fact]
        // public void DeleteItemTest()
        // {
        //     // Arrange
        //     CreateItemTest();
        //     var testDescription = "Test Item";
        //     var items = _toDoService.Get();
        //     var itemToDelete = items.First(x => x.Description == testDescription);

        //     // Act
        //     _toDoService.Delete(itemToDelete.ID);
        //     var itemsAfterDelete = _toDoService.Get();

        //     // Assert
        //     Assert.DoesNotContain(itemsAfterDelete, x => x.Description == testDescription);
        // }

        // [Fact]
        // public void ToggleTest()
        // {
        //     // Arrange
        //     CreateItemTest();
        //     var testDescription = "Test Item";
        //     var items = _toDoService.Get();
        //     var itemToToggle = items.First(x => x.Description == testDescription);

        //     // Act
        //     Assert.False(itemToToggle.IsComplete, "Item should not be checked initially.");

        //     _toDoService.Toggle(itemToToggle.ID);
        //     var itemsAfterToggle = _toDoService.Get();
        //     var toggledItem = itemsAfterToggle.First(x => x.Description == testDescription);

        //     Assert.True(toggledItem.IsComplete, "Item should be checked after toggling.");

        //     // Cleanup
        //     DeleteItemTest();
        // }

        // [Fact]
        // public void UnToggleTest()
        // {
        //     // Arrange
        //     CreateItemTest();
        //     var testDescription = "Test Item";
        //     var items = _toDoService.Get();
        //     var itemToUnToggle = items.First(x => x.Description == testDescription);

        //     // Act
        //     Assert.False(itemToUnToggle.IsComplete, "Item should not be checked initially.");

        //     _toDoService.Toggle(itemToUnToggle.ID);
        //     var itemsAfterFirstToggle = _toDoService.Get();
        //     var toggledItem = itemsAfterFirstToggle.First(x => x.Description == testDescription);

        //     Assert.True(toggledItem.IsComplete, "Item should be checked after first toggling.");

        //     _toDoService.Toggle(itemToUnToggle.ID);
        //     var itemsAfterSecondToggle = _toDoService.Get();
        //     var unToggledItem = itemsAfterSecondToggle.First(x => x.Description == testDescription);

        //     // Assert
        //     Assert.False(unToggledItem.IsComplete, "Item should not be checked after second toggling.");

        //     // Cleanup
        //     DeleteItemTest();
        // }

        // [Fact]
        // public void GetItemByIdTest()
        // {
        //     // Arrange
        //     CreateItemTest();
        //     var testDescription = "Test Item";
        //     var items = _toDoService.Get();
        //     var expectedItem = items.First(x => x.Description == testDescription);

        //     // Act
        //     var result = _toDoService.Get(expectedItem.ID);

        //     // Assert
        //     Assert.NotNull(result);
        //     Assert.Equal(expectedItem.ID, result.ID);
        //     Assert.Equal(expectedItem.Description, result.Description);
        // }

        // [Fact]
        // public void VerifyItemExistsTest()
        // {
        //     // Arrange
        //     var newItem = new ToDoItem
        //     {
        //         ID = Guid.NewGuid(),
        //         Description = "Test Item",
        //         IsComplete = false,
        //         DateCreated = DateTime.Now
        //     };
        //     _toDoService.Add(newItem);

        //     // Act
        //     var allItems = _toDoService.Get();
        //     var itemExists = allItems.Any(x => x.ID == newItem.ID);

        //     // Assert
        //     Assert.True(itemExists, "The item should exist in the list.");
        // }
        
    }
}
