using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ef6CodeFirst.Entities.OneToOne
{
    public class ContactDetails
    {
        public int PersonId { get; set; }
        public string PhoneNumber { get; set; }
        public Person Person { get; set; }
    }
}
