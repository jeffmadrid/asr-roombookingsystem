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
                if(9 <= _date.Hour && _date.Hour <= 13)
                {
                    if (_date.Minute == 0)
                        return ValidationResult.Success;
                    return new ValidationResult("We only run on exact o'clock times (:00).");
                }
                return new ValidationResult("During business hours of 9am-2pm only.");
            }
            return new ValidationResult(ErrorMessage);
        }
    }
}
