using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDTests
{
    public class PersonsServiceTests
    {
        private readonly IPersonService _personsService;

        public PersonsServiceTests()
        {
            _personsService = new PersonsService();
        }

        #region AddPerson

        //When we supply null value to PersonAddRequest, it should return ArgumentNullException
        [Fact]
        public void AddPerson_ArgumentNull()
        {
            //Arrange
            PersonAddRequest? request = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //act
                _personsService.AddPerson(request);
            });
        }

        //When we supply PersonName as Null, It should throw Argument Exception
        [Fact]
        public void AddPerson_PersonNameIsNull()
        {
            //Arrange
            PersonAddRequest? request = new PersonAddRequest() { PersonName=null};

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //act
                _personsService.AddPerson(request);
            });
        }

        //When we add proper Person detail to PersonAddRequest, it shoud add to the list of persons and generate new PersonID
        [Fact]
        public void AddPerson_ProperPersonDetails ()
        {
            //Arrange
            PersonAddRequest? request = new PersonAddRequest() { PersonName = "Vinay", Address="Gujarat", CountryID=Guid.NewGuid(), DateOfBirth=DateTime.Parse("2002-01-01"), Email="test@gmail.com", Gender=ServiceContracts.Enums.GenderOptions.Male, ReciveNewsLetters=true };

            //act
               PersonResponse? response =  _personsService.AddPerson(request);
               List<PersonResponse>? responseList = _personsService.GetAllPersons();

            //Assert
            Assert.True(response?.PersonID != Guid.Empty);
            Assert.Contains(response, responseList);
            
        }
        #endregion

    }
}
