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

namespace DomainCentricDemo.Infrastructure.Operations
{
    public class EmployeeOperations : IEmployeeOperations
    {
        ILoggerService _logger;
        EmployeeContext _employeeDbContext;


        public EmployeeOperations(ILoggerService logger)
        {
            _logger = logger;
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
                _logger.Log($"Insert Employee succeeded. ObjectId: {result.Id.ToString()}", false);


                // Return the execution result
                return 0;
            }
            catch (Exception ex)
            {
                _logger.Log($"Insert Employee failed. Exception: {ex.Message}", false);

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
                _logger.Log($"SelectAll Employee succeeded. Total: {result.Count}", false);


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

                _logger.Log($"SelectAll Employee failed. Exception: {ex.Message}", false);

                return null;
            }
        }
    }
}
