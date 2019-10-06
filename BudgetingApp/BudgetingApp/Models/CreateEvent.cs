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
        public string id { get; set; }
        [Display(Name = "What is the Name of the Event you are creating?")]
        public string EventsName { get; set; }
        [Display(Name ="What city do you want to host this Event?")]
        public string City { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name = "What is the date of this event")]        
        public string DateOfEvent { get; set; }
        [Display(Name ="How many people are going to be invited")]
        public double NumberOfMembers { get; set; }
        [Display(Name ="What is the total budget of this event")]

        public string TheBudgetOfEvent { get; set; }

        [ForeignKey("Planner")]
        [Display(Name = "PlannerId")]
        public int PlannerId { get; set; }
        public Planner Planner { get; set; }
    }
}