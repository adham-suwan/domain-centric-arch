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
    public class DepartmentOperations : IDepartmentOperations
    {
        ILoggerService _loggerService;
        DepartmentContext _departmentDbContext;

        public DepartmentOperations(ILoggerService logger)
        {
            _loggerService = logger;
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
                _loggerService.WriteLog($"Insert Department succeeded. ObjectId: {result.Id.ToString()}", LOG.Info);


                // Return the execution result
                return 0;
            }
            catch (Exception ex)
            {
                _loggerService.WriteLog($"Insert Department failed. Exception: {ex.Message}", LOG.Fatal);

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
                _loggerService.WriteLog($"SelectAll Department succeeded. Total: {result.Count}", LOG.Info);


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

                _loggerService.WriteLog($"SelectAll Department failed. Exception: {ex.Message}", LOG.Fatal);

                return null;
            }
        }
    }
}
