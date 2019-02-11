using DomainCentricDemo.Core.IServices;
using DomainCentricDemo.Core.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using static DomainCentricDemo.Core.Lookups;

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
                _loggerService.WriteLog("EmployeeController Create", LOG.Debug);

                ViewBag.Message = TempData["CreationResponse"];
                return View();
            }
            catch (Exception ex)
            {

                _loggerService.WriteLog(ex.Message, LOG.Fatal);

                TempData["ErrorMessage"] = "Error: " + ex.Message;

                return RedirectToAction("Error", "Home");

            }
        }


        public ActionResult CreateNew(Employee emp)
        {
            try
            {
                _loggerService.WriteLog("EmployeeController CreateNew", LOG.Debug);

                var result = _employeeService.Create(emp);

                var resultText = result == 0 ? "Success" : "Failed";

                _loggerService.WriteLog($"EmployeeController CreateNew result {resultText}", result == 0 ? LOG.Info : LOG.Error);

                TempData["CreationResponse"] = $"Creation Result: {resultText}";

                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                _loggerService.WriteLog(ex.Message, LOG.Fatal);

                TempData["ErrorMessage"] = "Error: " + ex.Message;

                return RedirectToAction("Error", "Home");

            }
        }

        public ActionResult GetAll()
        {
            try
            {
                _loggerService.WriteLog("EmployeeController GetAll", LOG.Debug);

                var employees = _employeeService.GetAll();

                if (employees != null)
                {
                    ViewBag.Message = $"Total Employees: {employees.Count}";

                    return View(employees);
                }

                _loggerService.WriteLog("EmployeeController Error getting employees", LOG.Error);

                TempData["ErrorMessage"] = $"Error getting employees";
                return RedirectToAction("Error", "Home");
            }
            catch (Exception ex)
            {
                _loggerService.WriteLog(ex.Message, LOG.Fatal);

                TempData["ErrorMessage"] = "Error: " + ex.Message;

                return RedirectToAction("Error", "Home");
            }
        }
    }
}