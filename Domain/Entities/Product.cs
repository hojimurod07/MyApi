

using System.Transactions;
using System.Xml.Linq;

namespace Domain.Entities
{
    public class Product :BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }=  string.Empty;

        public double Price { get; set; } 
        public int CAtegoryId { get; set; }
        public Category Category { get; set; } = new();

    }
}
