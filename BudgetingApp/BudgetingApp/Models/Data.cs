using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetingApp.Models
{
    public class Data
    {
        [Key]
        public int id;
        public double cost;
        public string activitesName;
    }
}