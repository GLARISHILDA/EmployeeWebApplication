using EmployeeWebApplication.Entities;
using EmployeeWebApplication.ViewModel;

namespace EmployeeWebApplication.Mapper
{
    public interface IEmployeeMapperInterface : IMapper
    {
        public IReadOnlyList<IEnumerable<EmployeeViewModel>> MapList(IEnumerable<Employee> employee);
    }

    public interface IMapper
    {
    }
}