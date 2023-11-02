using Microsoft.AspNetCore.Mvc;
using DSCC.Repositories;
using DSCC.Models;

namespace DSCC.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeController( EmployeeRepository employeeRepository )
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            IEnumerable<Employee> employees = _employeeRepository.GetAll();

            return Ok(employees);
        }


        [HttpGet("{id}")]
        public IActionResult GetEmployeeById( int id )
        {
            var employee = _employeeRepository.GetOne(id);

            if (employee == null) return NotFound();

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult CreateEmployee( [FromBody] Employee employee )
        {
            bool isSuccess = _employeeRepository.Insert(employee);

            if (!isSuccess) return BadRequest();

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateEmployee( [FromBody] Employee employee )
        {
            var isSucess = _employeeRepository.Update(employee);

            if (!isSucess) return BadRequest();

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee( int id )
        {
            var isSuccess = _employeeRepository.Delete(id);

            if (isSuccess) return Ok();

            return BadRequest();
        }
    }
}
