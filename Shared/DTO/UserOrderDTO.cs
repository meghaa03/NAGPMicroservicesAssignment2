using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTO
{
    public class UserOrderDTO
    {
        public UserDTO UserDetails { get; set; }
        public List<OrderDTO> Orders { get; set; }

    }
}
