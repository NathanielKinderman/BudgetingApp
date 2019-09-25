﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BudgetingApp.Models
{
    public class PartyMember
    {
        [Key]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "EMail Address")]
        public string EmailAddress { get; set; }
        [Display(Name ="Personal Budget for the Event")]
        public string PersonalBudget { get; set; }

        [ForeignKey("ApplicationUser")]
        [Display(Name = "UserID")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


    }
}