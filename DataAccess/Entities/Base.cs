using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace DataAccess.Entities
{
    public abstract class DataObject
    {
        [Key]
        public int Id { get; set; }
    }
}
