using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple
{
    public class FileLocator : IFileLocator
    {

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
