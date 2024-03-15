﻿using Entities;
using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// Act as a DTO for inserting a new person
    /// </summary>
    public class PersonAddRequest
    {
        [Required(ErrorMessage ="Person Name can't be blank")]
        public string? PersonName { get; set; }

        [Required(ErrorMessage ="Email can't be blank")]
        [EmailAddress(ErrorMessage ="Email should be a valid email address")]
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
    }
}
