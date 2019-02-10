using DomainCentricDemo.Core.IOperations;
using DomainCentricDemo.Core.IServices;
using DomainCentricDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCentricDemo.Infrastructure.Implementations
{
    public class EmployeeOperations : IEmployeeOperations
    {
        ILoggerService _logger;

        public EmployeeOperations(ILoggerService logger)
        {
            _logger = logger;
        }


        public int Create(Employee emp)
        {
            // Execute the code that create new employee, in DB for example

            // Some logs
            _logger.Log("New Employee created", false);

            // Return the execution result
            return 0;
        }

        public Employee Find(string id)
        {

            // Execute the code that find the employee


            // Some logs
            _logger.Log("Employee found", false);

            // Return the execution result
            return new Employee
            {
                Address = "Ramallah",
                DepartmentId = "1",
                Id = "14",
                Name = "Adham Suwan",
                Type = "Permenant"
            };
        }
    }
}
