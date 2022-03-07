using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace DataAccess.Entities
{
    public class Genere : DataObject
    {
        public Genere()
        {
            Games = new List<Game>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public List<Game> Games { get; set; }
    }
}
