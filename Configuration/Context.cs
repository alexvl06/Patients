
using Microsoft.EntityFrameworkCore;
using Patients.Model;
using Patients.Utils;

namespace Patients.Configuration
{
    public class Context : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<PatientPerson> Patients { get; set; }
        private ConnectionDB? connection;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connection.SQLString());
            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(
                person => {
                    person.ToTable("People");
                    person.HasKey(p => p.Id);
                    person.Property(p => p.Person_Type).HasDefaultValue("doctor");
                    person.Property(p => p.Firstnames).IsRequired().HasMaxLength(60);
                    person.Property(p => p.Lastnames).IsRequired().HasMaxLength(60);
                    person.Property(p => p.Birthdate).IsRequired().HasDefaultValue(DateTime.Now);
                    person.Property(p => p.Registered_At).IsRequired().HasDefaultValue(DateTime.Now);
                    person.Property(p => p.Out_Date).HasDefaultValue(null);

                });


            modelBuilder.Entity<PatientPerson>(
                patient =>
                {
                    patient.ToTable("Patients");
                    patient.HasKey(p => p.Patient.Id);

                }
                );
       
        }


    }
}
