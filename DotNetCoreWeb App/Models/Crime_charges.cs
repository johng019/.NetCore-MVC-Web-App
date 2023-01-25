using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWeb_App.Models
{
    public class Crime_charges
    {
        [Key]
        public int charge_id { get; set; }
        [ForeignKey("Crimes")]
        public  int crime_id { get; set; }
        [ForeignKey("CrimeCodes")]
        public int crime_code { get; set; }
        public string charge_status { get; set; }
        public string fine_amount { get; set; }
        public string court_fee { get; set; }
        public string amount_paid { get; set; }
        public string pay_due_date { get; set; }

        public Crime_charges()
        {

        }
    }
}
