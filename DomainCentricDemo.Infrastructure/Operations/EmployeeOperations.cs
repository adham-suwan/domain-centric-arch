using DomainCentricDemo.Core.IOperations;
using DomainCentricDemo.Core.IServices;
using DomainCentricDemo.Core.Models;
using DomainCentricDemo.Infrastructure.DAL;
using DomainCentricDemo.Infrastructure.MongoDB_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DomainCentricDemo.Core.Lookups;

namespace DomainCentricDemo.Infrastructure.Operations
{
    public class EmployeeOperations : IEmployeeOperations
    {
        ILoggerService _loggerService;
        EmployeeContext _employeeDbContext;


        public EmployeeOperations(ILoggerService logger)
        {
            _loggerService = logger;
            _employeeDbContext = new EmployeeContext();

        }


        public int Insert(Employee emp)
        {
            try
            {
                // Execute the DAL code
                var result = _employeeDbContext.Create(
                    new MongoDB_Employee
                    {
                        EmpId = emp.Id,
                        Name = emp.Name,
                        Address = emp.Address,
                        DepartmentId = emp.DepartmentId,
                        Type = emp.Type
                    });


                // Some logs
                _loggerService.WriteLog($"Insert Employee succeeded. ObjectId: {result.Id.ToString()}", LOG.Info);


                // Return the execution result
                return 0;
            }
            catch (Exception ex)
            {
                _loggerService.WriteLog($"Insert Employee failed. Exception: {ex.Message}", LOG.Fatal);

                return -1;
            }
        }

        public List<Employee> SelectAll()
        {
            try
            {
                // Execute the DAL code
                var result = _employeeDbContext.Get();


                // Some logs
                _loggerService.WriteLog($"SelectAll Employee succeeded. Total: {result.Count}", LOG.Info);


                // Return the execution result
                return result.Select(r => new Employee()
                {
                    Name = r.Name,
                    Address = r.Address,
                    Type = r.Type,
                    Id = r.EmpId,
                    DepartmentId = r.DepartmentId

                }).ToList();
            }
            catch (Exception ex)
            {

                _loggerService.WriteLog($"SelectAll Employee failed. Exception: {ex.Message}", LOG.Fatal);

                return null;
            }
        }
    }
}
