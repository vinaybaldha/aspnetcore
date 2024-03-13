using Entities;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// Represent DTO class that is used to return type of most methods of person service
    /// </summary>
    public class PersonResponse
    {
        public Guid PersonID { get; set; }
        public string? PersonName { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public string? Gender { get; set; }
        public Guid? CountryID { get; set; }

        public string? Country {  get; set; }
        public string? Address { get; set; }
        public bool ReciveNewsLetters { get; set; }

        public double? Age { get; set; }

        public override bool Equals(object? obj)
        {
            if(obj == null) return false;
            if(obj.GetType() != typeof(PersonResponse)) return false; 

            PersonResponse person = (PersonResponse)obj;
            return PersonID==person.PersonID && PersonName==person.PersonName && Email==person.Email && DateOfBirth==person.DateOfBirth && Gender==person.Gender && CountryID==person.CountryID && Address==person.Address && ReciveNewsLetters==person.ReciveNewsLetters && Age==person.Age;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public static class PersonExtensions
    {
        /// <summary>
        /// An Extesion method to convert an object of Person class into PersonResponse class
        /// </summary>
        /// <param name="person">The person object to convert</param>
        /// <returns>Returns the converted PersonResponse object</returns>
        public static PersonResponse ToPersonResponse(this Person person)
        {
            return new PersonResponse() { PersonID = person.PersonID, PersonName = person.PersonName, Email = person.Email, DateOfBirth = person.DateOfBirth, Gender = person.Gender, Address = person.Address, ReciveNewsLetters = person.ReciveNewsLetters, Age = (person.DateOfBirth != null) ? Math.Round((DateTime.Now - person.DateOfBirth.Value).TotalDays / 365.25) : null };
        }
    }
}
