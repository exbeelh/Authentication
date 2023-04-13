using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApp.Models
{
    [Table("TB_M_Account_Roles")]
    public class AccountRole
    {
        [Key]
        [Column("id", TypeName = "int")]
        public int Id { get; set; }

        [Column("account_nik", TypeName = "varchar(5)")]
        public string Nik { get; set; } = null!;

        [Column("role_id", TypeName = "int")]
        public int RoleId { get; set; }

        public Account? Accounts { get; set; }

        public Role? Roles { get; set; }
    }
}
