using System.Collections.Generic;
using System.Xml.Serialization;

namespace CachProjectConsole.Models
{
    [XmlRoot("rsp")]
    public class FlickrPhotoRsp
    {
        [XmlElement("photo")]
        public FlickrPhoto Photo { set; get; }
    }

    public class FlickrPhoto
    {
        [XmlElement("title")]
        public string Title { set; get; }

        [XmlElement("description")]
        public string Description { set; get; }

        [XmlElement("urls")]
        public List<string> Urls { set; get; }

        [XmlElement("tags")]
        public List<FlickrTags> Tags { set; get; }

        [XmlElement("dates")]
        public FlickrDate Date { set; get; }

        [XmlElement("visibility")]
        public FlickrVisisibility Visisibility { set; get; }


    }

    public class FlickrUrl
    {
        [XmlElement("url")]
        public string Url { set; get; }
    }

    public class FlickrTags
    {
        [XmlElement("tag")]
        public string Tags { set; get; }
    }

    public class FlickrTag
    {
        [XmlAttribute("raw")]
        public string Tag { set; get; }
    }

    public class FlickrDate
    {
        [XmlAttribute("taken")]
        public string Date { set; get; }

        [XmlAttribute("takengranularity")]
        public string Granularity { set; get; }
    }

    public class FlickrVisisibility
    {
        [XmlAttribute("ispublic")]
        public string Public { set; get; }
    }
}
