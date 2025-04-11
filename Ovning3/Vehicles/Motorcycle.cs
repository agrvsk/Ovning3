using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ovning3.Vehicles;

internal class Motorcycle : Vehicle
{
    public bool HasSideCar { get; set; }

    public Motorcycle() : base()
    {

    }
    public Motorcycle(string brand, string model, int year, double weight, bool sidecar) : base(brand, model, year, weight)
    {
        HasSideCar = sidecar;
    }

    public override string StartEngine()
    {
        return "Motorcycle startEngine";
    }


}
