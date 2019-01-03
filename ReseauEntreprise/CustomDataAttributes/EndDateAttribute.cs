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
            ErrorMessage = "The event cannot end before it has started";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                object Model = validationContext.ObjectInstance;
                DateTime StartDate = (DateTime)Model.GetType().GetProperty(StartDateName).GetValue(Model, null);
                if (DateTime.Compare((DateTime)value, StartDate) < 0)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return null;
        }
    }
}