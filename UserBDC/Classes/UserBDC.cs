using MySql.Data.MySqlClient;
using Shared;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;
using UserBDC.Interfaces;

namespace UserBDC.Classes
{
    public class UserBDC : IUserBDC
    {
        public UserDTO userDetails;

        public UserBDC()
        {

        }

        public UserDTO GetUserByID(int userId)
        {
            return GetUserDataById(userId).GetAwaiter().GetResult();
        }

        private async Task<UserDTO> GetUserDataById(int userId)
        {
            UserDTO userData = null;
            try
            {
                using (var conn = new MySqlConnection("server=34.66.100.232;user id=root;password=password;port=3306;database=nagp_assignment;"))
                {
                    conn.Open();

                    string command = "SELECT * FROM User WHERE Id = '" + userId + "'";
                    MySqlCommand cmd = new MySqlCommand(command, conn);

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            userData = new UserDTO
                            {
                                Name = reader.GetString(1),
                                Age = reader.GetInt32(2),
                                Email = reader.GetString(3),
                            };
                        }

                    }
                    conn.Close();
                }

            }
            catch (Exception e)
            {

            }

            return userData;
        }

    }
}
