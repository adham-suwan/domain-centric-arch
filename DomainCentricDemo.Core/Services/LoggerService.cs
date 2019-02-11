using DomainCentricDemo.Core.IOperations;
using DomainCentricDemo.Core.IServices;
using DomainCentricDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DomainCentricDemo.Core.Lookups;

namespace DomainCentricDemo.Core.Services
{
    public class LoggerService : ILoggerService
    {
        private ILoggerOperations _logOps;

        public LoggerService(ILoggerOperations logOps)
        {
            _logOps = logOps;
        }


        public void WriteLog(string logText, LOG type)
        {
            // Add some logic
            switch (type)
            {
                case LOG.Debug:
                    _logOps.Debug(logText);
                    break;
                case LOG.Warning:
                    _logOps.Warning(logText);
                    break;
                case LOG.Info:
                    _logOps.Info(logText);
                    break;
                case LOG.Error:
                    _logOps.Error(logText);
                    break;
                case LOG.Fatal:
                    _logOps.Fatal(logText);
                    break;
                default:
                    _logOps.Debug(logText);
                    break;
            }

        }
    }
}
