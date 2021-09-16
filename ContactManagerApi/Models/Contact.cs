/// <summary>
/// This class represents the Contact entity
/// </summary>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactManagerApi.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public Name name { get; set; }
        public Address address { get; set; } 
        public List<Phone> phone { get; set; } = new List<Phone>(); 
        public string Email { get; set; }
    }
}
