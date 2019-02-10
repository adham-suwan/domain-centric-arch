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

        public int Add(Department emp)
        {
            // Business rules here



            // To the operations
            return _depOps.Create(emp);
        }

        public Department Get(string id)
        {

            // To the operations
            var dep = _depOps.Find(id);


            // Business rules here

            return dep;
        }
    }
}
