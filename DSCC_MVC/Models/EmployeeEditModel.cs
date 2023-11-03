namespace DSCC_MVC.Models
{
    public class EmployeeEditModel
    {
        public Employee Employee { get; set; }

        public IEnumerable<Department> Departments { get; set; }
    }
}