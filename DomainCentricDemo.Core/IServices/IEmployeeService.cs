using DomainCentricDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCentricDemo.Core.IServices
{
    public interface IEmployeeService
    {
        int Create(Employee emp);
        List<Employee> GetAll();

    }
}
