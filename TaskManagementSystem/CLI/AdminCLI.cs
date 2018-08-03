using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.DataAccess;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.CLI
{
    public class AdminCLI : LeadCLI
    {
        public void CreateUsersCLI()
        {
            User user = new User();
            AdminDA admin = new AdminDA();
            PasswordProtection pp = new PasswordProtection();
            ExcuteAdminCLI excute = new ExcuteAdminCLI();

            Console.WriteLine("");
            Console.WriteLine("+++ Add New User +++");
            Console.WriteLine("");

            Console.WriteLine("enter user name :");
            user.userName = Console.ReadLine();

            Console.WriteLine("enter user password :");
            user.password = pp.ReadPassword();

            Console.WriteLine("enter user role :");
            user.role = Int32.Parse(Console.ReadLine());

            Console.WriteLine("");
            Console.WriteLine("** press [Esc] to save and exit");
            Console.WriteLine("** press [1] to save and add new user");

            var k = Console.ReadKey(true);

            if (k.Key == ConsoleKey.Escape)
            {
                var msg = admin.CreateUsersDA(user);
                Console.WriteLine(msg);
                Console.Clear();
                excute.Header();
            }
            else if (k.Key == ConsoleKey.NumPad1 || k.Key == ConsoleKey.D1)
            {
                var mmsg = admin.CreateUsersDA(user);
                Console.WriteLine(mmsg);
                Console.Clear();
                excute.HeaderInfo();
                CreateUsersCLI();
            }
        }

        public void UpdateUserCLI()
        {
            User user = new User();
            AdminDA admin = new AdminDA();
            PasswordProtection pp = new PasswordProtection();
            ExcuteAdminCLI excute = new ExcuteAdminCLI();

            Console.WriteLine("");
            Console.WriteLine("+++ Update User Details +++");
            Console.WriteLine("");

            ViewUserCLI();

            Console.WriteLine("");
            Console.WriteLine("enter user id that want to change details :");
            user.id = Int32.Parse(Console.ReadLine());

            Console.WriteLine("enter user name :");
            user.userName = Console.ReadLine();

            Console.WriteLine("enter user password :");
            user.password = pp.ReadPassword();

            Console.WriteLine("enter user role :");
            user.role = Int32.Parse(Console.ReadLine());

            var msg = admin.UpdateUserDA(user);
            Console.WriteLine(msg);

            Console.Clear();
            excute.HeaderInfo();
            ViewUserCLI();

            Console.WriteLine("");
            Console.WriteLine("** press [Esc] back to menu");

            var k = Console.ReadKey(true);

            if (k.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                excute.Header();
            }
        }

        public void DeleteUserCLI()
        {
            User user = new User();
            AdminDA admin = new AdminDA();
            PasswordProtection pp = new PasswordProtection();
            ExcuteAdminCLI excute = new ExcuteAdminCLI();

            Console.WriteLine("");
            Console.WriteLine("+++ Delete User Details +++");
            Console.WriteLine("");

            ViewUserCLI();

            Console.WriteLine("");
            Console.WriteLine("enter user id that want to delete :");
            user.id = Int32.Parse(Console.ReadLine());


            var msg = admin.DeleteUserDA(user);
           

            Console.Clear();
            excute.HeaderInfo();
            Console.WriteLine("");
            Console.WriteLine(msg);
            Console.WriteLine("");
            ViewUserCLI();

            Console.WriteLine("");
            Console.WriteLine("** press [Esc] back to menu");

            var k = Console.ReadKey(true);

            if (k.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                excute.Header();
            }
        }

        public void CreateTeamCLI()
        {
            List<UserView> list = new List<UserView>();
            var res = 0;

            Team team = new Team();
            Team_User team_User = new Team_User();
            AdminDA admin = new AdminDA();
            ExcuteAdminCLI excute = new ExcuteAdminCLI();
            UserCLI userCLI = new UserCLI();

            Console.WriteLine("");
            Console.WriteLine("+++ Create New Team +++");
            Console.WriteLine("");

            Console.WriteLine("enter team name :");
            team.teamName = Console.ReadLine();

            var msg = admin.CreateTeamDA(team);

            if(msg== "team create successfully...!")
            {
                Console.Clear();
                excute.HeaderInfo();
                Console.WriteLine("+++ Now Add Users to the " + team.teamName + " +++");
                Console.WriteLine("");
                Console.WriteLine("Here the available team leaders list");
                Console.WriteLine("");
                ViewUserByRoleCLI(2);

                Console.WriteLine("");
                Console.WriteLine("+++ add team lead to team (enter user id)");
                team_User.userId = Int32.Parse(Console.ReadLine());

                list = admin.ViewUserByRoleDA(2);
                res = admin.CheckUserValiedOrNotDA(list, team_User.userId);
                if (res == -1)
                {
                    Console.WriteLine("The User is not a lead or already assigned a team --- Try Again");
                    Console.WriteLine("");
                    Console.WriteLine("+++ add team lead to team (enter user id)");
                    team_User.userId = Int32.Parse(Console.ReadLine());

                    list = admin.ViewUserByRoleDA(2);
                    res = admin.CheckUserValiedOrNotDA(list, team_User.userId);

                    if (res == -1)
                    {
                        Console.Clear();
                        excute.Header();
                    }
                    else
                    {
                        var mmsg = admin.AddUsersToTeamDA(team_User);
                        Console.WriteLine(mmsg);
                    }

                }
                else
                {
                    var mmsg = admin.AddUsersToTeamDA(team_User);
                    Console.WriteLine(mmsg);
                }

                Console.WriteLine("");

                Console.WriteLine("+++ add team members to team (enter user id)");

                Console.WriteLine("");
                Console.WriteLine("Here the available team Members list");
                Console.WriteLine("");
                ViewUserByRoleCLI(3);
                Console.WriteLine("");

                Console.WriteLine("Press [Enter] to assign a member");
                Console.WriteLine("");


                for (int i = 0; i < 20; i++)
                {
                    var kk = Console.ReadKey(true);
                    

                    if (kk.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        excute.Header();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("enter user id:");
                        team_User.userId = Int32.Parse(Console.ReadLine());

                        list = admin.ViewUserByRoleDA(3);
                        res = admin.CheckUserValiedOrNotDA(list, team_User.userId);
                        if (res == -1)
                        {
                            list = admin.ViewUserByRoleDA(2);
                            res = admin.CheckUserValiedOrNotDA(list, team_User.userId);
                            if (res != -1)
                            {
                                Console.WriteLine("The user cannot be assigned, The user is a team leader");
                                Console.WriteLine("--- press [Enter] to try again...");
                                Console.WriteLine("");
                            }
                            else
                            {
                                Console.WriteLine("The user cannot assigned, may be user is not availble");
                                Console.WriteLine("--- press [Enter] to try again...");
                                Console.WriteLine("");
                            }
                        }
                        else
                        {
                            var mmmsg = admin.AddUsersToTeamDA(team_User);
                            Console.WriteLine(mmmsg);
                            Console.WriteLine("Press [Enter] to assign an another member or press [Esc] exit and back to main menu");
                            Console.WriteLine("");
                        }
                    }
                }
            }

        }

        public void ViewUserByRoleCLI(int role)
        {
            AdminDA admin = new AdminDA();

            var list = admin.ViewUserByRoleDA(role);

            var markdownTable = list.ToMarkdownTable();
            Console.WriteLine(markdownTable);
        }

    }
}
