using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApp.Models
{
    [Table("TB_M_Educations")]
    public class Education
    {
        [Key]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        [Column("major", TypeName = "varchar(100)")] 
        public string Major { get; set; } = null!;

        [Column("degree", TypeName = "varchar(10)")] 
        public string Degree { get; set; } = null!;

        [Column("gpa", TypeName = "decimal(3,2)")]
        public double GPA { get; set; }

        [Column("university_id", TypeName = "int")]
        public int UniversityId { get; set; }

        public University? Universities { get; set; }

        public Profilling? Profillings { get; set; }
    }
}
