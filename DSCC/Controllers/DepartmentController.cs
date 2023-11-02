using Microsoft.AspNetCore.Mvc;
using DSCC.Repositories;
using DSCC.Models;

namespace DSCC.Controllers
{
    [Route("api/departments")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentRepository _departmentRepository;

        public DepartmentController( DepartmentRepository departmentRepository )
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public IActionResult GetAllDepartments()
        {
            IEnumerable<Department> departments = _departmentRepository.GetAll();

            return Ok(departments);
        }


        [HttpGet("{id}")]
        public IActionResult GetDepartmentById( int id )
        {
            var department = _departmentRepository.GetOne(id);

            if (department == null) return NotFound();

            return Ok(department);
        }

        [HttpPost]
        public IActionResult CreateDepartment( [FromBody] Department department )
        {
            bool isSuccess = _departmentRepository.Insert(department);

            if (!isSuccess) return BadRequest();

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateDepartment( [FromBody] Department department )
        {
            var isSucess = _departmentRepository.Update(department);

            if (!isSucess) return BadRequest();

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment( int id )
        {
            var isSuccess = _departmentRepository.Delete(id);

            if (isSuccess) return Ok();

            return BadRequest();
        }
    }
}
