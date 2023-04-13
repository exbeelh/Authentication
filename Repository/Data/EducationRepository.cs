using EmployeeApp.Models;
using Exercise.Context;
using Exercise.Repository.Contracts;

namespace Exercise.Repository.Data
{
    public class EducationRepository : GeneralRepository<Education, int, ManagementContext>, IEducationRepository
    {
        public EducationRepository(ManagementContext context) : base(context)
        {

        }
    }
}
