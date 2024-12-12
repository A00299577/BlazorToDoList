using BlazorToDoList.App.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace BlazorToDoList.App.Services
{
    public class FileService : IFileService
    {
        private readonly IConfiguration _configuration;

        public FileService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ReadFromFile()
        {
            string path = @"C:\Users\MuraliGanta\Desktop\code\BlazorToDoList\sample-data\todoitems.json";
            return File.ReadAllText(path);
        }

        public void SaveToFile(List<ToDoItem> toDoItems)
        {
            string path = @"C:\Users\MuraliGanta\Desktop\code\BlazorToDoList\sample-data\todoitems.json";
            string json = JsonConvert.SerializeObject(toDoItems);
            System.IO.File.WriteAllText(path, json);
        }
    }
}
