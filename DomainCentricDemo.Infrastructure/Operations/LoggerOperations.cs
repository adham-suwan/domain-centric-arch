using DomainCentricDemo.Core.IOperations;
using DomainCentricDemo.Core.IServices;
using DomainCentricDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCentricDemo.Infrastructure.Operations
{
    public class LoggerOperations : ILoggerOperations
    {
        public void DbLog(string logText)
        {
            System.Diagnostics.Debug.WriteLine($"Log: {logText} to Database");
        }

        public void FileLog(string logText)
        {
            System.Diagnostics.Debug.WriteLine($"Log: {logText} to File");
        }
    }
}
