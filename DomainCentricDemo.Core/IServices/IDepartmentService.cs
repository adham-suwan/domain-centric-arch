using DomainCentricDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCentricDemo.Core.IServices
{
    public interface IDepartmentService
    {
        int Add(Department dep);
        Department Get(string id);
    }
}
