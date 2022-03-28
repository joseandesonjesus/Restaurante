using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFood.Domain
{
    public class ProductImage
    {
        public int productId { get; set; }
        public Product product { get; set; }
        public int imageId { get; set; }
        public Images image { get; set; }
    }
}


