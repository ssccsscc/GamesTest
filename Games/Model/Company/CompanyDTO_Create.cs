using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Games.Model
{
    public class CompanyDTO_Create : CompanyDTO
    {
        private new int Id { get; set; }
    }
}
