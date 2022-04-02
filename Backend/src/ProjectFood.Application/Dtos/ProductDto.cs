using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFood.Application.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public IEnumerable<ImagesDto> Image { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]

        public string NameProduct { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal PriceProduct { get; set; }
        public int Discount { get; set; }
        public string DateRegister { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool StatusProduct { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }

    }
}