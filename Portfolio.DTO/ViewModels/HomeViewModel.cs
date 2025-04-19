using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio.DTO.Models;

namespace Portfolio.DTO.ViewModels
{
    public class HomeViewModel
    {
        public List<MotorcycleVideo> MotorcycleVideoList { get; set; }
        public List<PortfolioImage> PortfolioImageList { get; set; }

    }
}
