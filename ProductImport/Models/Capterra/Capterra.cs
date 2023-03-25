using SaaSProductsImport.Models.Domain;

namespace SaaSProductsImport.Models.Capterra
{
    public class Capterra : BaseEntity
    {
        public string Tags { get; set; }
        public string Name { get; set; }
        public string Twitter { get; set; }
    }
}
