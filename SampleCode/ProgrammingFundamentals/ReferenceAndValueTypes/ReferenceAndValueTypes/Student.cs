using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ReferenceAndValueTypes
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public string Name { get; set; }
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string Fullname { get; set; }
        List<Lesson> LessonsAttending { get; set; }
    }
}
