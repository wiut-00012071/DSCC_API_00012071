using DSCC_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DSCC_MVC.Services;

namespace DSCC_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController( EmployeeService employeeService )
        {
            _employeeService = employeeService;
        }

        public ActionResult Index()
        {
            List<Employee> employees = _employeeService.GetAll();

            return View(employees);
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register( Employee employee )
        {
            Employee newEmployee = _employeeService.Insert(employee);

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Details( int id )
        {
            Employee employee = _employeeService.GetOne(id);

            if (employee == null) return RedirectToAction(nameof(Index));

            return View(employee);
        }

        public ActionResult Edit( int id )
        {
            Employee employee = _employeeService.GetOne(id);

            if (employee == null) return RedirectToAction(nameof(Index));

            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit( int id, Employee employee )
        {
            Employee updatedEmployee = _employeeService.Update(id, employee);

            if (updatedEmployee == null) return RedirectToAction(nameof(Edit), new { id });

            return RedirectToAction(nameof(Details), new { id });
        }

        public ActionResult Delete( int id )
        {
            bool isSuccess = _employeeService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}