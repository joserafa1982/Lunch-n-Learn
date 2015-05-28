using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ef6CodeFirst.Entities.ManyToMany
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
