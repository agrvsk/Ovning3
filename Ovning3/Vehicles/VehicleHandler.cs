using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using ConsoleUtils;

namespace Ovning3.Vehicles;

public class VehicleHandler
{
    //privat lista för att lagra instanser av Vehicle.
    public List<Vehicle> Vehicles { get; private set; }

    //Används som menyalternativ nedan.
    private enum FordonsVal
    {
        Car,
        ElectricScooter,
        MotorCycle,
        Truck
    };

    public VehicleHandler()
    {
        Vehicles = new List<Vehicle>();
    }
    public int GetVehicleCount()
    {
        return Vehicles.Count;
    }


    public void CreateVehicle()
    {
        Console.WriteLine();
        //Lät användaren bestämma vilken typ av fordon som ska skapas
        Console.WriteLine("------------------------------");
        Console.WriteLine("Ange önskad fordonstyp:");
        foreach (FordonsVal fordon in Enum.GetValues<FordonsVal>())
            Console.WriteLine($"{((int)fordon)} {fordon}");
        Console.WriteLine("------------------------------");

        Vehicle? vehicle = null;

        do
        {
            Console.Write("Välj fordonstyp:");
            ConsoleKeyInfo test = Console.ReadKey();
            Console.WriteLine();

            if (FordonsVal.TryParse(test.KeyChar.ToString(), out FordonsVal retur))
            {
                switch (retur)
                {
                    case FordonsVal.Car:
                        vehicle = new Car();
                        Console.WriteLine("Ange properties för Car...");
                        break;

                    case FordonsVal.MotorCycle:
                        Console.WriteLine("Ange properties för MotorCycle...");
                        vehicle = new Motorcycle();
                        break;

                    case FordonsVal.Truck:
                        vehicle = new Truck();
                        Console.WriteLine("Ange properties för Truck...");

                        break;
                    case FordonsVal.ElectricScooter:
                        vehicle = new ElectricScooter();
                        Console.WriteLine("Ange properties för ElectricScooter...");
                        break;

                    default:
                        Console.WriteLine("Menyalternativet har inte implementerats?!");
                        break;
                }
                //break;
            }
        } while (vehicle == null);

        Console.WriteLine("------------------------------");

        //Fyller i properties för den typ av vehicle som instansierades ovan.
        do
        {
            try
            {
                //Frågar endast efter de som inte redan har fyllts i.
                //Valideringen av properties sker i Vehicle...
                if (vehicle.Brand == Vehicle.UNSPECIFIED)
                    vehicle.Brand = InputControl.AskForString("Brand");

                if (vehicle.Model == Vehicle.UNSPECIFIED)
                    vehicle.Model = InputControl.AskForString("Model");

                if (vehicle.Year == 0)
                    vehicle.Year = InputControl.AskForInt("Year");

                if (vehicle.Weight == 0)
                    vehicle.Weight = InputControl.AskForDouble("Weight");

                //Så alla de olika typernas unika properties.
                switch (vehicle)
                {
                    case Truck:
                        if (((Truck)vehicle).CargoCapacity == 0)
                            ((Truck)vehicle).CargoCapacity = InputControl.AskForInt("CargoCapacity");
                        break;


                    case ElectricScooter:
                        if (((ElectricScooter)vehicle).BatteryRange == 0)
                            ((ElectricScooter)vehicle).BatteryRange = InputControl.AskForInt("BatteryRange");
                        break;


                    case Car:
                        ((Car)vehicle).Dragkrok = InputControl.AskForBool("Dragkrok [true|false]");
                        break;


                    case Motorcycle:
                        ((Motorcycle)vehicle).HasSideCar = InputControl.AskForBool("Sidovagn [true|false]");
                        break;

                    default:
                        Console.WriteLine("Menyalternativet har inte implementerats?!");
                        break;
                }

                //Kommer vi hit så är allt korrekt ifyllt!
                break;

            }
            catch (Exception e) //Meddelar anvöndare vid felaktig input.
            {
                Console.WriteLine(e.Message);
            }

        } while (true); //Fortsätter loopa tills allt är korrekt ifyllt.

        Vehicles.Add(vehicle);
    }
    public void CreateVehicles()
    {
        //Svar på fråga:
        //List<Motorcycle> mc = new List<Motorcycle>();
        //mc.Add(new Car("BMW", "M2 Coupé", 2023, 1500, true));
        //Ovanstående ger Kompileringsfel, Cannot convert from Car to MotorCycle.

        //För att rymma alla fordonstyper ska listan byggas på toppen av arvshierarkin.
        //i detta fall på Vehicle som alla fordon ärver ifrån.
        //- En lista av Object sväljer allt (men då måste man casta för att kunna använda metoderna)
        //Ännu bättre kan vara att bygga listan på ett interface som alla objekt i listan implementerar.

        //Seeding values
        Vehicles.Add(new Car("BMW", "M2 Coupé", 2023, 1234, true));
        Vehicles.Add(new ElectricScooter("Xiaomi", "4 Lite IT", 2020, 120, 50));
        Vehicles.Add(new Truck("Scania", "P 360", 1990, 5200, 2000));
        Vehicles.Add(new Car("Renault", "Clio", 2011, 1000, true));
        Vehicles.Add(new Motorcycle("Harley-Davidson", "Touring", 1990, 100, false));
        Vehicles.Add(new Car("Volvo", "Amazon", 1961, 1500, false));

        //FÖLJANDE GER ERRORS:
        //Vehicle v2 = new Car("X", "Model", 1990, 1500, true);
        //Vehicle v3 = new Car("XXX", "Model", 2027, 1500);
    }

    public Vehicle? SelectVehicle()
    {
        if (Vehicles.Count == 0) return null;

        //Visa rader så användaren kan välja vilken rad som ska ändras...
        ListVehicles();
        Console.WriteLine("----------");
        do
        {
            int iVal = InputControl.AskForInt($"rad att ändra[0-{Vehicles.Count - 1}]");

            if (iVal >= 0 && iVal <= Vehicles.Count - 1)
            {
                return Vehicles.ElementAt(iVal);
            }
            Console.WriteLine("Felaktigt radnummer, försök igen...");
        } while (true); //Loopar tills vi fått ett korrekt radnummer.
    }



    public void UpdateVehicle()
    {
        Vehicle? vehicle = SelectVehicle();
        if(vehicle == null) return;
        Console.WriteLine();
        Console.WriteLine("Före ändring: "+vehicle);
        do
        {
            try
            {
                //Just nu är det Brand vi kan ändra...
                vehicle.Brand = InputControl.AskForString("Brand");

                //bryter loopen när allt fyllts i.
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        } while (true); //Loopar tills vehicle är korrekt ifylld.
        Console.WriteLine("Efter ändring: " + vehicle);

    }



    public void ListVehicles()
    {
        Console.WriteLine("----------");
        Console.WriteLine("VEHICLES");
        Console.WriteLine("----------");
        foreach (var vehicle in Vehicles)
        {
            Console.WriteLine(vehicle);
        }

    }
    public void RunVehicles()
    {
        Console.WriteLine("----------");
        Console.WriteLine("START VEHICLES");
        Console.WriteLine("----------");
        foreach (var vehicle in Vehicles)
        {
            Console.WriteLine(vehicle.Stats());
            Console.WriteLine(vehicle.StartEngine());

            //Svar på fråga:
            //Vehicle implementerar inte ICleanable så vi kommer inte åt .Clean() härifrån.
            //Vi kan bara ärva från EN klass, men vi kan implementera flera interface.
            //Vi kan lägga till funktionalitet utan att arvhierarkin behöver ändras.

            if (vehicle is ICleanable)
                Console.WriteLine(((ICleanable)vehicle).Clean());

            Console.WriteLine("");
        }

    }


}
