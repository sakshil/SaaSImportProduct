using SaaSProductsImport.Interface;
using SaaSProductsImport.Services;
using System;

namespace SaaSProductsImport
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                GetInput();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void GetInput()
        {
            string commandString = string.Empty;

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Please enter the command for importing data.");
            commandString = Console.ReadLine();

            if(String.IsNullOrEmpty(commandString))
            {
                GetInput();
            }

            ProcessInput(commandString);
        }
        private static void ProcessInput(string commandString)
        {
            try
            {
                string productName = commandString.Split(' ')[2];
                string filePath = commandString.Split(' ')[3];

                FileParser productSelector = new FileParser();
                IFileParser product = productSelector.GetFileParserInstance(filePath);

                product.ProcessFile(filePath);
                GetInput();
                Console.ReadKey();

            }
            catch (IndexOutOfRangeException)
            {                
                throw new Exception("Invalid or incomplete command");
            }
            catch (ArgumentException)
            {                
                throw new Exception("Invalid product"); 
            }
            catch (Exception)
            {                
                throw new Exception("Invalid or incomplete command");
            }
        }
    }
}