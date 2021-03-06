﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Profile
{
    public class EditPassForm
    {
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(50)]
        [DisplayName("Old Password")]
        public String OldPass { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(50)]
        [DisplayName("New Password")]
        public String NewPass { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(NewPass))]
        [DisplayName("Confirm Password")]
        public String Confirm { get; set; }
    }
}