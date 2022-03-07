using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Logic.Model
{
    public class GameModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CompanyId { get; set; }
        public CompanyModel Company { get; set; }

        public List<GenereModel> Generes { get; set; }
    }
}
