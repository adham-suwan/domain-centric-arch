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
    public class LoggerService : ILoggerService
    {
        private ILoggerOperations _logOps;

        public LoggerService(ILoggerOperations logOps)
        {
            _logOps = logOps;
        }

        public void Log(string logText, bool isFile)
        {

            // Add some logic
            if (isFile)
            {
                _logOps.FileLog(logText);
            }
            else
            {
                _logOps.DbLog(logText);

            }
        }
    }
}
