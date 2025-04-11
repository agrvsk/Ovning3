using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ovning3.Vehicles;

namespace Ovning3.Vehicles;

public class ElectricScooter : Vehicle
{
    public int BatteryRange { get; set; }

    public ElectricScooter() : base()
    {

    }
    public ElectricScooter(string brand, string model, int year, double weight,int range) : base(brand, model, year, weight)
    {
        BatteryRange = range;
    }
    public override string StartEngine()
    {
        return "ElectricScooter startEngine";
    }


}
