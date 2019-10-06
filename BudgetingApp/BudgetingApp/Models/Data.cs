using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BudgetingApp.Models
{
    public class Data
    {
        [Key]
        public int id { get; set; }
        public double cost { get; set; }
        public string activitesName { get; set; }

        [ForeignKey("MadeActivites")]
        [Display(Name = "MadeActivitesId")]
        public int MadeActivitesId { get; set; }
        public MadeActivites MadeActivites { get; set; }
    }
}