using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReferenceAndValueTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.RunValueTypeTest();

            Console.ReadLine();
        }

        #region .: Value types example :.

        public void RunValueTypeTest()
        {
            int myNumber = 1;
            Console.WriteLine("------ 1.------------");
            Console.WriteLine(myNumber);

            MakeChange(myNumber);

            Console.WriteLine("------ 3.------------");
            Console.WriteLine(myNumber);
        }

        private void MakeChange(int number)
        {
            number++;
            Console.WriteLine("------ 2.------------");
            Console.WriteLine(number);
        }

        private void MakeChange(ref int number)
        {
            number++;
            Console.WriteLine("------ 2.------------");
            Console.WriteLine(number);
        }

        #endregion .: Value types example :.

        #region .: Reference type example :.

        public void RunReferenceTypeTest()
        {
            Student student = new Student();
            student.StudentId = 1;
            student.Fullname = "John";
            Console.WriteLine("------ 1.------------");
            Console.WriteLine(student.StudentId);
            Console.WriteLine(student.Fullname);

            MakeChange(student);

            Console.WriteLine("------ 3.------------");
            Console.WriteLine(student.StudentId);
            Console.WriteLine(student.Fullname);
        }

        private void MakeChange(Student student)
        {
            student.StudentId = 2;
            student.Fullname = "Jane";
            Console.WriteLine("------ 2.------------");
            Console.WriteLine(student.StudentId);
            Console.WriteLine(student.Fullname);
        }

        private void MakeChange(ref Student student)
        {
            student.StudentId = 2;
            student.Fullname = "Jane";
            Console.WriteLine("------ 2.------------");
            Console.WriteLine(student.StudentId);
            Console.WriteLine(student.Fullname);
        }

        
        #endregion .: Value types example :.

        #region .: Reference type example set to null :.

        public void RunReferenceTypeSetToNullTest()
        {
            Student student = new Student();
            student.StudentId = 1;
            student.Fullname = "John";
            Console.WriteLine("------ 1.------------");
            Console.WriteLine(student.StudentId);
            Console.WriteLine(student.Fullname);

            SetToNull(student);

            Console.WriteLine("------ 3.------------");
            Console.WriteLine(student.StudentId);
            Console.WriteLine(student.Fullname);
        }

        private void SetToNull(Student student)
        {
            student = null;
            Console.WriteLine("------ 2.------------");
        }

        private void SetToNull(ref Student student)
        {
            student = null;
            Console.WriteLine("------ 2.------------");
        }


        #endregion .: Value types example :.

        #region .: Reference type List example :.

        public void RunReferenceTypeListTest()
        {
            List<int> myList = new List<int>();
            myList.Add(10);
            Console.WriteLine("------ 1.------------");
            foreach(var value in myList)
                Console.WriteLine(value);

            MakeChange(myList);

            Console.WriteLine("------ 3.------------");
            foreach (var value in myList)
                Console.WriteLine(value);
        }

        private void MakeChange(List<int> myList)
        {
            myList.Add(20);
            Console.WriteLine("------ 2.------------");
            foreach (var value in myList)
                Console.WriteLine(value);
        }

        private void MakeChange(ref List<int> myList)
        {
            myList.Add(20);
            Console.WriteLine("------ 2.------------");
            foreach (var value in myList)
                Console.WriteLine(value);
        }
        
        #endregion .: Value types example :.

        #region .: Reference type List Shallow Copy example :.

        public void RunReferenceTypeListShallowCopyTest()
        {
            List<int> myList = new List<int>();
            myList.Add(10);
            Console.WriteLine("------ 1.------------");
            foreach (var value in myList)
                Console.WriteLine(value);

            MakeShallowCopyAndModify(myList);

            Console.WriteLine("------ 3.------------");
            foreach (var value in myList)
                Console.WriteLine(value);
        }

        private void MakeShallowCopyAndModify(List<int> myList)
        {
            var myCopy = new List<int>(myList);
            myCopy.Add(20);
            Console.WriteLine("------ 2.------------");
            foreach (var value in myCopy)
                Console.WriteLine(value);
        }

        
        #endregion .: Value types example :.

        #region .: Reference type List Shallow Copy with common data example :.

        public void RunReferenceTypeListShallowCopyAndModifyCommonValueTest()
        {
            List<Student> myList = new List<Student>();
            myList.Add(new Student() { Fullname = "John", StudentId = 1 });
            Console.WriteLine("------ 1.------------");
            foreach (var student in myList)
                Console.WriteLine(student.Fullname + " " + student.StudentId);

            MakeShallowCopyAndModifyCommonValue(myList);

            Console.WriteLine("------ 3.------------");
            foreach (var student in myList)
                Console.WriteLine(student.Fullname + " " + student.StudentId);
        }

        private void MakeShallowCopyAndModifyCommonValue(List<Student> myList)
        {
            var myCopy = new List<Student>(myList);
            myCopy.Add(new Student() { Fullname = "Steve", StudentId = 3});
            myCopy.First(x => x.StudentId == 1).Fullname = "Jonathan";
            
            Console.WriteLine("------ 2.------------");
            foreach (var student in myList)
                Console.WriteLine(student.Fullname + " " + student.StudentId);
        }


        #endregion .: Value types example :.

        #region .: Reference type List Where example :.

        public void RunReferenceTypeListWhereTest()
        {
            List<int> myList = new List<int>();
            myList.Add(5);
            myList.Add(10);
            myList.Add(15);
            Console.WriteLine("------ 1.------------");
            foreach (var value in myList)
                Console.WriteLine(value);

            PerformWhereAndModify(myList);

            Console.WriteLine("------ 3.------------");
            foreach (var value in myList)
                Console.WriteLine(value);
        }

        private void PerformWhereAndModify(List<int> myList)
        {
            var subsetList = myList.Where(x => x <= 10).ToList();
            subsetList.Add(20);
            Console.WriteLine("------ 2.------------");
            foreach (var value in subsetList)
                Console.WriteLine(value);
        }


        #endregion .: Value types example :.

        #region .: String immutability example :.

        public void RunStringImmutabilityTest()
        {
            string name = "John";
            Console.WriteLine(name);

            MakeChange(name);

            Console.WriteLine(name);
        }

        private void MakeChange(string name)
        {
            name = "Jane";
            Console.WriteLine(name);
        }

        private void MakeChange(ref string name)
        {
            name = "Jane";
            Console.WriteLine(name);
        }

        #endregion .: Value types example :.
    }
}
