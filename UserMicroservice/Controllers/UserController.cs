using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.DTO;
using UserBDC.Interfaces;

namespace UserMicroservice.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBDC userBDC;

        public UserController(IUserBDC userBDC)
        {
            this.userBDC = userBDC;
        }
        
        [HttpGet("{userId}")]
        public UserDTO Get([FromRoute]int userId)
        {
            //return userBDC.GetUserByID(userId);
            return userBDC.GetUserByID(userId);
        }

        
    }
}
