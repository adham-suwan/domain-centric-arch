using DomainCentricDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCentricDemo.Core.IOperations
{
    public interface IDepartmentOperations
    {
        int Insert(Department dep);
        List<Department> SelectAll();
    }
}
