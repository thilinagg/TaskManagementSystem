using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.DataAccess;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.CLI
{
    public class AccountCLI
    {
        public static string currentUser = "";
        public static int currentUserRole = 0;
        public static int currentUserID = 0;
        public void LoginCLI()
        {
            User user = new User();
            PasswordProtection pp = new PasswordProtection();
            AccountDA account = new AccountDA();

            Console.WriteLine("--------- Welcome |  Login the System to continue ----------");
            Console.WriteLine("");
            Console.WriteLine("User Name: ");
            user.userName = Console.ReadLine();
            Console.WriteLine("Password: ");
            user.password = pp.ReadPassword();

            var res = account.loginDA(user);
            currentUser = res.userName;
            currentUserRole = res.role;
            currentUserID = res.id;

            if(res.id > 0)
            {
                Console.WriteLine("successfully Login...!");
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Invalied Login Attempt...!");
            }

        }
    }
}
