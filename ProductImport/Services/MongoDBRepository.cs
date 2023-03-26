using SaaSImportProduct.Models.Domain;
using SaaSImportProduct.Services.Products;
using System.Collections.Generic;

namespace SaaSImportProduct.Services
{
    class MongoDBRepository : IRepository
    {        
        public void InsertMany<T>(List<T> Entity) where T : BaseEntity
        {
            ////Logic for saving list of entities to mongo db
        }
    }
}
