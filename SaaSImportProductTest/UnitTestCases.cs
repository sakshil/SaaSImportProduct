using Microsoft.VisualStudio.TestTools.UnitTesting;
using SaaSImportProduct.Services;
using SaaSImportProduct.Services.Products;
using System;
using System.IO;

namespace SaaSImportProductTest
{
    [TestClass]
    public class UnitTestCases
    {
        private CapterraService capterraService;
        private FileParser formatterInstance;
        public UnitTestCases()
        {
            capterraService = new CapterraService();
            formatterInstance = new FileParser();
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
            var exceptionMessage = "The file parser for the given file type is not supported";

            var exception = Assert.ThrowsException<ArgumentException>(() => formatterInstance.GetFileParserInstance(fileName));

            Assert.AreEqual(exceptionMessage, exception.Message);
        }
    }
}
