using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using Services.Helpers;


namespace Services
{
    public class PersonsService : IPersonService
    {
        private List<Person> _persons;
        private ICountriesService _countriesService;
        public PersonsService()
        {
            _persons = new List<Person>();
            _countriesService = new CountriesService();
        }
        private PersonResponse ConvertPersonToPersonResponse(Person person)
        {
            PersonResponse? personResponse = person.ToPersonResponse();
            personResponse.Country = _countriesService.GetCountryByCountryID(personResponse.CountryID)?.CountryName;
            return personResponse;
        }
        public PersonResponse AddPerson(PersonAddRequest? personAddRequest)
        {
            
            if (personAddRequest == null) throw new ArgumentNullException(nameof(personAddRequest));

            if(personAddRequest.PersonName==null) throw new ArgumentException(nameof(personAddRequest.PersonName));

            ValidationHelper.ModelValidation(personAddRequest);


            Person person = personAddRequest.ToPerson();
            person.PersonID=Guid.NewGuid();
            _persons.Add(person);
            return ConvertPersonToPersonResponse(person);
        }

        public List<PersonResponse> GetAllPersons()
        {
            return _persons.Select(temp => temp.ToPersonResponse()).ToList();
        }

        public PersonResponse? GetPersonByPersonID(Guid? personID)
        {
            if (personID == null) return null;
            Person? person = _persons.FirstOrDefault(temp => temp.PersonID == personID);
            if(person == null) return null;
            return person.ToPersonResponse();
        }

        public List<PersonResponse> FilterPerson(string searchBy, string? searchString)
        {
            List<PersonResponse> allPerson = GetAllPersons();
            List<PersonResponse> matchingPerson = allPerson;

            if(string.IsNullOrEmpty(searchString) || string.IsNullOrEmpty(searchBy))
            {
                return matchingPerson;
            }

            switch (searchBy)
            {
                case nameof(Person.PersonName):
                   matchingPerson= allPerson.Where(temp=> temp.PersonName != null ? temp.PersonName.Contains(searchBy, StringComparison.OrdinalIgnoreCase):true).ToList();
                    return matchingPerson;
                   

                case nameof(Person.Address):
                    matchingPerson = allPerson.Where(temp => temp.Address != null ? temp.Address.Contains(searchBy, StringComparison.OrdinalIgnoreCase) : true).ToList();
                    return matchingPerson;
                   
                case nameof(Person.Gender):
                    matchingPerson = allPerson.Where(temp => temp.Gender != null ? temp.Gender.Contains(searchBy, StringComparison.OrdinalIgnoreCase) : true).ToList();
                    return matchingPerson;
                   
                case nameof(Person.DateOfBirth):
                    matchingPerson = allPerson.Where(temp => temp.DateOfBirth != null ? temp.DateOfBirth.Value.ToString("dd MM yyyy").Contains(searchBy, StringComparison.OrdinalIgnoreCase) : true).ToList();
                    return matchingPerson;

                case nameof(Person.Email):
                    matchingPerson = allPerson.Where(temp => temp.Email != null ? temp.Email.Contains(searchBy, StringComparison.OrdinalIgnoreCase) : true).ToList();
                    return matchingPerson;

                default : return matchingPerson = allPerson;
            }
        }

        public List<PersonResponse> SortedPersons(List<PersonResponse> persons, string sortBy, SortOrderOptions sortOrder)
        {
   
            if(string.IsNullOrEmpty(sortBy))
                return persons;

            List<PersonResponse> sortedPersons = (sortBy, sortOrder) switch
            {
                (nameof(PersonResponse.PersonName), SortOrderOptions.ASC)
                => persons.OrderBy(temp => temp.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.PersonName), SortOrderOptions.DESC)
                => persons.OrderByDescending(temp => temp.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Email), SortOrderOptions.ASC)
                => persons.OrderBy(temp => temp.Email, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Email), SortOrderOptions.DESC)
                => persons.OrderByDescending(temp => temp.Email, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Address), SortOrderOptions.ASC)
                => persons.OrderBy(temp => temp.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Address), SortOrderOptions.DESC)
                => persons.OrderByDescending(temp => temp.Address, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.DateOfBirth), SortOrderOptions.ASC)
                => persons.OrderBy(temp => temp.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.DateOfBirth), SortOrderOptions.DESC)
                => persons.OrderByDescending(temp => temp.DateOfBirth).ToList(),

                (nameof(PersonResponse.Age), SortOrderOptions.ASC)
                => persons.OrderBy(temp => temp.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Age), SortOrderOptions.DESC)
                => persons.OrderByDescending(temp => temp.Age).ToList(),

                (nameof(PersonResponse.Country), SortOrderOptions.ASC)
                => persons.OrderBy(temp => temp.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Country), SortOrderOptions.DESC)
                => persons.OrderByDescending(temp => temp.Country, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Gender), SortOrderOptions.ASC)
               => persons.OrderBy(temp => temp.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Gender), SortOrderOptions.DESC)
                => persons.OrderByDescending(temp => temp.Gender, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.ReciveNewsLetters), SortOrderOptions.ASC)
                => persons.OrderBy(temp => temp.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.ReciveNewsLetters), SortOrderOptions.DESC)
                => persons.OrderByDescending(temp => temp.ReciveNewsLetters).ToList(),

                _ => persons
            } ;

            return sortedPersons;
                
        }

        public PersonResponse UpdatePerson(PersonUpdateRequest? personUpdateRequest)
        {
            if(personUpdateRequest == null)
            {
                throw new ArgumentNullException(nameof(personUpdateRequest));
            }

            ValidationHelper.ModelValidation(personUpdateRequest);

            Person? matchingPerson = _persons.FirstOrDefault(temp => temp.PersonID == personUpdateRequest?.PersonID);

            if(matchingPerson == null)
            {
                throw new ArgumentException("Given personID dosen't exist");
            }

            matchingPerson.PersonName = personUpdateRequest.PersonName;
            matchingPerson.Address = personUpdateRequest.Address;
            matchingPerson.Gender = personUpdateRequest.Gender.ToString();
            matchingPerson.Email = personUpdateRequest.Email;
            matchingPerson.DateOfBirth= personUpdateRequest.DateOfBirth;
            matchingPerson.ReciveNewsLetters = personUpdateRequest.ReciveNewsLetters;
            matchingPerson.CountryID = personUpdateRequest.CountryID;
          
            return matchingPerson.ToPersonResponse();
        }

        public bool DeletePerson(Guid? personID)
        {
            if (personID == null)
            {
                throw new ArgumentNullException(nameof(personID));
            }

            Person? person = _persons.FirstOrDefault(temp => temp.PersonID == personID);

            if(person == null)
            {
                return false;
            }
            _persons.RemoveAll(temp=>temp.PersonID == personID);

            return true;
        }
    }
}
