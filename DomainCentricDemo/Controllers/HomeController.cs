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
    public class HomeController : Controller
    {
        private ILoggerService _loggerService;

        public HomeController()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

           _loggerService = kernel.Get<ILoggerService>();

        }

        public ActionResult Index()
        {
            try
            {
                _loggerService.WriteLog("HomeController Index", LOG.Debug);

                return View();
            }
            catch (Exception ex)
            {

                _loggerService.WriteLog(ex.Message, LOG.Fatal);

                TempData["ErrorMessage"] = "Error: " + ex.Message;

                return RedirectToAction("Error", "Home");
            }
        }

        public ActionResult Error()
        {
            _loggerService.WriteLog("HomeController Error", LOG.Debug);

            ViewBag.Message = TempData["ErrorMessage"];

            return View();
        }
    }
}