using System.Collections.Generic;
using System.Xml.Serialization;

namespace CachProjectConsole.Models
{
    [XmlRoot("rsp")]
    public class FlickrPhotoSizesRsp
    {
        [XmlElement("sizes")]
        public FlickrPhotoSizes Sizes { set; get; }
    }

    public class FlickrPhotoSizes
    {
        [XmlElement("size")]
        public List<FlickrPhotoSize> Size { set; get; }
    }

    public class FlickrPhotoSize
    {
        [XmlAttribute("label")]
        public string Label { set; get; }
        [XmlAttribute("source")]
        public string Source { set; get; }
    }
}
