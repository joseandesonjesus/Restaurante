using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFood.Application.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }  
        public string NameCategory { get; set; }
        public string BulkProduct { get; set; }
        //public int? ProductId { get; set; }
        // public ProductDto Product { get; set; }
    }
}