using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChangeWallpaperUnplash.Backend
{
    public class Get
    {
        private static List<string> listAPIS = new List<string>{ "YOUR_API_LIST" };
        private static string apiUrl = "https://api.unsplash.com/photos/random?client_id=";


        public static async Task<bool> GetAsync()
        {
            var httpClient = new HttpClient();
            var response = new HttpResponseMessage();
            try
            {
                for(int i = 0; i <= listAPIS.Count; i++)
                {
                    string newApiUrl = apiUrl + listAPIS[i];
                    response = await httpClient.GetAsync(newApiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        httpClient = new HttpClient();
                        var json = await httpClient.GetStringAsync(newApiUrl);
                        var jsonObject = JObject.Parse(json);
                        var imageUrl = (string)jsonObject["urls"]["full"];

                        string directory = @"" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LEOzD\\downloads";

                        Directory.CreateDirectory(directory);

                        string fileName = directory + @"\" + (string)jsonObject["id"] + ".jpg";

                        new WebClient().DownloadFile(imageUrl, fileName);
                        Wallpaper.Set(new Uri(fileName), Wallpaper.Style.Fill);

                        return true;
                    }
                }
                
            }
            catch(Exception ex)
            {
                return false;
            }

            return false;
        }

        public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }
    }
}
