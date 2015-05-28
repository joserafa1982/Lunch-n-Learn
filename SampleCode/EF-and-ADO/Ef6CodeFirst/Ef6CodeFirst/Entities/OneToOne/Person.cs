using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ef6CodeFirst.Entities.OneToOne
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Fullname { get; set; }
        public ContactDetails Contact { get; set; }
    }
}
