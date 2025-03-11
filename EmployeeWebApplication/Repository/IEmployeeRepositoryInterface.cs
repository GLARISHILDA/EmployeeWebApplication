using EmployeeWebApplication.Entities;

namespace EmployeeWebApplication.Repository
{
    public interface IEmployeeRepositoryInterface : IRepository<Employee>
    {
        public Task<IEnumerable<Employee>> ListAsync();

        public Task<Employee> GetByIdAsync(Guid id);
    }
}