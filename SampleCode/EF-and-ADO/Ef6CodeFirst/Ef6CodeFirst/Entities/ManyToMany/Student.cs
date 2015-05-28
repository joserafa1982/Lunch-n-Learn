using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ef6CodeFirst.Entities.ManyToMany
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Fullname { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }
}
