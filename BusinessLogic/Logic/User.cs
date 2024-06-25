using BusinessLogic.Logic;
using BusinessLogic.Repository;
using DataAccess.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Hosting;
using static System.Net.WebRequestMethods;
using BusinessLogic.Json;
using System.Web.Routing;

namespace BusinessLogic
{
    public class User
    {
        public int Id { get; set; }
        
        public string LastNum(int lastValues)
        {
            IRepositoryImage image = new RepositoryImage();
            return image.GetImage(lastValues);
        }

        public string Vowels(string userIdentifier)
        {
            //UserIdentifier has [a.e.i.o.u]
            char[] arrayID = userIdentifier.ToCharArray();
            List<char> listVowels = new List<char>() {
                'a', 'e', 'i', 'o', 'u'
            };
            List<char> listFind = new List<char>();
            foreach (char c in listVowels)
            {
               bool find= Array.Exists(arrayID, element => element == c);
                if (find)
                {
                    return "https://api.dicebear.com/8.x/pixel-art/png?seed=vowel&size=150";
                }
            }
            return "";
        }

        public string NonAlphanumeric()
        {
            try
            {
                Random random = new Random();
                int round= random.Next(1,6);

                JsonFile file = new JsonFile();
                Image img = new Image();
                img = file.ReadJsonFile(round);

                return img.url;

            }catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}