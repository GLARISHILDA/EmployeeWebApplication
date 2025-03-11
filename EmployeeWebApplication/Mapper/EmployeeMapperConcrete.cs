using EmployeeWebApplication.Entities;
using EmployeeWebApplication.ViewModel;

namespace EmployeeWebApplication.Mapper
{
    public class EmployeeMapperConcrete : IEmployeeMapperInterface
    {
        public IReadOnlyList<IEnumerable<EmployeeViewModel>> MapList(IEnumerable<Employee> employees)
        {
            var employeeList = new List<EmployeeViewModel>();

            foreach (var employee in employees)
            {
                employeeList.Add(new EmployeeViewModel()
                {
                    Name = employee.Name,
                    DOB = employee.DOB,
                    StartingDate = employee.StartingDate,
                    Mobile = employee.Mobile,
                    Email = employee.Email,
                    MaritalStatus = employee.MaritalStatus,
                    Gender = employee.Gender,
                    Image = employee.Image
                });
            }

            return (IReadOnlyList<IEnumerable<EmployeeViewModel>>)employeeList.OrderBy(x => x.Name).ToList();
        }
    }
}