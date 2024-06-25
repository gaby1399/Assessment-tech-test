using BusinessLogic.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository
{
    internal interface IRepositoryImage
    {
        string GetImage(int id);
    }
}
