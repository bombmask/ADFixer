using System;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Diagnostics;
using System.Security;




namespace ADFixer
{
    class Program
    {
        static void Main(string[] args)
        {
            
            System.Windows.Forms.Application.Run(new mainform());
            

            //ADFixer.ReadAD NewAD = new ReadAD();

            //NewAD.ReadGroup();
            ////Exit Program
            //Console.WriteLine("Press Any Key To Exit...");
            //Console.ReadKey();

            
        }

        static void ReaadAD()
        {

            

            string groupName = "Domain Admins";

            Console.Write("Domain: ");
            string domainName = Console.ReadLine();
            Console.Write("Username: ");
            string User = Console.ReadLine();
            Console.Write("Password: ");
            string Password = Console.ReadLine();

            // Create Domain Context
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domainName, User, Password);

            Password = "";

            GroupPrincipal grp = GroupPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, groupName);

            if (grp != null)
            {
                foreach (Principal p in grp.GetMembers(false))
                {
                    Console.WriteLine(p.SamAccountName + " - " + p.DisplayName);
                }


                grp.Dispose();

                //Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\nWe did not find that group in that domain, perhaps the group resides in a different domain?");
                //Console.ReadLine();
            }

            // define a "query-by-example" principal - here, we search for a GroupPrincipal 
            
        
            UserPrincipal qbeGroup = new UserPrincipal(ctx);

            // create your principal searcher passing in the QBE principal    
            PrincipalSearcher srch = new PrincipalSearcher(qbeGroup);

            // find all matches
            foreach (UserPrincipal found in srch.FindAll())
            {
                
                Console.WriteLine(found.Name);

                foreach (GroupPrincipal g in found.GetGroups(ctx))
                {
                    Console.WriteLine("\t{0}", g.Name);
                }

                // do whatever here - "found" is of type "Principal" - it could be user, group, computer.....          
            }

            
        }
    }



    public class Example
    {
        public static void Test()
        {
            // Instantiate the secure string.
            SecureString securePwd = new SecureString();
            ConsoleKeyInfo key;

            Console.Write("Enter password: ");
            do
            {
                key = Console.ReadKey(true);

                // Ignore any key out of range. 
                if (((int)key.Key) >= 32 && ((int)key.Key <= 128))
                {
                    // Append the character to the password.
                    securePwd.AppendChar(key.KeyChar);
                    Console.Write("*");
                }
                // Exit if Enter key is pressed.
            } while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();

            try
            {
                Process.Start("Notepad.exe", "MyUser", securePwd, "MYDOMAIN");
            }
            catch (Win32Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

 

