using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TylorTrubPortfolio.DataAccess.Helpers
{
    public class PorfolioImageHelper
    {
        public static byte[] GetImageBytesFromResources(string fileName)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", fileName);
            byte[] imageBytes = File.ReadAllBytes(path);
            return imageBytes;
        }
    }
}
