
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWeb_App.Models
{
    public class Sentences
    {
        [Key] 
        public int sentence_id { get; set; }

        [ForeignKey("Criminals")]
        public int criminal_id { get; set; }
        public string type { get; set; }

        [ForeignKey("ProbationOfficers")]
        public int prob_id { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string violations { get; set; }

        public Sentences()
        {

        }
    }
}
