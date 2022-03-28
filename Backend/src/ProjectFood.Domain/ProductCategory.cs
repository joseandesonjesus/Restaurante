using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFood.Domain
{
    public class ProductCategory
    {
        public int productId { get; set; }
        public Product product { get; set; }
        public int categoryId { get; set; }
        public Category category { get; set; }
    }
}