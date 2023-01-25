using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWeb_App.Models
{
    public class CrimeCodes
    {
        [Key]
        public int crime_code { get; set; }
        public string code_description { get; set; }

        public CrimeCodes()
        {

        }
    }
}
