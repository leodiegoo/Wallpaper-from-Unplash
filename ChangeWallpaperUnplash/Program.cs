using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace ChangeWallpaperUnplash
{
    class Program
    {
        private const string apiUrl = "https://api.unsplash.com/photos/random?client_id=14c5fdeca53f9644d67641b3bd77bbdadfc0b05f03c29f3a206605d68f654876";
        static void Main(string[] args)
        {
            MainAsync().Wait();
            Console.ReadKey();
        }

        static async Task MainAsync()
        {
            String line;
            string json = "";
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Users\\leonardo.ITEBAURU\\Dropbox\\Projetos Visual Studio\\ChangeWallpaperUnplash\\ChangeWallpaperUnplash\\json.txt");

                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    json += line;
                    //write the lie to console window
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            //var httpClient = new HttpClient();
            //var json = await httpClient.GetStringAsync(apiUrl);
            //var teste = JsonConvert.DeserializeObject(json);
            var jsonObject = JObject.Parse(json);
            var imageUrl = (string)jsonObject["urls"]["full"];
            Directory.CreateDirectory(@"C:\downloads");
            string fileName = @"C:\downloads\" + (string)jsonObject["id"] + ".jpg";
            try
            {
                new WebClient().DownloadFile(imageUrl, fileName);
                Console.WriteLine("Downloaded");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            Wallpaper.Set(new Uri(fileName), Wallpaper.Style.Stretched);
            Console.WriteLine("Setted");
        }
    }
}
