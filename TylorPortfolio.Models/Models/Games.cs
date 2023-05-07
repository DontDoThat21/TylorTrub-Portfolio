using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TylorTrubPortfolio.Models.Models
{
    public class Games
    {
        [Key]
        public int Id { get; set; }
        public required string GameName { get; set; }
        public required string Preview { get; set; }
    }
}
