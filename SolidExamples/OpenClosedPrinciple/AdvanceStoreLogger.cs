using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrinciple
{
    public class AdvanceStoreLogger : StoreLogger
    {
        //Implementation of AdvanceStoreLogger
        public AdvanceStoreLogger()
        {
            
        }

        public override void Info(string info)
        {
            // Code for writing details into DB 
        }
        public override void Debug(string info)
        {
            // Code for writing debug information into DB
        }
        public override void Error(string message, Exception ex)
        {
            // Code for writing Error with message and exception detail
        }
    }
}
