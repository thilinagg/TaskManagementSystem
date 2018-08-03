using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.DataAccess
{
    public class UserDA
    {
        public string UpdatePasswordDA(User user)
        {
            string msg = "";
            PasswordProtection pp = new PasswordProtection();
            var hashedPassowrd = pp.GenerateSHA256(user.password);

            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["id"] = new SqlParameter("id", user.id);
            cmdParameters["password"] = new SqlParameter("password", hashedPassowrd);
            int rc = SqlDatabaseUtility.ExecuteCommand("[dbo].[UpdateUsers]", cmdParameters);

            if (rc == -1)
            {
                msg = "Password updated successfully...!";
            }
            else
            {
                msg = "OOPs, something went wrong...!";
            }
            return msg;

        }

        public List<UserView> ViewUserDA()
        {
            List<UserView> userList = new List<UserView>();

            Dictionary<string, SqlParameter> queryParameters = new Dictionary<string, SqlParameter>();
            SqlDataReader reader = SqlDatabaseUtility.ExecuteQuery("[dbo].[GetUserList]", queryParameters);
            while (reader.Read() == true)
            {
                userList.Add(new UserView()
                {
                    id = reader.GetInt32(reader.GetOrdinal("id")),
                    userName = reader.GetString(reader.GetOrdinal("userName")),
                    role = reader.GetInt32(reader.GetOrdinal("role"))
                });
            }
            return userList;
        }

        public List<Tasks> ViewTaskDA(int id)
        {
            List<Tasks> taskList = new List<Tasks>();

            Dictionary<string, SqlParameter> queryParameters = new Dictionary<string, SqlParameter>();

            if (id == 0)
            {
                SqlDataReader reader = SqlDatabaseUtility.ExecuteQuery("[dbo].[ViewTask]", queryParameters);
                while (reader.Read() == true)
                {
                    taskList.Add(new Tasks()
                    {
                        id = reader.GetInt32(reader.GetOrdinal("id")),
                        taskDetails = reader.GetString(reader.GetOrdinal("taskDetails")),
                        taskAssignedDate = reader.GetString(reader.GetOrdinal("taskAssignedDate")),
                        taskEndDate = reader.GetString(reader.GetOrdinal("taskEndDate")),
                        responsibleUserId = reader.GetInt32(reader.GetOrdinal("responsibleUserId")),
                        responsibleUser = reader.GetString(reader.GetOrdinal("responsibleUser")),
                        teamName = reader.GetString(reader.GetOrdinal("teamName")),
                        status = reader.GetInt32(reader.GetOrdinal("status"))
                    });
                }
            }
            else
            {
                queryParameters["id"] = new SqlParameter("id", id);
                SqlDataReader reader = SqlDatabaseUtility.ExecuteQuery("[dbo].[ViewTask]", queryParameters);
                while (reader.Read() == true)
                {
                    taskList.Add(new Tasks()
                    {
                        id = reader.GetInt32(reader.GetOrdinal("id")),
                        taskDetails = reader.GetString(reader.GetOrdinal("taskDetails")),
                        taskAssignedDate = reader.GetString(reader.GetOrdinal("taskAssignedDate")),
                        taskEndDate = reader.GetString(reader.GetOrdinal("taskEndDate")),
                        responsibleUserId = reader.GetInt32(reader.GetOrdinal("responsibleUserId")),
                        responsibleUser = reader.GetString(reader.GetOrdinal("responsibleUser")),
                        teamName = reader.GetString(reader.GetOrdinal("teamName")),
                        status = reader.GetInt32(reader.GetOrdinal("status"))
                    });
                }
            }
            return taskList;
        }

        public int UpdateStatusDA(Tasks task)
        {

            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["id"] = new SqlParameter("id", task.id);
            cmdParameters["status"] = new SqlParameter("status", task.status);
            int rc = SqlDatabaseUtility.ExecuteCommand("[dbo].[UpdateTask]", cmdParameters);

            return rc;
        }

    }
}
