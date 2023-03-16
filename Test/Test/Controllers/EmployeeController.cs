
using System.Net;
using Test.Models;
using System.Net;
using System.Net.Http;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Test.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class EmployeeController : Controller
    {
        IList<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
               EmployeeId=1, EmployeeName = "Mukesh Kumar", Address = "New Delhi", Department = "IT"
             },
            new Employee()
                {
                    EmployeeId = 2, EmployeeName = "Banky Chamber", Address = "London", Department = "HR"
                },
                new Employee()
                {
                    EmployeeId = 3, EmployeeName = "Rahul Rathor", Address = "Laxmi Nagar", Department = "IT"
                },
                new Employee()
                {
                    EmployeeId = 4, EmployeeName = "YaduVeer Singh", Address = "Goa", Department = "Sales"
                },
                new Employee()
                {
                    EmployeeId = 5, EmployeeName = "Manish Sharma", Address = "New Delhi", Department = "HR"
                }
        };
        [HttpGet]
      
        
        public   IActionResult GetAllEmployees()
        {
            return Ok(employees);
        }

        [HttpGet]
        [Route("getall")]
        public Employee GetEmployeeDetails(int id)
        {
            var employee = employees.FirstOrDefault(e=> e.EmployeeId == id);
            if(employee == null)
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound );
            }
            return employee;
        }
    }
}
