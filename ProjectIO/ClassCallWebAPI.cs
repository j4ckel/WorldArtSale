using Newtonsoft.Json;
using Repositoty;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIO
{
    public class ClassCallWebAPI
    {

        public ClassCallWebAPI()
        {

        }

        public async Task<byte[]> GetURLContentsAsync(string url)
        {
            // The downloaded resource ends up in the variable named content.
            var content = new MemoryStream();

            // Initialize an HttpWebRequest for the current URL.
            var webReq = (HttpWebRequest)WebRequest.Create(url);

            // Send the request to the Internet resource and wait for
            // the response.
            // Note: you can't use HttpWebRequest.GetResponse in a Windows Store app.
            using (WebResponse response = await webReq.GetResponseAsync())
            {
                // Get the data stream that is associated with the specified URL.
                using (Stream responseStream = response.GetResponseStream())
                {
                    // Read the bytes in responseStream and copy them to content.
                    await responseStream.CopyToAsync(content);
                }
            }

            // Return the result as a byte array.
            return content.ToArray();
        }
        public async Task<ObservableCollection<ZipCity>> GetZipCitySearch(string url)
        {
            WebRequest webReq = WebRequest.Create(url);
            WebResponse webRes = await webReq.GetResponseAsync();
            string jsonString;

            using (Stream stream = webRes.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);

                jsonString = await reader.ReadToEndAsync();
            }
            ObservableCollection<ZipCity> zc = await Task.Run(() => JsonConvert.DeserializeObject<ObservableCollection<ZipCity>>(jsonString));
            return zc;
        }

    }
}
