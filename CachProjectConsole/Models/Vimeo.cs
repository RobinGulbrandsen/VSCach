using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace CachProjectConsole.Models
{
    [XmlRoot("videos")]
    public class Vimeo
    {
        [XmlElement("video")]
        public List<VimeoVideo> VimeoVideos { set; get; } 
    }

    public class VimeoVideo
    {
        [XmlElement("id")]
        public string Id { set; get; }

        [XmlElement("title")]
        public string Title { set; get; }

        [XmlElement("url")]
        public string Url { set; get; }

        [XmlElement("upload_date")]
        public string UploadDate { set; get; }

        [XmlElement("thumbnail_small")]
        public string ThumbnailSmall { set; get; }

        [XmlElement("thumbnail_medium")]
        public string ThumbnailMedium { set; get; }

        [XmlElement("thumbnail_large")]
        public string ThumbnailLarge { set; get; }

        [XmlElement("duration")]
        public int Duration { set; get; }

        [XmlElement("width")]
        public int Width { set; get; }

        [XmlElement("height")]
        public int Height { set; get; }

        [XmlElement("embed_privacy")]
        public string Privacy { set; get; }

        [XmlElement("tags")]
        public string VimeoTags { set; get; } 
    }
}
