using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaaSImportProduct.Interface
{
    public interface IFileParser
    {
        void ProcessFile(string filePath);
    }
}
