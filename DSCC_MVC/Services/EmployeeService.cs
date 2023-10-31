using DSCC_MVC.Models;

namespace DSCC_MVC.Services
{
    public class EmployeeService
    {
        private readonly RestClientService _restClientService;

        public EmployeeService( RestClientService restClientService )
        {
            _restClientService = restClientService;
        }

        public List<Employee>? GetAll()
        {
            try
            {
                List<Employee> employees = _restClientService.Get<List<Employee>>("employees");

                return employees;
            }
            catch
            {
                return null;
            }
        }

        public Employee? GetOne( int id )
        {
            try
            {
                Employee employee = _restClientService.Get<Employee>($"employees/{id}");

                return employee;
            }
            catch
            {
                return null;
            }
        }

        public Employee? Insert( Employee employee )
        {
            try
            {
                Employee createdEmployee = _restClientService.Post("employees", employee);

                return createdEmployee;
            }
            catch
            {
                return null;
            }
        }

        public Employee? Update( int id, Employee employee )
        {
            try
            {
                Employee updatedEmployee = _restClientService.Put($"employees/{id}", employee);

                return updatedEmployee;
            }
            catch
            {
                return null;
            }
        }

        public bool Delete( int id )
        {
            try
            {
                string status = _restClientService.Delete($"employees/{id}");

                return status == "200";
            }
            catch
            {
                return false;
            }
        }
    }
}
