using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelValidationsExample.CustomValidators
{
    public class DateRangeValidatorAttribut: ValidationAttribute
    {
        public string? OtherPropertyName { get; set; }
        public DateRangeValidatorAttribut(string? otherPropertyName)
        {
            OtherPropertyName = otherPropertyName;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                DateTime toDate = Convert.ToDateTime(value);

                if(OtherPropertyName != null)
                {
                    PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName);

                    if(otherProperty != null)
                    {
                        DateTime fromDate = Convert.ToDateTime(otherProperty.GetValue(validationContext.ObjectInstance));

                        if (fromDate>toDate)
                        {
                            return new ValidationResult(ErrorMessage, new string[] { OtherPropertyName, validationContext.MemberName });
                        }
                    }

                    return null;
                }
                
                return null;

            }
            
            return null;

        }
    }
}
