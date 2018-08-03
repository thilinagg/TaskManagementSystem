using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.DataAccess;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.CLI
{
    public class UserCLI
    {
        public void UpdatePasswordCLI()
        {
            User user = new User();
            UserDA userDA = new UserDA();
            PasswordProtection pp = new PasswordProtection();
            user.id = AccountCLI.currentUserID;

            Console.WriteLine("Enter your current password: ");
            user.password = pp.ReadPassword();
            Console.WriteLine("Enter Your New Password :");
            user.password = pp.ReadPassword();
            Console.WriteLine("Re-Enter your new password : ");
            var rePassword = pp.ReadPassword();

            if (user.password == rePassword)
            {
                var res = userDA.UpdatePasswordDA(user);
                Console.WriteLine(res);
            }
            else
            {
                Console.WriteLine("oops, password you entered did not match- try again...");
                Console.WriteLine("");
                UpdatePasswordCLI();
            }
        }
        public void ViewUserCLI()
        {
            User user = new User();
            AdminDA admin = new AdminDA();

            var list = admin.ViewUserDA();
            list = list.ToList();
            var markdownTable = list.ToMarkdownTable();
            Console.WriteLine(markdownTable);
        }

        public void ViewTaskListCLI()
        {
            UserDA user = new UserDA();
            List<Tasks> list = new List<Tasks>();

            if (AccountCLI.currentUserRole != 3)
            {
                list = user.ViewTaskDA(0);
            }
            else
            {
                list = user.ViewTaskDA(AccountCLI.currentUserID);
            }
            

            var markdownTable = list.ToMarkdownTable();
            Console.WriteLine(markdownTable);
        }

        public void UpdateStatusCLI()
        {
            UserDA user = new UserDA();
            Tasks task = new Tasks();

            Console.WriteLine("enter task id that you want to update status: ");
            task.id = Int32.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("enater updated status number: ");
            task.status = Int32.Parse(Console.ReadLine());

            int res = user.UpdateStatusDA(task);

            if (res == -1)
            {
                Console.WriteLine("status updated successfully...!");
            }
            else
            {
                Console.WriteLine("OOPs, something went wrong...!");
            }
        }
    }
}
