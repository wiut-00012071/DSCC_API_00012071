using DSCC_API_00012071.Data;
using DSCC_API_00012071.Interfaces;
using DSCC_API_00012071.Models;
using Microsoft.EntityFrameworkCore;

namespace DSCC_API_00012071.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        public EmployeeRepository( DataContext dbContext )
        {
            _dbContext = dbContext;
        }

        private readonly DataContext _dbContext;

        public IEnumerable<Employee> GetAll()
        {
            try
            {
                return _dbContext.Employees.Include(e => e.Department).ToList();
            }
            catch
            {
                return Enumerable.Empty<Employee>();
            }
        }

        public Employee? GetOne( int id )
        {
            try
            {
                return _dbContext.Employees.Where(e => id == e.Id).Include(e => e.Department).First();
            }
            catch
            {
                return null;
            }
        }

        public bool Insert( Employee employee )
        {
            try
            {
                employee.Department = null;

                _dbContext.Add(employee);

                Save();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update( Employee employee )
        {
            try
            {
                employee.Department = null;

                _dbContext.Employees.Update(employee);

                Save();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete( int id )
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

        public bool isPresent( int id )
        {
            return _dbContext.Employees.Any(employee => employee.Id == id);
        }

    }
}
