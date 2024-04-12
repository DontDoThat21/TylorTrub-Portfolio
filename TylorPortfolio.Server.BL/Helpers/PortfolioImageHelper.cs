using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TylorTrubPortfolio.DataAccess.Helpers
{
    public class PortfolioImageHelper
    {

        public static byte[] GetImageBytesFromResources(string folderRoot, string fileName)
        {

            string projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase))));
            string wwwRootPath = projectPath.Replace("file:\\", "") + "\\wwwroot\\images";

            string filePath = $"{wwwRootPath}\\{folderRoot}\\{fileName}";
            byte[] imageBytes = File.ReadAllBytes(filePath);
            return imageBytes;
        }
    }
}
