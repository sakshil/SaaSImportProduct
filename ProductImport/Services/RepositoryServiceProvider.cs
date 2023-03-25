using Microsoft.Extensions.DependencyInjection;
using SaaSProductsImport.Services.Products;
using System;

namespace SaaSProductsImport.Services
{
    /// <summary>
    /// In future, if we need to change from MySQLRepository to MongoDBRepository, we can easily change it here 
    /// without changing in each class.
    /// </summary>
    public class RepositoryServiceProvider
    {
        private static ServiceProvider serviceProvider;
         static RepositoryServiceProvider()
         {
            serviceProvider = new ServiceCollection()
                .AddScoped<IRepository, MySQLRepository>()
                .BuildServiceProvider();
         }
        
        public static IRepository GetRepositoryInstance()
        {
            try
            {
                return serviceProvider.GetService<IRepository>();
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
