using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApp.Models
{
    [Table("TB_M_Accounts")]
    public class Account
    {
        // Property
        [Key]
        [Column("employee_nik", TypeName = "varchar(5)")]
        public string Nik { get; set; } = null!;

        [Column("password", TypeName = "varchar(255)")]
        public string Password { get; set; } = null!;

        // Cardinality
        public Employee? Employees { get; set; }

        public ICollection<AccountRole>? AccountRoles { get; set; }

    }
}
