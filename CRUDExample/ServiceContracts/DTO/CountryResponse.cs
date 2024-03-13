using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// DTO class that is used as return type for most for country service methods
    /// </summary>
    public class CountryResponse
    {
        public Guid CountryID { get; set; }
        public string? CountryName { get; set; }

        //overrides Equals method for Testing
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (typeof(CountryResponse) != obj.GetType()) return false;
            CountryResponse countryResponse = (CountryResponse)obj;
            return CountryID == countryResponse.CountryID && CountryName == countryResponse.CountryName;
        }

        //It is required for overriding
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    public static class CountryExtension
    {
        public static CountryResponse ToCountryResponse(this Country country)
        {
            return new CountryResponse() { CountryID = country.CountryID, CountryName = country.CountryName, };
        }
    }
}
