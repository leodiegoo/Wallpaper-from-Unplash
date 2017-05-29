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
        private static List<string> listAPIS = new List<string>{ "14c5fdeca53f9644d67641b3bd77bbdadfc0b05f03c29f3a206605d68f654876", "64159d4c29231bea3cfc66dbd73e86576a350f54ec609b319dae6f8266b647d0" };
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
                        foreach (FileInfo file in new DirectoryInfo(directory).GetFiles())
                        {
                            file.Delete();
                        }

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
