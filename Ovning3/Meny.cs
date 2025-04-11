using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

using Ovning3.Errors;
using Ovning3.Vehicles;

namespace Ovning3;

public class Meny
{
    //Menyalternativen.
    public const char EXIT1 = 'X';
    public const char EXIT2 = 'x';
    public const char ETT = '1';
    public const char TVA = '2';
    public const char TRE = '3';
    public const char FYRA = '4';
    public const char FEM = '5';

    //kommer att innehålla en privat instans av VehicleHandler.
    //private VehicleHandler handler;

    //privat lista för intern lagring av SystemError instanser.
    public List<SystemError> Errors { get; private set; }

    public VehicleHandler Handler { get; private set; }

    public Meny()
    {
        //Instansierar följande varje gång en Menyinstans skapas:
        Handler = new VehicleHandler();
        Errors = new List<SystemError>();

        //Seedar in data i errors.
        InitErrors();

        //Seedar in lite data Vehicles
        Handler.CreateVehicles();
    }

    public void InitErrors()
    {
        Errors.Add(new BrakeFailureError());
        Errors.Add(new EngineFailureError());
        Errors.Add(new TransmissionError());
    }


    public void StartMeny()
    {
        bool avbryt = false;
        do
        {
            Console.WriteLine("-----------");
            Console.WriteLine("HUVUDMENY");
            Console.WriteLine("-----------");
            Console.WriteLine($"{ETT}. Skapa ett Vehicle. ");
            Console.WriteLine($"{TVA}. Ändra ett Vehicle. ");
            Console.WriteLine($"{TRE}. Visa alla ({Handler.GetVehicleCount()}) Vehicles. ");
            Console.WriteLine($"{FYRA}. Starta alla ({Handler.GetVehicleCount()}) Vehicles. ");
            Console.WriteLine($"{FEM}. Visa Errors. ");
            Console.WriteLine($"{EXIT1}. Avsluta. ");

            Console.WriteLine();
            Console.Write("Ange val:");
            ConsoleKeyInfo keyinfo = Console.ReadKey();
            Console.WriteLine();

            //Console.Clear();
            switch (keyinfo.KeyChar)
            {
                case ETT:
                    Handler.CreateVehicle();
                    break;

                case TVA:
                    Handler.UpdateVehicle();
                    break;

                case TRE:
                    Handler.ListVehicles();
                    break;

                case FYRA:
                    Handler.RunVehicles();
                    break;

                case FEM:
                    PrintErrorMessages();
                    break;

                case EXIT1:
                case EXIT2:
                    avbryt = true;
                    break;

                default:
                    Console.WriteLine($"{Environment.NewLine}Felaktigt val.");
                    break;

            }
            if (!avbryt)
            {
                Wait();
                Console.Clear();
            }
        } while (!avbryt);
    }

    //För att hinna läsa på skärmen innan vi gör Clear av Conolen.
    private static void Wait()
    {
        Console.WriteLine($"{Environment.NewLine}Press any key to continue...");
        Console.ReadKey();
    }

    //Skriver ut ErrorMessage från alla instanser i errorlistan.
    private void PrintErrorMessages()
    {
        Console.WriteLine("");
        foreach (SystemError error in Errors)
        {
            Console.WriteLine(error.ErrorMessage());
        }
    }


}
