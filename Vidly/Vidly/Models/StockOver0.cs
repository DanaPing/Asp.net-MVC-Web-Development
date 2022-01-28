using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class StockOver0 : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
        
          
            return (movie.NumberInStock >= 1)?ValidationResult.Success : new ValidationResult("Number of stock should be over 0");
            
      
            
        }
        
    }
}