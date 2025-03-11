using EmployeeWebApplication.Dto;
using EmployeeWebApplication.Entities;
using EmployeeWebApplication.Repository;

namespace EmployeeWebApplication.Service
{
    public class EmployeeServiceConcrete : BaseService<Employee>, IEmployeeServiceInterface
    {
        private readonly EmployeeRepositoryConcrete _employeeRepository;
        private readonly IConfiguration _configuration;

        public EmployeeServiceConcrete(EmployeeRepositoryConcrete employeeRepository, IConfiguration configuration)
        {
            _employeeRepository = employeeRepository;
            _configuration = configuration;
        }

        public async Task<IEnumerable<Employee>> ListAsync()
        {
            return await _employeeRepository.ListAsync();
        }

        public async Task<bool> AddAsync(AddEmployeeRequestDto requestDto)
        {
            var result = false;
            try
            {
                var newEmployee = new Employee()
                {
                    Id = new Guid(),
                    Name = requestDto.Name,
                    DOB = requestDto.DOB,
                    StartingDate = requestDto.StartingDate,
                    Gender = requestDto.Gender,
                    Mobile = requestDto.Mobile,
                    Email = requestDto.Email,
                    MaritalStatus = requestDto.MaritalStatus
                };

                await _employeeRepository.AddAsync(newEmployee);
                await _employeeRepository.CommitAsync();

                result = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }

        public async Task<Employee> GetByIdAsync(Guid id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(UpdateEmployeeRequestDto requestDto, Employee updateEmployee)
        {
            var result = false;
            try
            {
                updateEmployee.Name = requestDto.Name;
                updateEmployee.DOB = requestDto.DOB;
                updateEmployee.StartingDate = requestDto.StartingDate;
                updateEmployee.Gender = requestDto.Gender;
                updateEmployee.Mobile = requestDto.Mobile;
                updateEmployee.Email = requestDto.Email;
                updateEmployee.MaritalStatus = requestDto.MaritalStatus;

                await _employeeRepository.UpdateAsync(updateEmployee);
                await _employeeRepository.CommitAsync();

                result = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }

        public async Task<bool> RemoveAsync(Employee removeEmployee)
        {
            var result = false;
            try
            {
                removeEmployee.IsDeleted = true;

                await _employeeRepository.DeleteAsync(removeEmployee);
                await _employeeRepository.CommitAsync();

                result = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }
    }
}