using SaaSImportProduct.Interface;
using SaaSImportProduct.Services.Products;
using System;

namespace SaaSImportProduct.Services
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
                throw new ArgumentException("The file parser for the given file type is not supported");
            }

        }
    }
}
