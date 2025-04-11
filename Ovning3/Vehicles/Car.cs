using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ovning3.Vehicles;

namespace Ovning3.Vehicles;

public class Car : Vehicle, ICleanable
{
    public bool Dragkrok { get; set; } 


    public Car() : base()
    {

    }
    public Car(string brand, string model, int year, double weight, bool krok) : base(brand,model,year,weight)
    {
        Dragkrok = krok;
    }

    public override string StartEngine()
    {
        return "Car startEngine";
    }

    public string Clean()
    {
        return "Car is Clean.";
    }


}
