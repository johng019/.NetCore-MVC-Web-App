using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWeb_App.Models
{
    public class Appeals
    {
        [Key]
        public  int appeal_id { get; set; }
        [ForeignKey("Crimes")]
        public int crime_id { get; set; }
        public string filing_date  { get; set; }
        public string hearing_date { get; set; }
        public string status { get; set; }

        public Appeals()
        {

        }

    }
}
