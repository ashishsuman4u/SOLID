using System;

namespace LiskovSubstitutionPrinciple
{
    public interface ILogger
    {
        void Debug(string info);
        void Error(string message, Exception ex);
        string GetErrorFilePath(int id);
        void Info(string info);
    }
}