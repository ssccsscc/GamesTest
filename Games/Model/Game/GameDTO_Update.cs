using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Games.Model
{
    public class GameDTO_Update : GameDTO
    {
        private new CompanyDTO Company { get; set; }
        private new List<GenereDTO> Generes { get; set; }
        [Required]
        public int CompanyId { get; set; }
    }
}
