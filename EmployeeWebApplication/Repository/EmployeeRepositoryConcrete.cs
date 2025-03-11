using EmployeeWebApplication.Entities;
using System.Runtime.InteropServices;

namespace EmployeeWebApplication.Repository
{
    public class EmployeeRepositoryConcrete : Repository<Employee>
    {
        private readonly DatabaseContext _context;

        public EmployeeRepositoryConcrete(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> ListAsync()
        {
            return await _context.Employee.ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(Guid id)
        {
            return await _context.Employee.FirstOrDefaultAsync(_context.Employee.Id == id);
        }
    }
}