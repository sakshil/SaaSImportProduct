using SaaSProductsImport.Interface;
using SaaSProductsImport.Services.Products;
using System;

namespace SaaSProductsImport.Services
{
    public class FileParser
    {
        public IFileParser GetFileParserInstance(string fileName)
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
