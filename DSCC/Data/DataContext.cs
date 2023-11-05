using Microsoft.EntityFrameworkCore;
using DSCC_API_00012071.Models;

namespace DSCC_API_00012071.Data
{
    public class DataContext : DbContext
    {
        public DataContext( DbContextOptions<DataContext> options ) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
