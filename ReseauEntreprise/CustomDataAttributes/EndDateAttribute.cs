using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReseauEntreprise.CustomDataAttributes
{
    public class EndDateAttribute : ValidationAttribute
    {
        public string StartDateName { get; set; }

        public EndDateAttribute(string startDateName)
        {
            StartDateName = startDateName;
            ErrorMessage = "The end date cannot be before the start date";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                object Model = validationContext.ObjectInstance;
                object StartDate = Model.GetType().GetProperty(StartDateName).GetValue(Model, null);
                if (StartDate != null && DateTime.Compare((DateTime)value, (DateTime)StartDate) < 0)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return null;
        }
    }
}