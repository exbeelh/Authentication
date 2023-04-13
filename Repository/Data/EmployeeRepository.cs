using EmployeeApp.Models;
using Exercise.Context;
using Exercise.Repository.Contracts;

namespace Exercise.Repository.Data
{
    public class EmployeeRepository : GeneralRepository<Employee, string, ManagementContext>, IEmployeeReopsitory
    {
        public EmployeeRepository(ManagementContext context) : base(context)
        {
        }
    }
}
