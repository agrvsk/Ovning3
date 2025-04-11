using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ovning3.Vehicles;

public abstract class Vehicle
{
    //Initierar strängarna för att slippa varningar.
    public const string UNSPECIFIED = "UNSPECIFIED";

    private string brand = UNSPECIFIED;
    private string model = UNSPECIFIED;
    private int year;
    private double weight;

    public string Brand
    {
        get { return brand; }
        set 
        {
            ValidateLength_2_20("Brand",  value);
            brand = value; 
        }
    }


    public string Model
    {
        get { return model; }
        set 
        {
            ValidateLength_2_20("Model", value);
            model = value; 
        }
    }
    public int Year
    {
        get { return year; }
        set 
        {
            if (value < 1886 || value > DateTime.Now.Year )
                throw new ArgumentException($"Year måste vara mellan 1886 och {DateTime.Now.Year}!");
            year = value; 
        }
    }
    public double Weight
    {
        get { return weight; }
        set 
        { 
            if(value < 0.0)
                throw new ArgumentException($"Weight ska vara ett positivt tal!");
            weight = value; 
        }
    }

    public Vehicle()
    {

    }

    public Vehicle(string brand, string model, int year, double weight)
    {
        Brand = brand;
        Model = model;
        Year = year;
        Weight = weight;
    }

    private static void ValidateLength_2_20(string name, string value)
    {
        if (value == null || value.Trim().Length < 2 || value.Trim().Length > 20)
            throw new ArgumentException($"{name} måste vara mellan 2 och 20 tecken!");
    }


    public override string ToString()
    {
        return $"{Brand.PadRight(20,' ')} {Model.PadRight(20,' ')} {Year} {Weight}";
    }


    public virtual string StartEngine()
    {
        return "Vehicle startEngine";
    }

    public string Stats()
    {
        return ToString();
    }


}
