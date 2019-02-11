using DomainCentricDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainCentricDemo.Core.IOperations
{
    public interface ILoggerOperations
    {
        void Debug(string text);
        void Info(string text);
        void Error(string text);
        void Fatal(string text);
        void Warning(string text);
    }
}
