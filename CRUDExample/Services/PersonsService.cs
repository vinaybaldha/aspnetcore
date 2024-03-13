using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

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

            Person person = personAddRequest.ToPerson();
            person.PersonID=Guid.NewGuid();
            _persons.Add(person);
            return ConvertPersonToPersonResponse(person);
        }

        public List<PersonResponse> GetAllPersons()
        {
            throw new NotImplementedException();
        }
    }
}
