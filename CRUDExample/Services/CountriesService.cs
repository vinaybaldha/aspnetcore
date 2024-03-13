using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
    public class CountriesService : ICountriesService
    {
        private List<Country> _countries;
        public CountriesService()
        {
            _countries = new List<Country>();
        }
        public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
        {
            //Validation: CountryAddRequest is null
            if (countryAddRequest == null)
            {
                throw new ArgumentNullException(nameof(countryAddRequest));
            }

            //Validation: CountryName is null
            if (countryAddRequest.CountryName == null)
            {
                throw new ArgumentException(nameof(countryAddRequest.CountryName));
            }

            //Validation: Dublicate country name
            if (_countries.Where(temp => temp.CountryName == countryAddRequest.CountryName).Count() > 0)
            {
                throw new ArgumentException("this country name is already added");
            }

            //convert object CountryAddRequest to Country type
            Country country = countryAddRequest.ToCountry();
            //generate countryID
            country.CountryID = Guid.NewGuid();
            //Add Country object into _countries
            _countries.Add(country);
            //convert Country object to CountryResponse type
            return country.ToCountryResponse();

        }

        //implemetation of GetAllCountries method
        public List<CountryResponse> GetAllCountries()
        {
            return _countries.Select(country => country.ToCountryResponse()).ToList();
        }

        //implementation of GetCountryByCountryID
        public CountryResponse? GetCountryByCountryID(Guid? CountryID)
        {
            if (CountryID == null) { return null; }

            Country? country = _countries.FirstOrDefault(temp => temp.CountryID == CountryID);

            if(country == null) { return null; }

            return country.ToCountryResponse();

        }
    }
}
