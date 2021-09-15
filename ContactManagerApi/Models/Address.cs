/// <summary>
/// This class represents address entity
/// </summary>

namespace ContactManagerApi.Models
{
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}
