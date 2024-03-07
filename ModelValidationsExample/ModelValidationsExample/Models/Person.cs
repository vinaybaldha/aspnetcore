using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelValidationsExample.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace ModelValidationsExample.Models
{
    public class Person :IValidatableObject
    {
        [Required(ErrorMessage = "{0} can not be null or empty.")]
        [Display(Name = "person name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} length should in between {2} to {1} charectors.")]
        [RegularExpression("[a-zA-Z]+\\.?", ErrorMessage ="{0} should contain only alphabatical,space or (.) as values.")]
        public string? Name { get; set; }

        [Required(ErrorMessage ="{0} is required.")]
        [EmailAddress(ErrorMessage ="{0} is not valid.")]
        public string? Email { get; set; }

        [Phone(ErrorMessage ="{0} is not vaid.")]
        public string? Phone { get; set; }

        [Required(ErrorMessage ="{0} is required.")]
    
        public string? Password { get; set; }

        [Required(ErrorMessage ="{0} is required.")]
        [Compare("Password",ErrorMessage ="{0} is not equal to {1}.")]
        public string? ConformPassword { get; set; }


        [Range(0,maximum:1000,ErrorMessage ="{0} should in between {1}$ to {2}$.")]
        public double? Price { get; set; }

        //[MinimumYearValidator(2050,ErrorMessage ="date must be less than {0}")]

        [MinimumYearValidator(2050)]
        [BindNever]
        public DateTime? Date {  get; set; }

        public int? Age { get; set; }


        public DateTime? FromDate { get; set; }

        [DateRangeValidatorAttribut("FromDate",ErrorMessage ="'FromDate' is greate than 'ToDate'")]
        public DateTime? ToDate { get; set; }

        public List<string?> Tags { get; set; }=new List<string?>();

        public override string ToString()
        {
            return $"name:{Name}, email:{Email}, phone: {Phone},\n password: {Password}, confirmPassword: {ConformPassword}, price: {Price},\n Date: {Date}";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!Date.HasValue && !Age.HasValue)
            {
               yield return new ValidationResult("Either Age or Date property required.", new[] {nameof(Age)});
            }
        }
    }
}
