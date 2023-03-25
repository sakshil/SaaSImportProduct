using SaaSProductsImport.Interface;
using SaaSProductsImport.Services.Products;
using System;

namespace SaaSProductsImport.Services
{
    public class FileFormatter
    {
        public IFileFormatter GetFileFormatterInstance(string fileName)
        {
            if (fileName.Contains("yaml"))
            {
                return new CapterraService();
            }
            if (fileName.Contains("json"))
            {
                return new SoftwareAdviceService();
            }
            else
            {
                throw new ArgumentException("Invalid product name");
            }

        }
    }
}
