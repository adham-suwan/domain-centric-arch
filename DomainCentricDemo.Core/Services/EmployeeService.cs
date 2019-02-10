using DomainCentricDemo.Core.IOperations;
using DomainCentricDemo.Core.IServices;
using DomainCentricDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCentricDemo.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeOperations _empOps;

        public EmployeeService(IEmployeeOperations empOps)
        {
            _empOps = empOps;
        }

        public int Add(Employee emp)
        {
            // Business rules here
            if (emp.Address == "Ramallah" && emp.DepartmentId == "1")
            {
                emp.Type = "Permenant";
            }
            else
            {
                emp.Type = "Contract";
            }

            // To the operations
            return _empOps.Create(emp);
        }

        public Employee Get(string id)
        {

            // To the operations
            var emp = _empOps.Find(id);


            // Business rules here
            if (emp.Name == "Secret")
            {
                return new Employee();
            }
            return emp;
        }
    }
}
