using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BudgetingApp.Models
{
    public class CreateEvent
    {
        [Key]
        [Display(Name = "What is the Name of the Event you are creating?")]
        public string EventsName { get; set; }
        [Display(Name ="What city do you want to host this Event?")]
        public string City { get; set; }
        [Display(Name = "What is the date of this event")]
        public string DateOfEvent { get; set; }
        [Display(Name ="How many people are going to be invited")]
        public string NumberOfMembers { get; set; }
        [Display(Name ="What is the total budget of this event")]

        public string TheBudgetOfEvent { get; set; }

        [ForeignKey("Planner")]
        [Display(Name = "PlannerId")]
        public string PlannerId { get; set; }
        public Planner Planner { get; set; }
    }
}