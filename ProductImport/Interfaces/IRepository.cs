using SaaSImportProduct.Models.Domain;
using System.Collections.Generic;

namespace SaaSImportProduct.Services.Products
{
    public interface IRepository
    {
        void InsertMany<T>(List<T> Entity) where T : BaseEntity;
    }
}
