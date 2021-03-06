﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrinciple
{
    public class FileLogger : ILogger
    {

        public FileLogger()
        {
            // Code for initialization i.e. Creating Log file with specified details
        }
        public virtual void Info(string info)
        {
            // Code for writing details into text file 
        }
        public virtual void Debug(string info)
        {
            // Code for writing debug information into text file 
        }
        public virtual void Error(string message, Exception ex)
        {
            // Code for writing Error with message and exception detail
        }
        public string GetErrorFile(int id)
        {
            var fileName = string.Format(@"c:\Error\{0}.txt", id);
            var directoryInfo = new DirectoryInfo(fileName);
            if (directoryInfo.Exists)
            {
                return fileName;
            }
            return string.Empty;
        }
    }
}
