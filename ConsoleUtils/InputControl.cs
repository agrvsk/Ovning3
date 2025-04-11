namespace ConsoleUtils;

public class InputControl
{
/**
* @input Prompt
* @retur en ifylld sträng. 
**/
    public static string AskForString(string prompt)
    {
        do
        {
            Console.Write($"Ange {prompt}: ");
            string? retur = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(retur))
                return retur;

            Console.WriteLine("Felaktig input...");

        } while (true);
    }
    /*
     @input Prompt
     @retur En  int
     */
    public static int AskForInt(string prompt)
    {
        do
        {
            if (int.TryParse(AskForString(prompt), out int retur))
                return retur;

            Console.WriteLine("Felaktig input...");

        } while (true);
    }

    /*
     @input Prompt
     @retur En double
     */
    public static double AskForDouble(string prompt)
    {
        do
        {
            if (double.TryParse(AskForString(prompt), out double retur))
                return retur;

            Console.WriteLine("Felaktig input...");

        } while (true);
    }

    /*
     @input Prompt
     @retur En bool
     */
    public static bool AskForBool(string prompt)
    {
        do
        {
            if (bool.TryParse(AskForString(prompt), out bool retur))
                return retur;

            Console.WriteLine("Felaktig input...");

        } while (true);
    }

}
