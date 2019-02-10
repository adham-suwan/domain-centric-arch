using DomainCentricDemo.Core.IOperations;
using DomainCentricDemo.Core.IServices;
using DomainCentricDemo.Core.Services;
using DomainCentricDemo.Infrastructure.Operations;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomainCentricDemo
{

        public class DependencyInjectionBindings : NinjectModule 
        {
            public override void Load()
            {

                Bind<IEmployeeService>().To<EmployeeService>();
                Bind<IEmployeeOperations>().To<EmployeeOperations>();

                Bind<IDepartmentOperations>().To<DepartmentOperations>();
                Bind<IDepartmentService>().To<DepartmentService>();

                Bind<ILoggerService>().To<LoggerService>();
                Bind<ILoggerOperations>().To<LoggerOperations>();
            }
        }
    
}