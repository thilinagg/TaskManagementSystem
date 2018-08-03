using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.CLI;
using TaskManagementSystem.DataAccess;

namespace TaskManagementSystem
{
    class Program
    {
        public static void Main(string[] args)
        {
            AccountCLI cli = new AccountCLI();
            cli.LoginCLI();

            if (AccountCLI.currentUserRole == 1)
            {
                ExcuteAdminCLI excute = new ExcuteAdminCLI();

                excute.Header();

            }
            else if (AccountCLI.currentUserRole == 3)
            {
                ExcuteNormalUser excute = new ExcuteNormalUser();

                excute.Header();

            }
            else
            {
                ExcuteLeadCLI excute = new ExcuteLeadCLI();

                excute.Header();
            }

            Console.ReadLine();

        }

    }
}
