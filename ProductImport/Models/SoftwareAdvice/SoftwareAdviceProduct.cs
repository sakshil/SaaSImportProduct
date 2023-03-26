using SaaSImportProduct.Models.Domain;
using System.Collections.Generic;

namespace SaaSImportProduct.Models.SoftwareAdvice
{
    public class SoftwareAdviceProduct : BaseEntity
    {
        public List<string> Categories { get; set; }

        public string Twitter { get; set; }

        public string Title { get; set; }
    }
}
