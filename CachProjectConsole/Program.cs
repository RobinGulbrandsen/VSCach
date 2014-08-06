using System;
using System.Collections.Generic;
using System.IO;
using CachProjectConsole.Controllers;
using CachProjectConsole.Models;
using Newtonsoft.Json;

namespace CachProjectConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            FlickrController.HandleFlickr();
            var json = File.ReadAllText("flickr.json");
            HttpClient.Post("http://localhost:62639/api/v1/flickr/collection", json);
            
            //VimeoController.HandleVimeo();
            
            Console.WriteLine("Finished...");
            Console.ReadKey();
        }
    }
}
