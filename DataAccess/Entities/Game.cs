using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace DataAccess.Entities
{
    public class Game : DataObject
    {
        public Game()
        {
            Generes = new List<Genere>();
        }

        [Required]
        public string Name { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        [Required]
        public virtual Company Company { get; set; }

        [Required]
        public List<Genere> Generes { get; set; }
    }
}
