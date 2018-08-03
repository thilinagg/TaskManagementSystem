using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.DataAccess
{
    public class AccountDA
    {
        public User loginDA(User user)
        {
            PasswordProtection pp = new PasswordProtection();
            var hashedPassowrd = pp.GenerateSHA256(user.password);

            Dictionary<string, SqlParameter> queryParameters = new Dictionary<string, SqlParameter>();
            queryParameters["userName"] = new SqlParameter("userName", user.userName);
            queryParameters["password"] = new SqlParameter("password", hashedPassowrd);

            try
            {
                SqlDataReader reader = SqlDatabaseUtility.ExecuteQuery("[dbo].[Login]", queryParameters);
                while (reader.Read() == true)
                {
                    if (reader.GetInt32(reader.GetOrdinal("id")) > 0)
                    {
                        user.id = reader.GetInt32(reader.GetOrdinal("id"));
                        user.userName = reader.GetString(reader.GetOrdinal("userName"));
                        user.role = reader.GetInt32(reader.GetOrdinal("role"));
                    }
                    else
                    {
                        user.userName = null;
                        user.role = 0;
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }

            return user;
        }


    }
}
