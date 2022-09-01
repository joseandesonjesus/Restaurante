using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFood.Application.Dtos
{
    public class OrdersTableDto
    {
        public int Id { get; set; }
        public int InTableId { get; set; }
        public InTableDto InTable { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public int Amount { get; set; }
        public string Obs { get; set; }
        public string Opened { get; set; }
        public string Closed { get; set; }
    }
}
