using System.Collections.Generic;
using System.Xml.Serialization;

namespace CachProjectConsole.Models
{
    [XmlRoot("rsp")]
    public class FlickrCollectionRsp
    {
        [XmlElement("collections")]
        public FlickrCollections Flickrsets { set; get; }
    }

    public class FlickrCollections
    {

        [XmlElement("collection")]
        public List<FlickrCollection> FlickrCollection { set; get; }
    }

    public class FlickrCollection
    {
        [XmlAttribute("id")]
        public string Id { set; get; }

        [XmlAttribute("title")]
        public string Title { set; get; }

        [XmlAttribute("description")]
        public string Description { set; get; }

        [XmlAttribute("iconlarge")]
        public string Icon { set; get; }

        [XmlElement("set")]
        public List<FlickrSet> Sets { set; get; }
    }

    public class FlickrSet
    {
        [XmlAttribute("id")]
        public string Id { set; get; }

        [XmlAttribute("title")]
        public string Title { set; get; }

        [XmlAttribute("description")]
        public string Description { set; get; }

        public string Icon { set; get; }
        public List<FlickrPhotoInSet> Photos { set; get; } 
    }
}
