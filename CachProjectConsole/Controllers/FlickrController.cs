using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Xml.Serialization;
using CachProjectConsole.Models;
using Newtonsoft.Json;

namespace CachProjectConsole.Controllers
{
    class FlickrController
    {
        private const string BaseUrl = "https://api.flickr.com/services/rest/?";
        private const string PhotoListMethod = "method=flickr.photosets.getPhotos";
        private const string PhotoMethod = "method=flickr.photos.getInfo";
        private const string CollectionMethod = "method=flickr.collections.getTree";
        private const string ApiKeyUserAndFormat = "&api_key=7fa05383d113e5eec34f348b2b596237&user_id=101115693%40N04&format=rest";

        private const string CollectionUrl = BaseUrl + CollectionMethod + ApiKeyUserAndFormat;
        private const string PhotoListUrl = BaseUrl + PhotoListMethod + ApiKeyUserAndFormat;
        private const string PhotoUrl = BaseUrl + PhotoMethod + ApiKeyUserAndFormat;

        private static int count = 0;
        public static void HandleFlickr()
        {
            //Get Collections for the user
            var collections = GetCollections();

            var i = 0;
            //For each collection in the collections, get the sets
            foreach (var c in collections)
            {
                foreach (var set in c.Sets)
                {
                    var photoset = GetPhotoset(set.Id);

                    set.Photos = new List<FlickrPhotoInSet>();

                    foreach (var p in photoset.FlickrPhoto)
                    {
                        var photoFromFlickr = GetPhoto(p.Id);
                        p.SetValues(photoFromFlickr);
                        set.Photos.Add(p);

                        if (p.IsPrimary.Equals("1"))
                        {
                            set.Icon = p.Sizes.First();
                        }
                        i++;
                        Console.WriteLine("complete: " + i);

                        if (i > 2000) break;
                    }
                    if (i > 2000) break;
                } 
                if (i > 2000) break;
            }

            //convert list to string
            var json = JsonConvert.SerializeObject(collections);

            //write string to file
            File.WriteAllText("flickr.json", json, Encoding.UTF8);
        }

        public static List<FlickrCollection> GetCollections()
        {
            var rsp = new FlickrCollectionRsp();
            var xmlSerializer = new XmlSerializer(rsp.GetType());

            var xmlResult = HttpClient.Get(CollectionUrl);

            var xml = (FlickrCollectionRsp)xmlSerializer.Deserialize(new StringReader(xmlResult));

            return xml.Flickrsets.FlickrCollection;
        }

        public static FlickrPhotoset GetPhotoset(string photosetId)
        {
            var rsp = new FlickrPhotosetRsp();
            var xmlSerializer = new XmlSerializer(rsp.GetType());

            var url = PhotoListUrl + "&photoset_id=" + photosetId;

            var xmlResult = HttpClient.Get(url);

            var xml = (FlickrPhotosetRsp)xmlSerializer.Deserialize(new StringReader(xmlResult));

            return xml.Photoset;
        }

        public static FlickrPhoto GetPhoto(string photoId)
        {
            var rsp = new FlickrPhotoRsp();
            var xmlSerializer = new XmlSerializer(rsp.GetType());

            var url = PhotoUrl + "&photo_id=" + photoId;

            var xmlResult = HttpClient.Get(url);

            var xml = (FlickrPhotoRsp)xmlSerializer.Deserialize(new StringReader(xmlResult));

            return xml.Photo;
        }
    }
}
