using Newtonsoft.Json;
using SaaSImportProduct.Interface;
using SaaSImportProduct.Models.SoftwareAdvice;
using System;
using System.IO;

namespace SaaSImportProduct.Services.Products
{
    public class SoftwareAdviceService : IFileParser
    {

        private IRepository repositorySoftwareAdivce;
        public SoftwareAdviceService()
        {
            repositorySoftwareAdivce = RepositoryServiceProvider.GetRepositoryInstance();
        }

        public void ProcessFile(string filePath)
        {
            try
            {
                string combinedFilePath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, filePath.Replace('/', '\\'));
                using (var reader = new StreamReader(combinedFilePath))
                {
                    string content = reader.ReadToEnd();
                    SoftwareAdvice softwareAdvice = JsonConvert.DeserializeObject<SoftwareAdvice>(content);
                    foreach (var item in softwareAdvice.Products)
                    {
                        Console.WriteLine($"importing: Title: \"{item.Title}\"; Categories: {string.Join(",", item.Categories)}; Twitter: {item.Twitter ?? "Not Applicable"}");
                    }

                    repositorySoftwareAdivce.InsertMany<SoftwareAdviceProduct>(softwareAdvice.Products);

                }
            }
            catch (IOException)
            {
                throw new IOException("File path or name is invalid");
            }
            catch (Exception)
            {
                throw new IOException("Invalid input");
            }
        }
    }
}
