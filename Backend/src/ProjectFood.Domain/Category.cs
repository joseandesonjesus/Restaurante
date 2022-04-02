using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFood.Domain
{
    public class Category
    {
        [Key]
        public int Id { get; set; }  
        public string NameCategory { get; set; }
        public string BulkProduct { get; set; }
        //public int? ProductId { get; set; }
        //public Product Product { get; set; }
    }
}