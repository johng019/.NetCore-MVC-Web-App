using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWeb_App.Models
{
    public class Aliases
    {
        [Key]
        public int alias_id { get; set; }

        [ForeignKey("Criminals")]
        public int criminal_id { get; set; }

        public string alias { get; set; }

        public Aliases()
        {

        }
    }
}
