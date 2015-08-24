using System;
using System.Security;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;

namespace ADFixer
{
    public class ReadAD
    {
    
        private string domainName;
        private string User;
        private string Password;
        private PrincipalContext ctx;

        public ReadAD()
        {
            Console.Write("Domain: ");
            domainName = Console.ReadLine();

            Console.Write("Username: ");
            User = Console.ReadLine();

            Console.Write("Password: ");
            Password = Console.ReadLine();

            ctx = new PrincipalContext(ContextType.Domain, domainName, User, Password);              

            Password = "";

        }

        public void ReadGroup()
        {
            // Group Principal Searcher Creation
            GroupPrincipal Access = new GroupPrincipal(ctx);

            PrincipalSearcher search = new PrincipalSearcher(Access);

            foreach (GroupPrincipal iter in search.FindAll())
            {
                Console.WriteLine("{0} - {1}", iter.SamAccountName, iter.Name);
            }

        }
    }
}