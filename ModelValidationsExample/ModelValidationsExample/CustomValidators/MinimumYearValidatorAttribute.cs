using System.ComponentModel.DataAnnotations;

namespace ModelValidationsExample.CustomValidators
{
    public class MinimumYearValidatorAttribute:ValidationAttribute
    {
        public int MinimunYear { get; set; } = 2000;

        public string DefaultErrorMessage { get; set; } = "year must be less than {0}";

        public MinimumYearValidatorAttribute() { }

        public MinimumYearValidatorAttribute(int minimunYear)
        {
            MinimunYear = minimunYear;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;
                if (date.Year >= MinimunYear)
                {
                    return new ValidationResult(String.Format(ErrorMessage ?? DefaultErrorMessage,MinimunYear));
                }

                else
                {
                    return ValidationResult.Success;
                }
            }

            return null;
        }
    }
}
