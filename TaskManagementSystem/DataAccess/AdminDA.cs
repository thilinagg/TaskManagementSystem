using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.DataAccess
{
    public class AdminDA : LeadDA
    {
        public string CreateUsersDA(User user)
        {
            string msg = "";
            PasswordProtection pp = new PasswordProtection();
            var hashedPassowrd = pp.GenerateSHA256(user.password);

            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["userName"] = new SqlParameter("userName", user.userName);
            cmdParameters["password"] = new SqlParameter("password", hashedPassowrd);
            cmdParameters["role"] = new SqlParameter("role", user.role);
            int rc = SqlDatabaseUtility.ExecuteCommand("[dbo].[InsertUser]", cmdParameters);

            if (rc == -1)
            {
                msg = "user create successfully...!";
            }
            else
            {
                msg = "OOPs, something went wrong...!";
            }
            return msg;

        }

        public string UpdateUserDA(User user)
        {
            string msg = "";
            PasswordProtection pp = new PasswordProtection();
            var hashedPassowrd = pp.GenerateSHA256(user.password);

            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["id"] = new SqlParameter("id", user.id);
            cmdParameters["userName"] = new SqlParameter("userName", user.userName);
            cmdParameters["password"] = new SqlParameter("password", hashedPassowrd);
            cmdParameters["role"] = new SqlParameter("role", user.role);
            int rc = SqlDatabaseUtility.ExecuteCommand("[dbo].[UpdateUsers]", cmdParameters);

            if (rc == -1)
            {
                msg = "user Update successfully...!";
            }
            else
            {
                msg = "OOPs, something went wrong...!";
            }
            return msg;

        }

        public string DeleteUserDA(User user)
        {
            string msg = "";

            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["id"] = new SqlParameter("id", user.id);
            int rc = SqlDatabaseUtility.ExecuteCommand("[dbo].[DeleteUser]", cmdParameters);

            if (rc == -1)
            {
                msg = "user delete successfully...!";
            }
            else
            {
                msg = "OOPs, something went wrong...!";
            }
            return msg;

        }

        public string CreateTeamDA(Team team)
        {
            string msg = "";

            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["teamName"] = new SqlParameter("teamName", team.teamName);
            int rc = SqlDatabaseUtility.ExecuteCommand("[dbo].[CreateTeam]", cmdParameters);

            if (rc == -1)
            {
                msg = "team create successfully...!";
            }
            else
            {
                msg = "OOPs, something went wrong...!";
            }
            return msg;

        }

        public int GetSavedTeamIDDA()
        {
            var savedTeamId = 0;

            Dictionary<string, SqlParameter> queryParameters = new Dictionary<string, SqlParameter>();
            SqlDataReader reader = SqlDatabaseUtility.ExecuteQuery("[dbo].[GetSavedTeamID]", queryParameters);
            while (reader.Read() == true)
            {
                savedTeamId = reader.GetInt32(reader.GetOrdinal("maxId"));
            }
            return savedTeamId;
        }

        public string AddUsersToTeamDA(Team_User team_User)
        {
            string msg = "";

            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            if (team_User.teamId > 0)
            {
                cmdParameters["teamId"] = new SqlParameter("teamId", team_User.teamId);
            }
            else
            {
                int teamId = GetSavedTeamIDDA();
                cmdParameters["teamId"] = new SqlParameter("teamId", teamId);
            }
            cmdParameters["userId"] = new SqlParameter("userId", team_User.userId);
            int rc = SqlDatabaseUtility.ExecuteCommand("[dbo].[AddUserstoTeam]", cmdParameters);

            if (rc == -1)
            {
                msg = "add user to  team successfully...!";
            }
            else
            {
                msg = "OOPs, something went wrong...!";
            }
            return msg;

        }

        public List<UserView> ViewUserByRoleDA(int role)
        {
            List<UserView> userList = new List<UserView>();

            Dictionary<string, SqlParameter> queryParameters = new Dictionary<string, SqlParameter>();
            queryParameters["role"] = new SqlParameter("role", role);
            SqlDataReader reader = SqlDatabaseUtility.ExecuteQuery("[dbo].[GetUserListByRole]", queryParameters);
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

        public int CheckUserValiedOrNotDA(List<UserView> list, int userId)
        {
            
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].id == userId)
                {
                    return i;
                }
            }
            return -1;
        }

    }
}
