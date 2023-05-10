using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TylorTrubPortfolio.Models
{
    public class SimonSays
    {
        [Key]
        [DisplayName("Session Id")]
        [DefaultValue(-1)]
        public int Id { get; set; }

        public string currentColor = "";

        public int sequenceCounter { get; set; }
    }
}
