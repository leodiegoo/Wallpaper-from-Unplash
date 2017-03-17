using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChangeWallpaperUnplash.Backend
{
    public static class Get
    {
        private const string API_KEY = "YOUR_KEY";
        private const string apiUrl = "https://api.unsplash.com/photos/random?client_id=" + API_KEY;
        public static async Task<bool> GetAsync()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(apiUrl); ;
            var jsonObject = JObject.Parse(json);
            var imageUrl = (string)jsonObject["urls"]["full"];
            string directory = @"" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LEOzD\\downloads";
            Directory.CreateDirectory(directory);
            string fileName = directory + @"\" + (string)jsonObject["id"] + ".jpg";
            try
            {
                new WebClient().DownloadFile(imageUrl, fileName);
                Wallpaper.Set(new Uri(fileName), Wallpaper.Style.Fill);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
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
