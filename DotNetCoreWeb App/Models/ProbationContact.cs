
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWeb_App.Models
{
    public class ProbationContact
    {
       [Key]
        public int prob_cat { get; set; }
        public int low_amt { get; set; }
        public int high_amt { get; set; }
        public string con_freq { get; set; }

        public ProbationContact()
        {

        }
    }
}
