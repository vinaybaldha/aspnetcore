using ServiceContracts;
using ServiceContracts.DTO;
using Services;

namespace CRUDTests
{
    public class CountriesServiceTests
    {
        private readonly ICountriesService _countriesService;

        public CountriesServiceTests()
        {
            _countriesService = new CountriesService();
        }

        #region AddCountry
        [Fact]
        //When CountryAddRequest is null, it should throw ArgumentNullException
        public void AddCountry_NullCountry()
        {
            //Arrange
            CountryAddRequest? request = null;
            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Act
                _countriesService.AddCountry(request);
            });


        }

        //When the CountryName is null, it should throw ArgumentException
        [Fact]
        public void AddCountry_CountryNameIsNull()
        {
            //Arrange
            CountryAddRequest? request = new CountryAddRequest() { CountryName = null };
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _countriesService.AddCountry(request);
            });


        }

        //When CountryName is duplicate, it should throw ArgumentException
        [Fact]
        public void AddCountry_DublicateCountryName()
        {
            //Arrange
            CountryAddRequest? request1 = new CountryAddRequest() { CountryName = "India" };
            CountryAddRequest? request2 = new CountryAddRequest() { CountryName = "India" };
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _countriesService.AddCountry(request1);
                _countriesService.AddCountry(request2);
            });


        }
        //When you supply proper country name, it should insert(add) the country to the existing list of countries
        [Fact]
        public void AddCountry_ProperCountryDetails()
        {
            //Arrange
            CountryAddRequest? request = new CountryAddRequest() { CountryName = "India" };


            //Act
            CountryResponse response = _countriesService.AddCountry(request);

            //Assert
            Assert.True(response.CountryID != Guid.Empty);



        }
        #endregion

        #region GetAllCountries
        [Fact]

        //this method test EmptyList GetAllCountries method
        public void GetAllCountries_EmptyList()
        {
            //arrange
            List<CountryResponse> response = _countriesService.GetAllCountries();
            //act

            //assert
            Assert.Empty(response);
        }

        //this method test for Adding few Countries for GetAllCountries
        [Fact]
        public void GetAllCountries_AddFewCountries()
        {
            //arrange
            List<CountryAddRequest> countryAddRequests = new List<CountryAddRequest>()
            {
                new CountryAddRequest() { CountryName="India"},
                new CountryAddRequest() { CountryName = "America" }
            };
            //act
            List<CountryResponse> expectedResponse = new List<CountryResponse>();
            foreach (CountryAddRequest request in countryAddRequests)
            {
                expectedResponse.Add(_countriesService.AddCountry(request));
            }
            List<CountryResponse> actualResponse = _countriesService.GetAllCountries();

            //asert
            foreach (CountryResponse response in actualResponse)
            {
                Assert.Contains(response, expectedResponse);
            }
        }

        //check for proper Country details
        [Fact]
        public void GetAllCountries_ProperCountryDetails()
        {
            //arrange
            CountryAddRequest countryAddRequest = new CountryAddRequest() { CountryName = "India" };

            //act

            CountryResponse expectedResponse = _countriesService.AddCountry(countryAddRequest);
            List<CountryResponse> actualResponse = _countriesService.GetAllCountries();



            //asert
            Assert.True(expectedResponse.CountryID != Guid.Empty);
            Assert.Contains(expectedResponse, actualResponse);
        }
        #endregion

        #region GetCountryByCountryID

        //Testing If CountryID is Null
        [Fact]
        public void GetCountryByCountryID_CountryIDisNull()
        {
            //Arrange
            Guid? CountryID = null;

            //Act
            CountryResponse countryResponse = _countriesService.GetCountryByCountryID(CountryID);

            //Assert
            Assert.Null(countryResponse);
        }

        [Fact]
        //Testing to return Country based on CountryID
        public void GetCountryByCountryID_ValidCountryID()
        {
            //Arrange
            CountryAddRequest countryAddRequest = new CountryAddRequest() { CountryName = "India" };
            CountryResponse countryResponse = _countriesService.AddCountry(countryAddRequest);

            //Act
            CountryResponse countryResponse1 = _countriesService.GetCountryByCountryID(countryResponse.CountryID);

            //Asert
            Assert.Equal(countryResponse,countryResponse1);

        }

        #endregion


    }
}
