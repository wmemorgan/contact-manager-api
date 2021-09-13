using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagerApi.Models
{
    public class CallListContact
    {
        public Name name;

        [Display(Name = "phone")]
        public string PhoneNumber { get; set; }
    }
}
