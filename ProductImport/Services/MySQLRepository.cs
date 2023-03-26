using SaaSImportProduct.Models.Domain;
using SaaSImportProduct.Services.Products;
using System;
using System.Collections.Generic;

namespace SaaSImportProduct.Services
{
    class MySQLRepository : IRepository 
    {               

        public void InsertMany<T>(List<T> Entity) where T : BaseEntity
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"Saving to the table {typeof(T).Name} ");
            ////Logic for saving the list to my sql db
        }
    }
}
