using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ef6CodeFirst.Entities;
using Ef6CodeFirst.Entities.ManyToMany;
using Ef6CodeFirst.Entities.OneToMany;
using Ef6CodeFirst.Entities.OneToOne;

namespace Ef6CodeFirst
{
    public class CodeFirstExamplesInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CodeFirstExamplesContext>
    {
        protected override void Seed(CodeFirstExamplesContext context)
        {
            #region .: One to Many :.

            var orders = new List<Order>()
            {
                new Order() {ClientCode = "ABC", OrderDate = DateTime.Now},
                new Order() {ClientCode = "XYZ", OrderDate = DateTime.Now}
            };

            orders.ForEach(s => context.Orders.Add(s));
            context.SaveChanges();
            
            var lineItems = new List<LineItem>()
            {
                //new LineItem() { ItemCode = "10", Price = 9.99m, Quantity = 1, Order = orders[0]}, // with Order navigation property
                //new LineItem() { ItemCode = "11", Price = 19.99m, Quantity = 2, Order = orders[0]}, // with Order navigation property
                //new LineItem() { ItemCode = "20", Price = 100.00m, Quantity = 1, Order = orders[1]} // with Order navigation property
                new LineItem() { ItemCode = "10", Price = 9.99m, Quantity = 1, ParentOrderId = orders[0].OrderId, LastUpdated = DateTime.Now}, // with OrderId foreign key property
                new LineItem() { ItemCode = "11", Price = 19.99m, Quantity = 2, ParentOrderId = orders[0].OrderId, LastUpdated = DateTime.Now}, // with OrderId foreign key property
                new LineItem() { ItemCode = "20", Price = 100.00m, Quantity = 1, ParentOrderId = orders[1].OrderId, LastUpdated = DateTime.Now} // with OrderId foreign key property
            };
            lineItems.ForEach(s => context.LineItems.Add(s));
            context.SaveChanges();

            #endregion .: One to Many :.

            #region .: Many to Many :.

            var students = new List<Student>()
            {
                new Student() { Fullname = "John Smith"},
                new Student() { Fullname = "Jane Doe"},
                new Student() { Fullname = "Steve Davis"},
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var subjects = new List<Subject>()
            {
                new Subject() {Name = "English", Students = new List<Student>() {students[0], students[1]}},
                new Subject() {Name = "French", Students = new List<Student>() {students[0], students[1]}},
                new Subject() {Name = "German", Students = new List<Student>() {students[1], students[2]}}
            };
            subjects.ForEach(s => context.Subjects.Add(s));
            context.SaveChanges();

            #endregion .: Many to Many :.

            #region .: One to One :.

            var people = new List<Person>()
            {
                new Person() {Fullname = "John Smith"},
                new Person() {Fullname = "Jane Doe"},
                new Person() {Fullname = "Steve Davis"}
            };

            people.ForEach(s => context.People.Add(s));
            context.SaveChanges();

            var contactDetails = new List<ContactDetails>()
            {
                new ContactDetails() {PhoneNumber = "666777888", Person = people[0]},
                new ContactDetails() {PhoneNumber = "666111222", Person = people[1]},
                new ContactDetails() {PhoneNumber = "666555666", Person = people[2]}
            };

            contactDetails.ForEach(s => context.ContactDetails.Add(s));
            context.SaveChanges();

            #endregion .: One to One :.
        }
    }
}
