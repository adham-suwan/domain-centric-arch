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
    public class DepartmentOperations : IDepartmentOperations
    {
        ILoggerService _logger;

        public DepartmentOperations(ILoggerService logger)
        {
            _logger = logger;
        }


        public int Create(Department dep)
        {
            // Execute the code that create new department, in DB for example

            // Some logs
            _logger.Log("New Department created", true);

            // Return the execution result
            return 0;
        }

        public Department Find(string id)
        {
            // Execute the code that find the department

            // Some logs
            _logger.Log("Department found", true);

            // Return the execution result
            return new Department
            {
                Id = "2",
                Location = "1st Floor",
                Name = "IT"
            };
        }
    }
}
