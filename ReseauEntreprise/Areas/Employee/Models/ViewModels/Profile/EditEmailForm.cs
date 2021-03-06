﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Profile
{
    public class EditEmailForm
    {
        [Required]
        [MinLength(5)]
        [MaxLength(360)]
        [DataType(DataType.EmailAddress)]
        [DisplayName("New Email")]
        public String Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [MaxLength(50)]
        [DisplayName("Password")]
        public String Passwd { get; set; }
    }
}