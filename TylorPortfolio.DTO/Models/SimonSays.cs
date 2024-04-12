﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TylorTrubPortfolio.DTO
{
    public class SimonSays
    {        
        public SimonSays()
        {
        }

        [Key]
        [DisplayName("Session Id")]
        public int Id { get; set; }

        public string currentColor = "";
    }
}
