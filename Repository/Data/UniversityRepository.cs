using EmployeeApp.Models;
using Exercise.Context;
using Exercise.Repository.Contracts;

namespace Exercise.Repository.Data
{
    public class UniversityRepository : GeneralRepository<University, int, ManagementContext>, IUniversityRepository
    {
        public UniversityRepository(ManagementContext context) : base(context)
        {
        }
    }
}
