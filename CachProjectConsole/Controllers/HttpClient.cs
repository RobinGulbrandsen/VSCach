using System;
using System.IO;
using System.Net;
using System.Text;

namespace CachProjectConsole.Controllers
{
    class HttpClient
    {
        public static string Get(string url)
        {
            // Create a request using a URL that can receive a post.
            var request = WebRequest.Create(url);
            request.Method = "GET";

            // Get the original response.
            var response = request.GetResponse();

            // Get the stream containing all content returned by the requested server.
            var dataStream = response.GetResponseStream();

            // Open the stream using a StreamReader for easy access.
            if (dataStream == null) return null;

            var reader = new StreamReader(dataStream);

            // Read the content fully up to the end.
            var responseFromServer = reader.ReadToEnd();

            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }

        public static void Post(string url, string data)
        {
            // Create a request using a URL that can receive a post. 
            var request = WebRequest.Create(url);

            // Create POST data and convert it to a byte array.
            var byteArray = Encoding.UTF8.GetBytes(data);

            // Setting up the headers for the post request
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;

            // Get the request stream.
            var dataStream = request.GetRequestStream();

            // Write the data to the request stream and close.
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
        }
    }
}
