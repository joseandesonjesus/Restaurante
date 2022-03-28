using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFood.Domain
{
    public class Images
    {
        public int Id { get; set; }
        public string NameImage { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }

    }
}