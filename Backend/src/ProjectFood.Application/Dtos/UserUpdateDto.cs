using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFood.Application.Dtos
{
    public class UserUpdateDto : UserDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Function { get; set; }
        public string Description { get; set; }
    }
}


