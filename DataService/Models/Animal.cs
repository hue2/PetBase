namespace Petbase.DataService.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Photos Photos { get; set; }
        public Contact Contact { get; set; }
    }
}
