using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    /// <summary>
    /// This class acts as a custom attribute. Like [Required], this inherits ValidationAttribute and allows
    /// us to override different methods. Overriding IsValid let's us return a new result after performing logic.
    /// In this case, we are calculating the Customer's age and returning a Success or custom message.
    /// </summary>
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if(customer.Birthday == null)
                return new ValidationResult("Birthday is required.");

            var age = DateTime.Today.Year - customer.Birthday.Value.Year;
            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 years old to start a membership.");
        }
    }
}