using System;
using System.Collections.Generic;
using CachProjectConsole.Controllers;
using CachProjectConsole.Models;
using Newtonsoft.Json;

namespace CachProjectConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
            //FlickrController.HandleFlickr();
            //VimeoController.HandleVimeo();
            var prefix = "http://localhost:62639/api/v1/";
            var active = HttpClient.Get(prefix + "settings/CacheActive");
            var interval = HttpClient.Get(prefix + "settings/CacheInterval");
            var time = HttpClient.Get(prefix + "settings/CacheTime");

            Console.WriteLine("Active : " + active);
            Console.WriteLine("interval : " + interval);
            Console.WriteLine("time : " + time);
            */

            var testData = GetTestData();
            var json = JsonConvert.SerializeObject(testData);

            HttpClient.Post("http://localhost:62639/api/v1/flickr/collection", json);

            Console.WriteLine("Finished...");
            Console.ReadKey();
        }
        private static FlickrCollections GetTestData()
        {
            var listSizes = new List<string>();
            listSizes.Add("size1");

            var listTags = new List<string>();
            listTags.Add("tag1");

            //Images
            var photo1 = new FlickrPhotoInSet()
            {
                DateGranulatiry = 8,
                DateTaken = new DateTime(2014, 07, 31),
                Description = "Description image 1",
                Id = "1234",
                IsPrimary = "true",
                IsPublic = true,
                Sizes = listSizes,
                Tags = listTags,
                Title = "Title Image 1"
            };

            var photo2 = new FlickrPhotoInSet()
            {
                DateGranulatiry = 8,
                DateTaken = new DateTime(2014, 07, 31),
                Description = "Description image 2",
                Id = "2345",
                IsPrimary = "true",
                IsPublic = true,
                Sizes = listSizes,
                Tags = listTags,
                Title = "Title Image 2"
            };

            //Set
            var set1 = new FlickrSet()
            {
                Description = "Description set 1",
                Icon = "http.icon.no",
                Id = "0100",
                Title = "title set 1"
            };

            //Collection
            var collection1 = new FlickrCollection()
            {
                Id = "1000",
                Description = "Description collection 1",
                Icon = "http.icon.no",
                Title = "Title collection 1"
            };

            //creating lists
            var listPhotos = new List<FlickrPhotoInSet>();
            listPhotos.Add(photo1);
            listPhotos.Add(photo2);

            var listSet = new List<FlickrSet>();
            listSet.Add(set1);

            var listCollection = new List<FlickrCollection>();
            listCollection.Add(collection1);

            var returnCollection = new FlickrCollections();

            //Adding the lists to the objects
            returnCollection.FlickrCollection = listCollection;
            collection1.Sets = listSet;
            set1.Photos = listPhotos;

            return returnCollection;
        }
    }
}
