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
    public class DepartmentController : Controller
    {
        private IDepartmentService _departmentService;
        private ILoggerService _loggerService;

        public DepartmentController()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            _departmentService = kernel.Get<IDepartmentService>();
            _loggerService = kernel.Get<ILoggerService>();

        }

        public ActionResult Create()
        {
            try
            {
                _loggerService.WriteLog("DepartmentController Create", LOG.Debug);

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

        [HttpPost]
        public ActionResult CreateNew(Department dep)
        {
            try
            {
                _loggerService.WriteLog("DepartmentController CreateNew", LOG.Debug);

                var result = _departmentService.Create(dep);

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
                _loggerService.WriteLog("DepartmentController GetAll", LOG.Debug);

                var departments = _departmentService.GetAll();

                if (departments != null)
                {
                    ViewBag.Message = $"Total Departments: {departments.Count}";

                    return View(departments);
                }

                ViewBag.Message = $"Error getting departments";
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