using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Ef6CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().TestOptimisticConcurrency();
        }

        #region .: One to Many :.

        public void RunOneToMany()
        {
            using (var context = new CodeFirstExamplesContext())
            {
                var orders = context.Orders;
                foreach (var order in orders)
                    Console.WriteLine(order.ClientCode);
            }
        }

        #endregion .: One to Many :.


        #region .: Many to Many :.

        public void RunManyToMany()
        {
            using (var context = new CodeFirstExamplesContext())
            {
                var students = context.Students;
                foreach (var student in students)
                    Console.WriteLine(student.Fullname);
            }
        }
        
        #endregion .: Many to Many :.


        #region .: One to One :.

        public void RunOneToOne()
        {
            using (var context = new CodeFirstExamplesContext())
            {
                var people = context.People;
                foreach (var person in people)
                    Console.WriteLine(person.Fullname);
            }
        }

        #endregion .: One to One :.

        // at the breakpoint change the data from Management Studio
        public void TestOptimisticConcurrency()
        {
            using (var context = new CodeFirstExamplesContext())
            {
                var lineItem = context.LineItems.FirstOrDefault();

                lineItem.Price = 2000;

                context.SaveChanges();
            }
        }
    }
}
