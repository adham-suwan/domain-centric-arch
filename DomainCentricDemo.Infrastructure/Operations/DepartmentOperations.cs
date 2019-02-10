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
    public class DepartmentOperations : IDepartmentOperations
    {
        ILoggerService _logger;
        DepartmentContext _departmentDbContext;

        public DepartmentOperations(ILoggerService logger)
        {
            _logger = logger;
            _departmentDbContext = new DepartmentContext();
        }


        public int Insert(Department dep)
        {
            try
            {
                // Execute the DAL code
                var result = _departmentDbContext.Create(
                    new MongoDB_Department
                    {
                        DeptId = dep.Id,
                        Name = dep.Name,
                        Location = dep.Location
                    });


                // Some logs
                _logger.Log($"Insert Department succeeded. ObjectId: {result.Id.ToString()}", true);


                // Return the execution result
                return 0;
            }
            catch (Exception ex)
            {
                _logger.Log($"Insert Department failed. Exception: {ex.Message}", true);

                return -1;
            }
        }

        public List<Department> SelectAll()
        {
            try
            {
                // Execute the DAL code
                var result = _departmentDbContext.Get();


                // Some logs
                _logger.Log($"SelectAll Department succeeded. Total: {result.Count}", true);


                // Return the execution result
                return result.Select(r => new Department()
                {
                    Id = r.DeptId,
                    Location = r.Location,
                    Name = r.Name

                }).ToList();
            }
            catch (Exception ex)
            {

                _logger.Log($"SelectAll Department failed. Exception: {ex.Message}", true);

                return null;
            }
        }
    }
}
