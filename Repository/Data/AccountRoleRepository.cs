using EmployeeApp.Models;
using Exercise.Context;
using Exercise.Repository.Contracts;

namespace Exercise.Repository.Data
{
    public class AccountRoleRepository : GeneralRepository<AccountRole, int, ManagementContext>, IAccountRoleRepository
    {
        public AccountRoleRepository(ManagementContext context) : base(context)
        {
        }
    }
}
