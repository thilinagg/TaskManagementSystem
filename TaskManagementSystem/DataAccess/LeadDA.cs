using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.DataAccess
{
    public class LeadDA : UserDA
    {
        public List<Team> ViewTeamListDA()
        {
            List<Team> teamList = new List<Team>();

            Dictionary<string, SqlParameter> queryParameters = new Dictionary<string, SqlParameter>();
            SqlDataReader reader = SqlDatabaseUtility.ExecuteQuery("[dbo].[TeamList]", queryParameters);
            while (reader.Read() == true)
            {
                teamList.Add(new Team()
                {
                    teamId = reader.GetInt32(reader.GetOrdinal("teamId")),
                    teamName = reader.GetString(reader.GetOrdinal("teamName")),
                    teamLead = reader.GetString(reader.GetOrdinal("teamLead"))
                });
            }
            return teamList;
        }

        public List<UsersToBeTeam> ViewTeamMembersDA(int teamId)
        {
            List<UsersToBeTeam> userList = new List<UsersToBeTeam>();

            Dictionary<string, SqlParameter> queryParameters = new Dictionary<string, SqlParameter>();
            queryParameters["teamId"] = new SqlParameter("teamId", teamId);
            SqlDataReader reader = SqlDatabaseUtility.ExecuteQuery("[dbo].[GetTeamMembersList]", queryParameters);
            while (reader.Read() == true)
            {
                userList.Add(new UsersToBeTeam()
                {
                    id = reader.GetInt32(reader.GetOrdinal("id")),
                    userName = reader.GetString(reader.GetOrdinal("userName"))
                });
            }
            return userList;
        }

        public int GetTeamIdDA(int userId)
        {
            int teamId = 0;
            Dictionary<string, SqlParameter> queryParameters = new Dictionary<string, SqlParameter>();
            queryParameters["userId"] = new SqlParameter("userId", userId);

            try
            {
                SqlDataReader reader = SqlDatabaseUtility.ExecuteQuery("[dbo].[GetTeamID]", queryParameters);
                while (reader.Read() == true)
                {
                        teamId = reader.GetInt32(reader.GetOrdinal("teamId"));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }

            return teamId;
        }
        public int CreateTaskDA(Tasks task)
        {

            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["taskDetails"] = new SqlParameter("taskDetails", task.taskDetails);
            cmdParameters["taskAssignedDate"] = new SqlParameter("taskAssignedDate", task.taskAssignedDate);
            cmdParameters["taskEndDate"] = new SqlParameter("taskEndDate", task.taskEndDate);
            cmdParameters["responsibleUserId"] = new SqlParameter("responsibleUserId", task.responsibleUserId);
            int rc = SqlDatabaseUtility.ExecuteCommand("[dbo].[InsertTask]", cmdParameters);

            return rc;
        }

        public int DeleteTaskDA(int id)
        {

            Dictionary<string, SqlParameter> cmdParameters = new Dictionary<string, SqlParameter>();
            cmdParameters["id"] = new SqlParameter("id", id);
            int rc = SqlDatabaseUtility.ExecuteCommand("[dbo].[DeleteTask]", cmdParameters);

            return rc;
        }

    }
}
