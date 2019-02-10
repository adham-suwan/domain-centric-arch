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
    public class DepartmentService : IDepartmentService
    {
        private IDepartmentOperations _depOps;

        public DepartmentService(IDepartmentOperations depOps)
        {
            _depOps = depOps;
        }

        public int Create(Department dep)
        {
            // Business rules & validations here
            if (string.IsNullOrEmpty(dep.Id) || string.IsNullOrEmpty(dep.Name))
                return -1;


            // To the operations
            var insertResult = _depOps.Insert(dep);

            // Return the result
            return insertResult;
        }

        public List<Department> GetAll()
        {
            // To the operations
            var departments = _depOps.SelectAll();


            // Business rules here


            // Return the result
            return departments;
        }
    }
}
