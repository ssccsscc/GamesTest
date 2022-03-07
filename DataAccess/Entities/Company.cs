using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace DataAccess.Entities
{
    public class Company : DataObject
    {
        [Required]
        public string Name { get; set; }
    }
}
