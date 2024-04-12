﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TylorTrubPortfolio.DTO
{
    public class Game
    {
        [Key]
        [DisplayName("Game Id")]
        public int Id { get; set; }
        public required string GameName { get; set; }
        public required string Preview { get; set; }
    }
}
