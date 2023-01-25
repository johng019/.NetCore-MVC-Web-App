using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWeb_App.Models
{
    public class ProbationOfficers
    {
        [Key]
        public int prob_id { get; set; }
        public string last { get; set; }
        public string first { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string status { get; set; }
        public  string mgr_id { get; set; }
        public string pager_num { get; set; }

        public ProbationOfficers()
        {

        }
    }
}
