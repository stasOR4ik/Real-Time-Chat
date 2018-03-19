using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Models
{
    public class User
    {
        [Key]
        public string Name { get; set; }
        public string Password { get ; set; }
    }
}
