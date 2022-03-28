using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFood.Application.Dtos
{
    public class ProductImageDto
    {
        public int productId { get; set; }
        public ProductDto product { get; set; }
        public int imageId { get; set; }
        public ImagesDto image { get; set; }
    }
}