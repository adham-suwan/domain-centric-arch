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

        public ActionResult Create()
        {
            try
            {
                ViewBag.Message = TempData["CreationResponse"];
                return View();
            }
            catch (Exception ex)
            {

                _loggerService.Log(ex.Message, true);

                TempData["ErrorMessage"] = "Error: " + ex.Message;

                return RedirectToAction("Error", "Home");

            }
        }


        public ActionResult CreateNew(Employee emp)
        {
            try
            {
                var result = _employeeService.Create(emp);

                var resultText = result == 0 ? "Success" : "Failed";

                TempData["CreationResponse"] = $"Creation Result: {resultText}";

                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                _loggerService.Log(ex.Message, true);

                TempData["ErrorMessage"] = "Error: " + ex.Message;

                return RedirectToAction("Error", "Home");

            }
        }

        public ActionResult GetAll()
        {
            try
            {
                var employees = _employeeService.GetAll();

                if (employees != null)
                {
                    ViewBag.Message = $"Total Employees: {employees.Count}";

                    return View(employees);
                }

                TempData["ErrorMessage"] = $"Error getting employees";
                return RedirectToAction("Error", "Home");
            }
            catch (Exception ex)
            {
                _loggerService.Log(ex.Message, true);

                TempData["ErrorMessage"] = "Error: " + ex.Message;

                return RedirectToAction("Error", "Home");
            }
        }
    }
}