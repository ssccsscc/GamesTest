using Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Games
{
    /// <summary>
    /// Api error details
    /// </summary>
    public class ApiError
    {    /// <summary>
         /// Problem description
         /// </summary>
        public string title { get; set; }
        /// <summary>
        /// Status (400, 404, 500)
        /// </summary>
        public int status { get; set; }
    }
}
