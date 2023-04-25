using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patients.Model
{
    public class Person
    {
        [Key]
        public string Id { get; set; }
        [StringLength(50)]
        public string? Firstnames { get; set; }
        [StringLength(50)]
        public string? Lastnames { get; set; }
        public DateTime Birthdate { get; set; }
        [Column("id_type")]
        public string? Id_type { get; set; }
        public string? genre { get; set; }
        [Column("registered_at")]
        public DateTime Registered_At { get; set; }
        [Column("out_date")]
        public DateTime? Out_Date { get; set; }
        public string? Address { get; set; }
        public String? Photo { get; set; }
        public string? Landline { get; set; }
        public string? Cellphone { get; set; }
        public String? Email { get; set; }
        [Column("person_type")]
        public string? Person_Type { get; set; }

        public override string ToString()
        {
            return $"" +
                $"Birthdate: {Birthdate}, " +
                $"Registered_at: {Registered_At}, " +
                $"out_date: {Out_Date}";
        }
    }
}
