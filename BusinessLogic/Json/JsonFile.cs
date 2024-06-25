using System.IO;
using System.Threading.Tasks;
using System.Text.Json;
using BusinessLogic.Logic;
using System.Web.Hosting;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace DataAccess.Json
{
    public class JsonFile
    {
        public Image ReadJsonFile(int id)
        {

            string filePath = HostingEnvironment.MapPath("~/Utils/db.json");
            Image img = new Image();
            List<Image> listImg= new List<Image>();
            try
            {
                if (File.Exists(filePath))
                {
                    using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {

                        using (StreamReader reader = new StreamReader(stream))
                        {
                            string jsonData = System.IO.File.ReadAllText(filePath);
                             JObject jsonObject = JObject.Parse(jsonData);

                            listImg = JsonConvert.DeserializeObject<List<Image>>(jsonObject["images"].ToString());
                            return listImg.FirstOrDefault(e => e.id == id);
                        }

                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Archivo no encontrado: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Acceso denegado: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error de E/S: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
            }
            return img;


        }

    }
}
