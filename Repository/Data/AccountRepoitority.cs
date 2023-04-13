using EmployeeApp.Models;
using Exercise.Context;
using Exercise.Repository.Contracts;
using Exercise.ViewModels;
using System.Transactions;

namespace Exercise.Repository.Data
{
    public class AccountRepoitority : GeneralRepository<Account, string, ManagementContext>, IAccountRepository
    {
        public AccountRepoitority(ManagementContext context) : base(context)
        {
        }

        public int Register(RegisterVM registerVM)
        {
            using var transaction = new TransactionScope();
            try
            {
                var university = new University
                {
                    Name = registerVM.UniversityName
                };
                _context.Universities.Add(university);
                _context.SaveChanges();

                var education = new Education
                {
                    Major = registerVM.Major,
                    Degree = registerVM.Degree,
                    GPA = registerVM.GPA,
                    UniversityId = university.Id
                };
                _context.Educations.Add(education);
                _context.SaveChanges();

                var employee = new Employee
                {
                    Nik = registerVM.NIK,
                    FirstName = registerVM.FirstName,
                    LastName = registerVM.LastName,
                    BirthDate = registerVM.BirthDate,
                    Gender = registerVM.Gender,
                    HiringDate = DateTime.Now,
                    Email = registerVM.Email,
                    PhoneNumber = registerVM.PhoneNumber
                };
                _context.Employees.Add(employee);
                _context.SaveChanges();

                var account = new Account
                {
                    Nik = registerVM.NIK,
                    Password = registerVM.Password,
                };

                var role = new Role
                {
                    Name = "User"
                };
                _context.Roles.Add(role);
                _context.SaveChanges();

                var profiling = new Profilling
                {
                    EmployeeNik = registerVM.NIK,
                    EducationId = education.Id
                };

                _context.Accounts.Add(account);
                _context.SaveChanges();

                transaction.Complete();
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public int RegisterAdmin(RegisterVM registerVM)
        {
            Register(registerVM);

            var role = new Role
            {
                Name = "Admin"
            };
            _context.Roles.Add(role);
            return _context.SaveChanges();
        }

        public int RegisterUser(RegisterVM registerVM)
        {
            Register(registerVM);

            var role = new Role
            {
                Name = "User"
            };
            _context.Roles.Add(role);
            return _context.SaveChanges();
        }

    }
}
