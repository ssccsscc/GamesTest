using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Games.Model
{
    public class GameDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public CompanyDTO Company { get; set; }
        [Required]
        public List<GenereDTO> Generes { get; set; }
    }
}
