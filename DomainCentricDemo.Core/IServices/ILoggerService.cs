using DomainCentricDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DomainCentricDemo.Core.Lookups;

namespace DomainCentricDemo.Core.IServices
{
    public interface ILoggerService
    {
        void WriteLog(string logText, LOG type);
    }
}
