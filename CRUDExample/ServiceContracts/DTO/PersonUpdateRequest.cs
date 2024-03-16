using Entities;
using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class PersonUpdateRequest
    {
        [Required(ErrorMessage ="It can't be blank")]
        public Guid PersonID { get; set; }

        [Required(ErrorMessage = "Person Name can't be blank")]
        public string? PersonName { get; set; }

        [Required(ErrorMessage = "Email can't be blank")]
        [EmailAddress(ErrorMessage = "Email should be a valid email address")]
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public GenderOptions? Gender { get; set; }
        public Guid? CountryID { get; set; }
        public string? Address { get; set; }
        public bool ReciveNewsLetters { get; set; }

        public Person ToPerson()
        {
            return new Person { PersonName = PersonName, Email = Email, DateOfBirth = DateOfBirth, Gender = Gender.ToString(), CountryID = CountryID, Address = Address, ReciveNewsLetters = ReciveNewsLetters };
        }

        public PersonUpdateRequest ToPersonUpdateRequest()
        {
            return new PersonUpdateRequest() { PersonName = PersonName, Email = Email, DateOfBirth = DateOfBirth, CountryID = CountryID, Address = Address, Gender = Gender, ReciveNewsLetters = ReciveNewsLetters };
        }
    }
}
