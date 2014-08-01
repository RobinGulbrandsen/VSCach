using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using CachProjectConsole.Models;
using Newtonsoft.Json;

namespace CachProjectConsole.Controllers
{
    class VimeoController
    {
        private const string VimeoUrl = "http://vimeo.com/api/v2/album/2498404/videos.xml?callback=?";
        private const string MollerArkivUrl = "http://localhost:62639/api/v1/vimeo";

        public static void HandleVimeo()
        {
            //Get videos in the album
            var list = GetVimeoResponse();
            
            //Converting list to json
            var json = JsonConvert.SerializeObject(list);

            //Send data to REST
            HttpClient.Post(MollerArkivUrl, json);
        }

        private static List<VimeoVideo> GetVimeoResponse()
        {
            var rsp = new Vimeo();
            var xmlSerializer = new XmlSerializer(rsp.GetType());

            var xmlResult = HttpClient.Get(VimeoUrl);

            var xml = (Vimeo)xmlSerializer.Deserialize(new StringReader(xmlResult));

            return xml.VimeoVideos;
        }
    }
}
