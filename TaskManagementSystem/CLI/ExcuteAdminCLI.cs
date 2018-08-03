using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.CLI
{
    public class ExcuteAdminCLI
    {
        AdminCLI admin = new AdminCLI();

        public void HeaderInfo()
        {
            Console.WriteLine("---------- Task Management System  ||  Welcome " + AccountCLI.currentUser + " ----------");
            Console.WriteLine("");
        }

        public void Header()
        {
            HeaderInfo();

            Console.WriteLine("Use the following command to Continue ... ");
            Console.WriteLine("");
            Console.WriteLine("\t[1]  Create/ Update/ Delete Users");
            Console.WriteLine("\t[2]  View Users List");
            Console.WriteLine("\t[3]  Create New Team");
            Console.WriteLine("\t[4]  Create a Task");
            Console.WriteLine("\t[5]  view Task List");
            Console.WriteLine("\t[6]  Delete Task");
            Console.WriteLine("\t[Esc]  Log Out");

            var k = Console.ReadKey(true);

            if (k.Key == ConsoleKey.NumPad1 || k.Key == ConsoleKey.D1)
            {
                Console.Clear();
                HeaderInfo();
                Console.WriteLine("");
                Console.WriteLine("\t[5]  Create New User");
                Console.WriteLine("\t[6]  Update Existing User");
                Console.WriteLine("\t[7]  Delete a User");
                Console.WriteLine("\t[Esc]  Back to Menu");

                var kk = Console.ReadKey(true);
                if (kk.Key == ConsoleKey.NumPad5 || kk.Key == ConsoleKey.D5)
                {
                    Console.Clear();
                    HeaderInfo();
                    admin.CreateUsersCLI();
                }
                else if(kk.Key == ConsoleKey.NumPad6 || kk.Key == ConsoleKey.D6)
                {
                    Console.Clear();
                    HeaderInfo();
                    admin.UpdateUserCLI();
                }
                else if (kk.Key == ConsoleKey.NumPad7 || kk.Key == ConsoleKey.D7)
                {
                    Console.Clear();
                    admin.DeleteUserCLI();
                }
                else
                {
                    Console.Clear();
                    Header();
                }
            }
            else if(k.Key == ConsoleKey.NumPad2 || k.Key == ConsoleKey.D2)
            {
                Console.Clear();
                HeaderInfo();
                Console.WriteLine("");
                Console.WriteLine("\tUsers List");
                Console.WriteLine("");
                admin.ViewUserCLI();

                Console.WriteLine("");
                Console.WriteLine("Press [Esc] Back to Menu ...");

                var kk = Console.ReadKey(true);
                if (kk.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Header();
                }

            }

            else if(k.Key == ConsoleKey.NumPad3 || k.Key == ConsoleKey.D3)
            {
                Console.Clear();
                HeaderInfo();
                Console.WriteLine("");
                Console.WriteLine("\t[5]  Create New Team");
                Console.WriteLine("\t[6]  View Team Details");
                Console.WriteLine("\t[Esc]  Back to Menu");

                var kk = Console.ReadKey(true);
                if (kk.Key == ConsoleKey.NumPad5 || kk.Key == ConsoleKey.D5)
                {
                    Console.Clear();
                    HeaderInfo();
                    admin.CreateTeamCLI();
                }
                else if (kk.Key == ConsoleKey.NumPad6 || kk.Key == ConsoleKey.D6)
                {
                    Console.Clear();
                    HeaderInfo();
                    Console.WriteLine("+++ Team List");
                    Console.WriteLine("");
                    admin.ViewTeamListCLI();
                    Console.WriteLine("");
                    Console.WriteLine("Press [Esc] Back to Menu ...");

                    var kkk = Console.ReadKey(true);
                    if (kkk.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Header();
                    }
                }
                else if (kk.Key == ConsoleKey.NumPad7 || kk.Key == ConsoleKey.D7)
                {
                    Console.Clear();
                    admin.DeleteUserCLI();
                }
                else
                {
                    Console.Clear();
                    Header();
                }
            }

            else if (k.Key == ConsoleKey.NumPad4 || k.Key == ConsoleKey.D4)
            {
                Console.Clear();
                HeaderInfo();
                Console.WriteLine("");
                Console.WriteLine("\tCreate a task");
                Console.WriteLine("");
                admin.CreateTaskCLI();

                Console.WriteLine("");
                Console.WriteLine("Press [Esc] Back to Menu ...");

                var kk = Console.ReadKey(true);
                if (kk.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Header();
                }

            }

            else if (k.Key == ConsoleKey.NumPad5 || k.Key == ConsoleKey.D5)
            {
                Console.Clear();
                HeaderInfo();
                Console.WriteLine("");
                Console.WriteLine("\t+++ Tasks List");
                Console.WriteLine("");
                admin.ViewTaskListCLI();

                Console.WriteLine("");
                Console.WriteLine("--- Status ---");
                Console.WriteLine("1 - Not yet Started");
                Console.WriteLine("2 - In Pogress");
                Console.WriteLine("3 - Done");

                Console.WriteLine("");
                Console.WriteLine("Press [Esc] Back to Menu ...");

                var kk = Console.ReadKey(true);
                if (kk.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Header();
                }

            }

            else if (k.Key == ConsoleKey.NumPad6 || k.Key == ConsoleKey.D6)
            {
                Console.Clear();
                HeaderInfo();
                Console.WriteLine("");
                Console.WriteLine("\t+++ Delete List");
                Console.WriteLine("");
                admin.ViewTaskListCLI();

                Console.WriteLine("");
                Console.WriteLine("--- Status ---");
                Console.WriteLine("1 - Not yet Started");
                Console.WriteLine("2 - In Pogress");
                Console.WriteLine("3 - Done");

                Console.WriteLine("");
                admin.DeleteTaskCLI();
                Console.WriteLine("");
                Console.WriteLine("Press [Esc] Back to Menu ...");

                var kk = Console.ReadKey(true);
                if (kk.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Header();
                }

            }
            else
            {
                string[] arr = new string[2];
                AccountCLI.currentUser = "";
                AccountCLI.currentUserID = 0;
                AccountCLI.currentUserRole = 0;
                Console.Clear();
                Program.Main(arr);               
            }

        }


    }
}
