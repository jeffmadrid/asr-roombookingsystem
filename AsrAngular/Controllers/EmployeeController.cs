using System.Collections.Generic;
using Angular.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace Angular.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeDataAccessLayer employeeDataAccessLayer = new EmployeeDataAccessLayer();

        [HttpGet]
        [Route("Index")]
        public IEnumerable<Employee> Get()
        {
            return employeeDataAccessLayer.GetAllEmployee();
        }

        [HttpPost]
        [Route("Create")]
        public int Create([FromBody] Employee employee)
        {
            return employeeDataAccessLayer.AddEmployee(employee);
        }

        [HttpGet]
        [Route("Details/{id}")]
        public Employee Details(int id)
        {
            return employeeDataAccessLayer.GetEmployeeData(id);
        }

        [HttpPut]
        [Route("Edit")]
        public int Edit([FromBody] Employee employee)
        {
            return employeeDataAccessLayer.UpdateEmployee(employee);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public int Delete(int id)
        {
            return employeeDataAccessLayer.DeleteEmployee(id);
        }

        [HttpGet]
        [Route("GetCityList")]
        public IEnumerable<City> Details()
        {
            return employeeDataAccessLayer.GetCities();
        }
    }
}
