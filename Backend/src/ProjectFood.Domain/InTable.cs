﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFood.Domain
{
    public class InTable
    {
        [Key]
        public int Id { get; set; }
        public bool StatusTable { get; set; }
    }
}
