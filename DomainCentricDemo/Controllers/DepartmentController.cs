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

        public ActionResult Add()
        {
            var addResult = _departmentService.Add(new Department { Name = "Marketing", Location = "2nd Floor" });

            ViewBag.Message = $"Add Department Result: {addResult}";

            return View();
        }

        public ActionResult Get()
        {
            var dep = _departmentService.Get("2");

            ViewBag.Message = $"Get Department Name: {dep.Name} Location: {dep.Location}";

            return View();
        }
    }
}