using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ovning3.Vehicles;

namespace Ovning3.Vehicles;

internal class Truck : Vehicle, ICleanable
{
    public int CargoCapacity { get; set; }

    public Truck() : base()
    {

    }
    public Truck(string brand, string model, int year, double weight,int cap) : base(brand, model, year, weight)
    {
        CargoCapacity = cap;

    }

    public override string StartEngine()
    {
        return "Truck startEngine";
    }

    public string Clean()
    {
        return "Truck is Clean.";
    }

}
