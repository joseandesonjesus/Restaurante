using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProjectFood.Domain.Identity;

namespace ProjectFood.Domain
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public IEnumerable<Images> Image { get; set; }
        public string NameProduct { get; set; }
        public decimal PriceProduct { get; set; }
        public int Discount { get; set; }
        public string DateRegister { get; set; }
        public bool StatusProduct { get; set; } 
        public int UserId { get; set; }
        public User User { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}