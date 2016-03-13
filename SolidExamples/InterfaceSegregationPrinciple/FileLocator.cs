using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrinciple
{
    public class FileLocator : IFileLocator
    {

        public string GetErrorFile(int id)
        {
            var fileName = string.Format(@"c:\Error\{0}", id);
            DirectoryInfo directoryInfo = new DirectoryInfo(fileName);
            if (directoryInfo.Exists)
            {
                return fileName;
            }
            return string.Empty;
        }
    }
}
