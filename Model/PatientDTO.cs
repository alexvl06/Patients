namespace Patients.Model
{
    public class PatientDTO
    {
        public Person? Patient { get; set; }
        public string DoctorId { get; set; }
        public string? EPS { get; set; }
        public string? ARL { get; set; }
        public string? Condition { get; set; }

    }
}
