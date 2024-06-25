using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;


namespace DataAccess.DB
{
    public class ImageDB
    {
        public string getImagen(int id) 
        {
            try
            {
          
                using (SQLiteConnection connetion =new SQLiteConnection(Conexion.cadena))
                {
                   
                    connetion.Open();
                    StringBuilder sb = new StringBuilder();
                      sb.AppendLine("SELECT url FROM images WHERE id="+id);
 
                    SQLiteCommand command = connetion.CreateCommand();
                    command.CommandText = sb.ToString();
                    return command.ExecuteScalar().ToString();

                }   
            }
            catch (SQLiteException e)
            {
                throw e;
            }
            
        }
    }
}
