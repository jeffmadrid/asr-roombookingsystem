using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asr
{
    public class CheckDate : ValidationAttribute

    {   // get code for asp.net forums by sudip_inn
        protected override ValidationResult IsValid(object o, ValidationContext validationContext)
        {
            DateTime _date = Convert.ToDateTime(o);
            if (_date >= DateTime.Now)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage);
            }
        }
    }
}
