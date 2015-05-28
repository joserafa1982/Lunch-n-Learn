using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Ef6CodeFirst.Entities;
using Ef6CodeFirst.Entities.ManyToMany;
using Ef6CodeFirst.Entities.OneToMany;
using Ef6CodeFirst.Entities.OneToOne;

namespace Ef6CodeFirst
{
    public class CodeFirstExamplesContext : DbContext
    {
        // One to Many
        public DbSet<Order> Orders { get; set; }
        public DbSet<LineItem> LineItems { get; set; }

        // Many to Many
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        // One to One
        public DbSet<Person> People { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }

        public CodeFirstExamplesContext()
            : base("CodeFirstExamplesContext")
        {
            
        }

        
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region .: One to One :.

            modelBuilder.Entity<LineItem>().Property(x => x.LastUpdated).IsConcurrencyToken();

            modelBuilder.Entity<LineItem>()
                .HasRequired(x => x.Order)
                .WithMany(x => x.LineItems)
                .HasForeignKey(x => x.ParentOrderId);

            modelBuilder.Entity<LineItem>().Ignore(x => x.Quantity);

            modelBuilder.Entity<LineItem>().ToTable("Purchasing.LineItems");
            modelBuilder.Entity<Order>().ToTable("Purchasing.Orders");

            modelBuilder.Entity<ContactDetails>().HasKey(x => x.PersonId);

            //// Person has an optional ContactDetails
            //modelBuilder.Entity<ContactDetails>()
            //    .HasRequired(x => x.Person)
            //    .WithOptional(x => x.Contact);

            // Person must have a ContactDetails
            modelBuilder.Entity<ContactDetails>()
                .HasRequired(x => x.Person)
                .WithRequiredDependent(x => x.Contact);

            #endregion .: One to One :.

            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
