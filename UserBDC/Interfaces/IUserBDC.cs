using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UserBDC.Interfaces
{
    public interface IUserBDC
    {
        UserDTO GetUserByID(int userId);
    }
}
