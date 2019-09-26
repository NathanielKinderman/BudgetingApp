using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BudgetingApp.Models
{
    public class MadeActivites
    {
        [Key]
        [Display(Name = "Whats the Name of Activity?")]
        public string NameOfActivity { get; set; }
        [Display(Name = "What is the Address of this Activity?")]
        public string LocationOfActivity { get; set; }
        [Display(Name = "What Time is the Activity happening?")]
        public string TimeOfActivity { get; set; }
        [Display(Name = "How many people do you plan on going to this event?")]
        public string HowManyMembersInvolved { get; set; }
        [Display(Name = "How much do you think this Activity is going to cost?")]
        public string EstimatedCostOfActivity { get; set; }

        [ForeignKey("Planner")]
        [Display(Name = "PlannerID")]
        public string PlannerId { get; set; }
        public Planner Planner { get; set; }

    }
}