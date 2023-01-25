using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWeb_App.Models
{
    public class Officers
    {
        [Key]
        public int officer_id { get; set; }
        public string last { get; set; }
        public string first { get; set; }
        public string precinct { get; set; }
        public string badge { get; set; }
        public string phone { get; set; }
        public string status { get; set; }

        public Officers()
        {

        }
    }
}
