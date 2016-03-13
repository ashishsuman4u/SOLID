using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    public class FileLogger
    {

        public FileLogger()
        {
            // Code for initialization i.e. Creating Log file with specified  
            // details
        }
        public void Info(string info)
        {
            // Code for writing details into text file 
        }
        public void Debug(string info)
        {
            // Code for writing debug information into text file 
        }
        public void Error(string message, Exception ex)
        {
            // Code for writing Error with message and exception detail
        }
        public string GetErrorFilePath(int id)
        {
            return string.Format(@"c:\Error\{0}", id);
        }
    }
}
