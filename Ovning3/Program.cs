using System;
using Ovning3.Errors;

namespace Ovning3;

public class Program
{
    static void Main()
    {
        try
        {
            Meny meny =  new Meny();
            meny.StartMeny();
        }
        catch (Exception e)
        {
            Console.WriteLine( e.Message );
        }
    }
}
