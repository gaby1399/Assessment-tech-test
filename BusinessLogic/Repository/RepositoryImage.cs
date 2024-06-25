using BusinessLogic.Logic;
using DataAccess.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository
{
    internal class RepositoryImage : IRepositoryImage
    {
        public string GetImage(int id)
        {
            ImageDB img = new ImageDB();
            return img.getImagen(id);

        }
    }
}
