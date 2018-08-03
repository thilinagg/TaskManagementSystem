using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.DataAccess;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.CLI
{
    public class LeadCLI : UserCLI
    {
        public void ViewTeamListCLI()
        {
            LeadDA lead = new LeadDA();

            var list = lead.ViewTeamListDA();

            var markdownTable = list.ToMarkdownTable();
            Console.WriteLine(markdownTable);
        }

        public void ViewTeamMembersCLI(int teamId)
        {
            LeadDA lead = new LeadDA();

            var list = lead.ViewTeamMembersDA(teamId);

            var markdownTable = list.ToMarkdownTable();
            Console.WriteLine(markdownTable);
        }

        public void CreateTaskCLI()
        {
            ExcuteAdminCLI excute = new ExcuteAdminCLI();
            Team team = new Team();
            Tasks task = new Tasks();
            LeadDA lead = new LeadDA();


            Console.WriteLine("+++ Create Task and Assign it to User");
            Console.WriteLine("");

            if (AccountCLI.currentUserRole == 1)
            {
                Console.WriteLine("Here is the current team list");
                Console.WriteLine("");
                ViewTeamListCLI();
                Console.WriteLine("");
                Console.WriteLine("Select a Team: ");
                team.teamId = Int32.Parse(Console.ReadLine());

                Console.WriteLine("");
                Console.WriteLine("Here is the members list selected team...");
                Console.WriteLine("");
                ViewTeamMembersCLI(team.teamId);
                Console.WriteLine("");
                Console.WriteLine("Select a user to assign a task: ");
                task.responsibleUserId = Int32.Parse(Console.ReadLine());

                Console.WriteLine("");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("Specify the task details: ");
                task.taskDetails = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("Task end date (DD-MM-YYYY) :");
                task.taskEndDate = Console.ReadLine();
                Console.ReadLine();

                DateTime date = new DateTime();
                task.taskAssignedDate = date.ToShortDateString().ToString();
                int res = lead.CreateTaskDA(task);

                if (res == -1)
                {
                    Console.WriteLine("task create successfully...!");
                }
                else
                {
                    Console.WriteLine("OOPs, something went wrong...!");
                }
            }

            else
            {
                int teamId = lead.GetTeamIdDA(AccountCLI.currentUserID);
                if(teamId != 0)
                {
                    Console.WriteLine("Here is the members list of Your team...");
                    Console.WriteLine("");
                    ViewTeamMembersCLI(teamId);
                    Console.WriteLine("");
                    Console.WriteLine("Select a user to assign a task: ");
                    task.responsibleUserId = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("");
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine("");
                    Console.WriteLine("Specify the task details: ");
                    task.taskDetails = Console.ReadLine();
                    Console.WriteLine("");
                    Console.WriteLine("Task end date (DD-MM-YYYY) :");
                    task.taskEndDate = Console.ReadLine();
                    Console.ReadLine();

                    DateTime date = new DateTime();
                    task.taskAssignedDate = date.ToShortDateString();
                    int res = lead.CreateTaskDA(task);

                    if (res == -1)
                    {
                        Console.WriteLine("task create successfully...!");
                    }
                    else
                    {
                        Console.WriteLine("OOPs, something went wrong...!");
                    }
                }
                else
                {
                    Console.WriteLine("Sorry you don't have a team yet, Contact your administator...");
                }
            }
        }

        public void DeleteTaskCLI()
        {
            LeadDA lead = new LeadDA();

            Console.WriteLine("Enter Task id which you want to delete: ");
            var id= Int32.Parse(Console.ReadLine());

            int res = lead.DeleteTaskDA(id);

            if (res == -1)
            {
                Console.WriteLine("task delete successfully...!");
            }
            else
            {
                Console.WriteLine("OOPs, something went wrong...!");
            }
        }
    }
}
