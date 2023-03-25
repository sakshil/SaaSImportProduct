using Microsoft.VisualStudio.TestTools.UnitTesting;
using SaaSProductsImport.Services;
using SaaSProductsImport.Services.Products;
using System;
using System.IO;

namespace SaaSImportProductTest
{
    [TestClass]
    public class UnitTestCases
    {
        private CapterraService capterraService;
        private FileFormatter formatterInstance;
        public UnitTestCases()
        {
            capterraService = new CapterraService();
            formatterInstance = new FileFormatter();
        }
        [TestMethod]
        public void InCorrectFilePath()
        {
            var filePath = "someInvalidPath";
            var exceptionMessage = "File path or name is invalid";

            var exception = Assert.ThrowsException<IOException>(() => capterraService.ProcessFile(filePath));

            Assert.AreEqual(exceptionMessage, exception.Message);
        }
        [TestMethod]
        public void InCorrectFileExtension()
        {
            var fileName = "randomFile.jhst";
            var exceptionMessage = "File path or name is invalid";

            var exception = Assert.ThrowsException<IOException>(() => formatterInstance.GetFileFormatterInstance(fileName));

            Assert.AreEqual(exceptionMessage, exception.Message);
        }
    }
}
