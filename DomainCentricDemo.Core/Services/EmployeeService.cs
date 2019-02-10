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

        public int Create(Employee emp)
        {
            // Business rules & validations here
            if (string.IsNullOrEmpty(emp.Id) || string.IsNullOrEmpty(emp.Name))
                return -1;

            if (emp.Address == "Ramallah" && emp.DepartmentId == "1")
            {
                emp.Type = "Permenant";
            }
            else
            {
                emp.Type = "Contract";
            }


            // To the operations
            var insertResult = _empOps.Insert(emp);

            // Return the result
            return insertResult;

        }

        public List<Employee> GetAll()
        {

            // To the operations
            var employees = _empOps.SelectAll();


            // Business rules here
            employees.RemoveAll(r => r.Name == "Secret");

            // Return the result
            return employees;
        }
    }
}
