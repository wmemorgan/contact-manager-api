/// <summary>
/// This class represents the contact entity
/// </summary>

using System.Collections.Generic;

namespace ContactManagerApi.Models
{
    public class Contact
    {
        public Name name;
        public Address address; 
        public List<Phone> phone = new List<Phone>(); 
        public string Email { get; set; }
    }
}
