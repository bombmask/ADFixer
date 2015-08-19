using System;
using System.DirectoryServices.ActiveDirectory;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADFixer
{
    class Program
    {
        static void Main(string[] args)
        {
            const long total = 10000;
            
            Console.WriteLine("Press go?");
            Console.ReadKey();

            ulong calc = 1;
            for (uint i = (uint)total; i > 1; i--) { calc *= i; }

            Console.Write("{0}\n", calc);
            //Exit Program
            Console.WriteLine("Press Any Key To Exit...");
            Console.ReadKey();

            
        }

        //static void DoStuff()
        //{
        //    string groupName = "Domain Users";
        //    string domainName = "";

        //    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domainName);
        //    GroupPrincipal grp = GroupPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, groupName);

        //    if (grp != null)
        //    {
        //        foreach (Principal p in grp.GetMembers(false))
        //        {
        //            Console.WriteLine(p.SamAccountName + " - " + p.DisplayName);
        //        }


        //        grp.Dispose();
        //        ctx.Dispose();
        //        Console.ReadLine();
        //    }
        //    else
        //    {
        //        Console.WriteLine("\nWe did not find that group in that domain, perhaps the group resides in a different domain?");
        //        Console.ReadLine();
        //    }
        //}
    }
}

 

