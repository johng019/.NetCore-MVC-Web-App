using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWeb_App.Models
{
    public class Crimes
    {
        [Key]
        public int crime_id { get; set; }

        [ForeignKey("Criminals")]
        public int criminal_id { get; set; }
        public string classification { get; set; }
        public string date_charged { get; set; }
        public string status { get; set; }
        public string hearing_date { get; set; }
        public string appeal_cut_date { get; set; }
        public string date_recorded { get; set; }

        public Crimes()
        {

        }
    }
}
