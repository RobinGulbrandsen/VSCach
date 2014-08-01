
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace CachProjectConsole.Models
{
    [XmlRoot("rsp")]
    public class FlickrPhotosetRsp
    {
        [XmlElement("photoset")]
        public FlickrPhotoset Photoset { set; get; }
    }

    public class FlickrPhotoset
    {
        [XmlAttribute("id")]
        public string Id { set; get; }
        
        [XmlAttribute("primary")]
        public string PhotoId { set; get; }

        [XmlAttribute("title")]
        public string Title { set; get; }

        [XmlElement("photo")]
        public List<FlickrPhotoInSet> FlickrPhoto { set; get; }

        public string Photo { set; get; }
    }

    public class FlickrPhotoInSet
    {
        [XmlAttribute("id")]
        public string Id { set; get; }

        [XmlAttribute("isprimary")]
        public string IsPrimary { set; get; }

        public string Title { set; get; }
        public string Description { set; get; }
        public bool IsPublic { set; get; }
        public DateTime DateTaken { set; get; }
        public int DateGranulatiry { set; get; }
        public List<string> Tags { set; get; }
        public List<string> Sizes { set; get; }

        public void SetValues(FlickrPhoto photo)
        {
            Title = photo.Title;
            Description = photo.Description;
            Sizes = photo.Urls;
            IsPublic = photo.Visisibility.Public.Equals("1");
            DateGranulatiry = Convert.ToInt32(photo.Date.Granularity);

            Tags = new List<string>();
            foreach (var tag in photo.Tags)
            {
                Tags.Add(tag.Tags);
            }
            
            try
            {
                DateTaken = Convert.ToDateTime(photo.Date.Date);
            }
            catch (Exception e)
            {
                var p = photo.Date.Date.Replace("-00-", "-01-");
                DateTaken = Convert.ToDateTime(p);
            }
        }
    }
}
