using DSCC.Data;
using DSCC.Interfaces;
using DSCC.Models;

namespace DSCC.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        public EmployeeRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly DataContext _dbContext;

        public IEnumerable<Employee> GetAll()
        {
            return _dbContext.Employees.ToList();
        }

        public Employee? GetOne(int id)
        {
            try
            {
                return _dbContext.Employees.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public bool Insert(Employee employee)
        {
            try
            {
                _dbContext.Add(employee);

                Save();

                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Update(Employee employee)
        {
            try
            {
                _dbContext.Employees.Update(employee);

                Save();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var employee = GetOne(id);

                if (employee == null) return false;

                _dbContext.Employees.Remove(employee);

                Save();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public bool isPresent(int id)
        {
            return _dbContext.Employees.Any(employee => employee.Id == id);
        }

    }
}
