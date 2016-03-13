using System;

namespace InterfaceSegregationPrinciple
{
    public interface ILogger
    {
        void Debug(string info);
        void Error(string message, Exception ex);
        void Info(string info);
    }
}