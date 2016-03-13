using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrinciple
{
    public class DBLogger : ILogger
    {
        //Implementation of DBLogger
        public DBLogger()
        {
            
        }

        public void Info(string info)
        {
            // Code for writing details into DB 
        }
        public void Debug(string info)
        {
            // Code for writing debug information into DB
        }
        public void Error(string message, Exception ex)
        {
            // Code for writing Error with message and exception detail
        }
        public string GetErrorFile(int id)
        {
            throw new NotSupportedException();
        }
    }
}
