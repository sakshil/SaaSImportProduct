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
                var productName = commandString.Split(' ')[1];
                var filePath = commandString.Split(' ')[2];

                FileFormatter productSelector = new FileFormatter();
                try
                {
                    string fileName = filePath.Split('/')[1];
                    IFileFormatter product = productSelector.GetFileFormatterInstance(fileName);
                    product.ProcessFile(filePath);
                    GetInput();
                    Console.ReadKey();
                }
                catch (Exception)
                {
                    throw new Exception("Invalid file name");
                }
                
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