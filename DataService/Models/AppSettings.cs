namespace Petbase.DataService.Models
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }
        public string PetFinderApiKey { get; set; }
        public string PetFinderApiSecret { get; set; }
        public string PetFinderAuthority { get; set; }
        public string PetFinderAnimalUrl { get; set; }
        public string PetFinderBaseUrl { get; set; }
    }
}
