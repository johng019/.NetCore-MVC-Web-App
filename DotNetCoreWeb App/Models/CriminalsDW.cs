using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWeb_App.Models
{
    public class CriminalsDW
    {
        [Key]
        public int criminal_id  { get; set; }
        public string last { get; set; }
        public string first { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phone { get; set; }
        public string v_status { get; set; }
        public string p_status { get; set; }

        public CriminalsDW()
        {

        }
    }
}
