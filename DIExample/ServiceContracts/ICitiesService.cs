namespace ServiceContracts
{
    public interface ICitiesService
    {
        public Guid Id { get; }
        List<string> GetCities();
    }
}
