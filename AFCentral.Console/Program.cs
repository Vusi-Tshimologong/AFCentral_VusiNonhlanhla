using System;

namespace AFCentral.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Please enter your name");

            var firstName = System.Console.ReadLine();
            
            System.Console.WriteLine("Please enter your surname");
            var surName = System.Console.ReadLine();


            System.Console.WriteLine("Please enter your Printer Code");
                            var printerCode = System.Console.ReadLine();

            DataAccess.SqlServerAccess ssa = new(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AFCentral;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            var msg = ssa.ConnectToDB(firstName, surName, printerCode);

            System.Console.WriteLine(msg);
        }
    }
}
