using EmployeeApp.Models;
using Exercise.Context;
using Exercise.Repository.Contracts;

namespace Exercise.Repository.Data
{
    public class ProfilingRepository : GeneralRepository<Profilling, string, ManagementContext>, IProfilingReopsitory
    {
        public ProfilingRepository(ManagementContext context) : base(context)
        {
        }
    }
}
