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
            /*
            //VimeoController.HandleVimeo();
            var prefix = "http://localhost:62639/api/v1/";
            var active = HttpClient.Get(prefix + "settings/CacheActive");
            var interval = HttpClient.Get(prefix + "settings/CacheInterval");
            var time = HttpClient.Get(prefix + "settings/CacheTime");

            Console.WriteLine("Active : " + active);
            Console.WriteLine("interval : " + interval);
            Console.WriteLine("time : " + time);
            */

            //var json = File.ReadAllText("flickr.json");

            //var objList = JsonConvert.DeserializeObject<List<FlickrCollection>>(json);

            //var testData = GetTestData();
           // var json = JsonConvert.SerializeObject(testData);

            //HttpClient.Post("http://localhost:62639/api/v1/flickr/collection", json);

            Console.WriteLine("Finished...");
            Console.ReadKey();
        }
    }
}
