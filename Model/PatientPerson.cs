using System.ComponentModel.DataAnnotations.Schema;

namespace Patients.Model
{
    public class PatientPerson 
    { 
        public Person Patient { get; set; }
        public Person? Doctor { get; set; }
        public string? EPS { get; set; }
        public string? ARL { get; set; }
        public  string? Condition { get; set; }

    }
}
