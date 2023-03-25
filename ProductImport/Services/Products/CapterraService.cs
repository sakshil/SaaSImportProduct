﻿using SaaSProductsImport.Interface;
using SaaSProductsImport.Models.Capterra;
using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace SaaSProductsImport.Services.Products
{
    public class CapterraService : IFileFormatter
    {
        private IRepository repositorySoftwareAdivce;

        public CapterraService()
        {
            repositorySoftwareAdivce = RepositoryDIService.GetRepositoryInstance();
        }
        public void ProcessFile(string filePath)
        {
            try
            {
                string combinedFilePath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, filePath.Replace('/', '\\'));
                using (var reader = new StreamReader(combinedFilePath))
                {
                    var deserializer = new DeserializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance).Build();
                    List<Capterra> listCapterra = deserializer.Deserialize<List<Capterra>>(reader);
                    foreach (var item in listCapterra)
                    {
                        Console.WriteLine($"importing: Name: \"{item.Name}\"; Tags: {item.Tags}; Twitter: @{ item.Twitter ?? "Not Applicable"}");
                    }

                    repositorySoftwareAdivce.InsertMany<Capterra>(listCapterra);

                }
            }
            catch(IOException)
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