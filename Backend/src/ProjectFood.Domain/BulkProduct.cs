using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFood.Domain
{
    public class BulkProduct
    {
        [Key]
        public int Id { get; set; }
        public string NameBulk { get; set; }
        public string Abbreviation { get; set; }
    }
}
