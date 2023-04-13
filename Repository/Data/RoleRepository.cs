using EmployeeApp.Models;
using Exercise.Context;
using Exercise.Repository.Contracts;

namespace Exercise.Repository.Data
{
    public class RoleRepository : GeneralRepository<Role, int, ManagementContext>, IRoleRepository
    {
        public RoleRepository(ManagementContext context) : base(context)
        {
        }
    }
}
