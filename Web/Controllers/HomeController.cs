using Antlr.Runtime.Misc;
using BusinessLogic;
using BusinessLogic.Json;
using BusinessLogic.Logic;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.WebPages;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly JsonService _jsonService;
        public HomeController(JsonService jsonService)
        {
            _jsonService = jsonService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetImageUrl(string userIdentifier)
        {
            try
            {
                string summit = "";
                User user = new User();
                //If none of the above conditions 
                summit = "https://api.dicebear.com/8.x/pixel-art/png?seed=default&size=150";
                // Si va null
                if (userIdentifier != "")
                {
                    //take the last value in the string
                    char lastValues = userIdentifier[userIdentifier.Length - 1];
                    if (lastValues.ToString().IsInt())
                    {
                        int values = int.Parse(lastValues.ToString());

                        //last digit [6.7.8.9]
                        if (values > 5 && values < 10)//Se toma de un api
                          {
                
                            string endpoint = $"https://my-json-server.typicode.com/ck-pacificdev/tech-test/images/{values}";
                            Image img = new Image();
                            img=  _jsonService.GetJsonFromUrlAsync<Image>(endpoint);
                            summit = img.url;
                          
                        }

                        //last digit [1.2.3.4.5]
                        if (values > 0 && values < 6)
                        {
                            summit = user.LastNum(values);
                        }

                    }

                    //UserIdentifier has [a.e.i.o.u]
                    Regex regex = new Regex("[aeiouAEIOU]");
                    if (regex.IsMatch(userIdentifier))
                    {
                        summit = user.Vowels(userIdentifier);
                    }

                   //UserIdentifier has non-alphanumeric character
                    Regex reg = new Regex("[^a-zA-Z0-9]");
                    if (reg.IsMatch(userIdentifier))
                    {
                        summit = user.NonAlphanumeric();
                    }
                }
               
                return Json(summit, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                TempData["Message"] = "Error al procesar los datos! " + ex.Message;
                TempData.Keep();

                return Json(null, JsonRequestBehavior.AllowGet);
            }

        }
    }
}