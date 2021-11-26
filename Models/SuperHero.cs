namespace basic_api.Models
{
    public class SuperHero
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;        
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
        public bool IsAlive { get; set; }
    }
}