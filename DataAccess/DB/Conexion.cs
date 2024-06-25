using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataAccess
{
    public class Conexion : HttpApplication
    {
       public static string cadena =ConfigurationManager.ConnectionStrings["SQLiteDbContext"].ToString();
       
    }
}
     