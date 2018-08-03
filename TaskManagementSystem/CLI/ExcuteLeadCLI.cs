﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.CLI
{
    public class ExcuteLeadCLI
    {
        LeadCLI lead = new LeadCLI();
        public void HeaderInfo()
        {
            Console.WriteLine("---------- Task Management System   ||   Welcome " + AccountCLI.currentUser + " ----------");
            Console.WriteLine("");
        }

        public void Header()
        {
            HeaderInfo();

            Console.WriteLine("Use the following command to Continue ... ");
            Console.WriteLine("");
            Console.WriteLine("\t[1]  View your task List");
            Console.WriteLine("\t[2]  Create a task");
            Console.WriteLine("\t[3]  Delete list");
            Console.WriteLine("\t[4]  Change Password");
            Console.WriteLine("\t[Esc]  Log Out");

            var k = Console.ReadKey(true);

            if (k.Key == ConsoleKey.NumPad1 || k.Key == ConsoleKey.D1)
            {
                Console.Clear();
                HeaderInfo();
                Console.WriteLine("");
                Console.WriteLine("\t+++ Tasks List");
                Console.WriteLine("");
                lead.ViewTaskListCLI();

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

            else if (k.Key == ConsoleKey.NumPad2 || k.Key == ConsoleKey.D2)
            {
                Console.Clear();
                HeaderInfo();
                Console.WriteLine("");
                Console.WriteLine("\tCreate a task");
                Console.WriteLine("");
                lead.CreateTaskCLI();

                Console.WriteLine("");
                Console.WriteLine("Press [Esc] Back to Menu ...");

                var kk = Console.ReadKey(true);
                if (kk.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Header();
                }

            }

            else if (k.Key == ConsoleKey.NumPad3 || k.Key == ConsoleKey.D3)
            {
                Console.Clear();
                HeaderInfo();
                Console.WriteLine("");
                Console.WriteLine("\t+++ Delete List");
                Console.WriteLine("");
                lead.ViewTaskListCLI();

                Console.WriteLine("");
                Console.WriteLine("--- Status ---");
                Console.WriteLine("1 - Not yet Started");
                Console.WriteLine("2 - In Pogress");
                Console.WriteLine("3 - Done");

                Console.WriteLine("");
                lead.DeleteTaskCLI();
                Console.WriteLine("");
                Console.WriteLine("Press [Esc] Back to Menu ...");

                var kk = Console.ReadKey(true);
                if (kk.Key == ConsoleKey.Escape)
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
                Console.WriteLine("\t+++ Change your password");
                Console.WriteLine("");
                lead.UpdatePasswordCLI();


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
