namespace BlazorToDoList.Tests
{
    using BlazorToDoList.App.Models;
    using BlazorToDoList.App.Services;
    using Microsoft.Extensions.DependencyInjection;
    using Moq;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Xunit;

    public class ToDoListTest
    {
        private IToDoService _toDoService;
        private List<ToDoItem> _testData;

        public ToDoListTest()
        {
            _toDoService = new ToDoService(new FileService(null));
            ReadJson();
        }

        // Read Items from the JSON file
        public void ReadJson()
        {
            var jsonPath = @"C:\Users\MuraliGanta\Desktop\code\BlazorToDoList\sample-data\todoitems.json";
            if (File.Exists(jsonPath))
            {
                var json = File.ReadAllText(jsonPath);
                _testData = JsonConvert.DeserializeObject<List<ToDoItem>>(json);
            }
            else
            {
                _testData = new List<ToDoItem>();
            }
        }

        // 1. Create a new item
        [Fact]
        public void CreateItemTest()
        {
            const string testDescription = "Test Item";

            var existingItems = _toDoService.Get();
            var itemToDelete = existingItems.FirstOrDefault(item => item.Description == testDescription);
            if (itemToDelete != null)
            {
                _toDoService.Delete(itemToDelete.ID);
            }

            _toDoService.Add(new ToDoItem
            {
                ID = Guid.NewGuid(),
                Description = testDescription,
                IsComplete = false,
                DateCreated = DateTime.Now
            });

            var updatedItems = _toDoService.Get();
            var testItemExists = updatedItems.Any(item => item.Description == testDescription);

            Assert.True(testItemExists, $"'{testDescription}' was not found in the to-do list after adding it.");
        }

        // 2. Delete an item from an existing list
        [Fact]
        public void DeleteItemTest()
        {
            CreateItemTest();

            const string testDescription = "Test Item";
            var items = _toDoService.Get();
            var item = items.FirstOrDefault(i => i.Description == testDescription);

            Assert.NotNull(item);

            _toDoService.Delete(item.ID);

            items = _toDoService.Get();
            var itemExistsAfterDeletion = items.Any(i => i.Description == testDescription);

            Assert.False(itemExistsAfterDeletion, $"'{testDescription}' was not deleted from the to-do list.");
        }

        // 3. Toggle an item from an existing list
        [Fact]
        public void ToggleTest()
        {
            CreateItemTest();

            const string testDescription = "Test Item";
            var items = _toDoService.Get();
            var item = items.FirstOrDefault(i => i.Description == testDescription);

            Assert.NotNull(item);
            Assert.False(item.IsComplete, "The item should not be completed initially.");

            _toDoService.Toggle(item.ID);

            items = _toDoService.Get();
            item = items.FirstOrDefault(i => i.Description == testDescription);

            Assert.NotNull(item);
            Assert.True(item.IsComplete, "The item should be completed after toggling.");

            DeleteItemTest();
        }

  

    }
}
