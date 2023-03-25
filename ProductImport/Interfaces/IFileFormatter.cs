using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaaSProductsImport.Interface
{
    public interface IFileFormatter
    {
        void ProcessFile(string filePath);
    }
}
