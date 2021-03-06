﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using C = Model.Client.Data; 

namespace ReseauEntreprise.Areas.Admin.Models.ViewModels.Event
{
    public class ListForm
    {
        [Key]
        [Display(Name = "Event Id")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Event Name")]
        public String Name { get; set; }
        [Required]
        [Display(Name = "Description")]
        public String Description { get; set; }
        [Required]
        [Display(Name = "Department Id")]
        public int? DepartmentId { get; set; }
        [Required]
        [Display(Name = "Address")]
        public String Address { get; set; }
        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Required]
        [Display(Name = "Open Subscription")]
        public bool OpenSubscription { get; set; }
        [Display(Name = "Subscribed")]
        public DateTime? Subscribed { get; set; }
        public C.Department Department { get; set; } 
    }
}