using ServiceContracts;

namespace Services
{
    public class CitiesService : ICitiesService, IDisposable
    {
        private List<string> _cities;
        private Guid _id;

        public Guid Id {  get { return _id; } }

        public CitiesService()
        {
            _id = Guid.NewGuid();
            _cities = new List<string>()
            {
                "Rajkot",
                "Mahesana",
                "Goa"
            };

        }
        public List<string> GetCities()
        {
            return _cities;
        }

        public void Dispose()
        {
            
        }
    }
}
