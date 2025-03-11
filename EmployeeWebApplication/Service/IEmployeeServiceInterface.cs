using EmployeeWebApplication.Dto;
using EmployeeWebApplication.Entities;

namespace EmployeeWebApplication.Service
{
    public interface IEmployeeServiceInterface
    {
        public Task<IEnumerable<Employee>> ListAsync();

        public Task<bool> AddAsync(AddEmployeeRequestDto requestDto);

        public Task<Employee> GetByIdAsync(Guid id);

        public Task<bool> UpdateAsync(UpdateEmployeeRequestDto requestDto, Employee employee);

        public Task<bool> RemoveAsync(Employee employee);
    }
}