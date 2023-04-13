using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApp.Models
{
    [Table("TB_TR_Profilings")]
    public class Profilling
    {
        [Key]
        [Column("employee_nik", TypeName = "varchar(5)")]
        public string EmployeeNik { get; set; } = null!;

        [Column("education_id", TypeName = "int")]
        public int EducationId { get; set; }

        public Employee? Employee { get; set; }

        public Education? Education { get; set; }
    }
}
