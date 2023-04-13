using EmployeeApp.Models;
using Exercise.ViewModels;

namespace Exercise.Repository.Contracts
{
    public interface IAccountRepository : IGeneralRepository<Account, string>
    {
        int Register(RegisterVM registerVM);
        int RegisterAdmin(RegisterVM registerVM);
        int RegisterUser(RegisterVM registerVM);
    }
}
