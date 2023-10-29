using Microsoft.AspNetCore.Mvc;
using DSCC.Dtos;
using DSCC.Repositories;
using DSCC.Models;

namespace DSCC.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeController(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult GetAllEmployees ()
        {
            IEnumerable<Employee> employees = _employeeRepository.GetAll();

            List<EmployeeResponseDto> employeeResponseDtos = new() { };

            foreach (Employee employee in employees)
            {
                var employeeResponseDto = EmployeeResponseDto.MapFromEmployee(employee);

                employeeResponseDtos.Add(employeeResponseDto);
            }

            return Ok(employeeResponseDtos);

        }


        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetOne(id);

            if (employee == null) return BadRequest();

            EmployeeResponseDto employeeResponseDto = EmployeeResponseDto.MapFromEmployee(employee);

            return Ok(employeeResponseDto);
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            var isSuccess = _employeeRepository.Insert(employee);

            if (isSuccess) return Ok(EmployeeResponseDto.MapFromEmployee(employee));

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee( int id, [FromBody] EmployeeUpdateDto employeeUpdateDto )
        {
            var employee = _employeeRepository.GetOne(id);

            if (employee == null) return BadRequest();

            employee.FirstName = employeeUpdateDto.FirstName;
            employee.JobTitle = employeeUpdateDto.JobTitle;
            employee.LastName = employeeUpdateDto.LastName;
            employee.Bio = employeeUpdateDto.Bio;

            var isSucess = _employeeRepository.Update(employee);

            if (!isSucess) return BadRequest();

            var employeeResponseDto = EmployeeResponseDto.MapFromEmployee(employee);

            return Ok(employeeResponseDto);
        } 
    }
}
