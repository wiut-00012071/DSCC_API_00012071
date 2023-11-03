using DSCC.Data;
using DSCC.Interfaces;
using DSCC.Models;
using Microsoft.EntityFrameworkCore;

namespace DSCC.Repositories
{
    public class DepartmentRepository : IRepository<Department>
    {
        public DepartmentRepository( DataContext dbContext )
        {
            _dbContext = dbContext;
        }

        private readonly DataContext _dbContext;

        public IEnumerable<Department> GetAll()
        {
            try
            {
                return _dbContext.Departments.ToList();
            }
            catch
            {
                return Enumerable.Empty<Department>();
            }
        }

        public Department? GetOne( int id )
        {
            try
            {
                return _dbContext.Departments.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public bool Insert( Department department )
        {
            try
            {
                _dbContext.Add(department);

                Save();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update( Department department )
        {
            try
            {
                _dbContext.Departments.Update(department);

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
                int refsCount = _dbContext.Employees.Count(e => e.DepartmentId == id);

                if (refsCount > 0) return false;

                var department = GetOne(id);

                if (department == null) return false;

                _dbContext.Departments.Remove(department);

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
            return _dbContext.Departments.Any(department => department.Id == id);
        }

    }
}
