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
        private const string apiUrl = "https://api.unsplash.com/photos/random?client_id=14c5fdeca53f9644d67641b3bd77bbdadfc0b05f03c29f3a206605d68f654876";
        public static async Task<bool> GetAsync()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(apiUrl);
            var jsonObject = JObject.Parse(json);
            var imageUrl = (string)jsonObject["urls"]["full"];
            Directory.CreateDirectory(@"C:\downloads");
            string fileName = @"C:\downloads\" + (string)jsonObject["id"] + ".jpg";
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
