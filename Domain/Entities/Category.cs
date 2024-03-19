﻿

namespace Domain.Entities
{
    public class Category:BaseEntity
    {
        public string Name {  get; set; } =string.Empty;

        public List<Product> Products = new List<Product>();
    }
}
