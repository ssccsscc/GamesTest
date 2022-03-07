﻿using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Logic.Model
{
    public class CompanyModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
