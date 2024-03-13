using ServiceContracts.DTO;

namespace ServiceContracts
{
    /// <summary>
    /// represents business logic for manipulating country entity
    /// </summary>
    public interface ICountriesService
    {
        /// <summary>
        /// add a country object to the list of countries 
        /// </summary>
        /// <param name="countryAddRequest">country object to add</param>
        /// <returns>return the country object after adding it</returns>
        CountryResponse AddCountry(CountryAddRequest? countryAddRequest);

        /// <summary>
        /// get all the list of available countries
        /// </summary>
        /// <returns>return list of all countries as CountryResponse</returns>
        List<CountryResponse> GetAllCountries();

        /// <summary>
        /// It should return Country based on given CountryID
        /// </summary>
        /// <param name="CountryID">required County's CountryID</param>
        /// <returns>return Country as CountryResponse</returns>
        CountryResponse? GetCountryByCountryID(Guid? CountryID);

    }
}
