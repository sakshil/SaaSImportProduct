using SaaSProductsImport.Models.Domain;
using System.Collections.Generic;

namespace SaaSProductsImport.Services.Products
{
    public interface IRepository
    {
        void InsertMany<T>(List<T> Entity) where T : BaseEntity;
    }
}
