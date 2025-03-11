using EmployeeWebApplication.Entities;

namespace EmployeeWebApplication.DatabaseContext
{
    public class DatabaseContext
    {
        private readonly DatabaseContext _databaseContext;

        public DatabaseContext(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public DbSet<Employee> Employees { get; set; }
    }
}