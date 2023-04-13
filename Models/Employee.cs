using Exercise.Utilities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApp.Models
{
    [Table("TB_M_Employees")]
    [Index("Email", "PhoneNumber", IsUnique = true)]
    public class Employee
    {
        [Key]
        [Column("nik", TypeName = "varchar(5)")]
        public string Nik { get; set; } = null!;

        [Column("first_name", TypeName = "varchar(50)")]
        public string FirstName { get; set; } = null!;

        [Column("last_name", TypeName = "varchar(50)")]
        public string? LastName { get; set; }

        [Column("birthdate", TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [Column("gender", TypeName = "int")]
        public EnumGender Gender { get; set; }

        [Column("hiring_date", TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime HiringDate { get; set; }

        [Column("email", TypeName = "varchar(50)")] 
        public string Email { get; set; } = null!;

        [Column("phone", TypeName = "varchar(20)")] 
        public string PhoneNumber { get; set; } = null!;

        public Account? Accounts { get; set; }
        
        public Profilling? Profillings { get; set; }

    }
}
