using DomainCentricDemo.Core.IServices;
using DomainCentricDemo.Core.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace DomainCentricDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService;
        private ILoggerService _loggerService;

        public EmployeeController()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            _employeeService = kernel.Get<IEmployeeService>();
            _loggerService = kernel.Get<ILoggerService>();

        }

        public ActionResult Add()
        {
            var addResult = _employeeService.Add(new Employee { Name = "Ahmad", Address = "Ramallah", DepartmentId = "2" });

            ViewBag.Message = $"Add Employee Result: {addResult}";

            return View();
        }

        public ActionResult Get()
        {
            var emp = _employeeService.Get("2");

            ViewBag.Message = $"Get Employee Name: {emp.Name} Type: {emp.Type} Address: {emp.Address}";

            return View();
        }
    }
}