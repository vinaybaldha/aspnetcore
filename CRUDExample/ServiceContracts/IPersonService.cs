using ServiceContracts.DTO;
using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface IPersonService
    {
        PersonResponse? AddPerson(PersonAddRequest? person);

        List<PersonResponse>? GetAllPersons();

        PersonResponse? GetPersonByPersonID(Guid? personID);

        List<PersonResponse> FilterPerson(string searchBy, string? searchString);

        List<PersonResponse> SortedPersons(List<PersonResponse> persons, string sortBy, SortOrderOptions sortOrder);

        PersonResponse UpdatePerson(PersonUpdateRequest? personUpdateRequest);
        
        bool DeletePerson(Guid? personID);
    }
}
