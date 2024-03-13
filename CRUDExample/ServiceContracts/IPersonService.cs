using ServiceContracts.DTO;
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

        List<PersonResponse> GetAllPersons();
    }
}
