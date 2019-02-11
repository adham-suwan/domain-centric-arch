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
        public static log4net.ILog logger;

        public LoggerOperations()
        {
            logger = log4net.LogManager.GetLogger("DomainCentricDemoLogger");
            log4net.Config.XmlConfigurator.Configure();
        }


        public void Debug(string text)
        {
            logger.Debug(text);
        }

        public void Info(string text)
        {
            logger.Info(text);
        }
        public void Error(string text)
        {
            logger.Error(text);
        }
        public void Fatal(string text)
        {
            logger.Fatal(text);
        }
        public void Warning(string text)
        {
            logger.Warn(text);
        }
    }
}
