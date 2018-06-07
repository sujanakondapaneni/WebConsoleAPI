using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebConsoleAPI.Models
{
    public class ConsoleModel
    {
        [Key]
        public int MessageId { get; set; }
        public string consoleMessage { get; set; }
    }
}