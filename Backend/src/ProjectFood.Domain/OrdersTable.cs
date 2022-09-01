using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFood.Domain
{
    public class OrdersTable
    {
        [Key]
        public int Id { get; set; }
        public int InTableId { get; set; }
        public InTable InTable { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
        public string Obs { get; set; }
        public string Opened { get; set; }
        public string Closed { get; set; }
    }
}
