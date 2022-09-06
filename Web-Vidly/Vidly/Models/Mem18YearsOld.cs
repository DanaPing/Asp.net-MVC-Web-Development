using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Mem18YearsOld : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if(customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            if (customer.Birthday == null)
                return new ValidationResult("Birthdate field is required");
            var age = DateTime.Today.Year - customer.Birthday.Value.Year;
            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Membership is ONLY open for 18 years old or older");
        }
    }
}