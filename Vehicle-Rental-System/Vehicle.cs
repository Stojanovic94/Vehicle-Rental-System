using System;

public class Vehicle
{
    private string _VehicleType { get; set; }
    private string _VehicleMark { get; set; }
    private string _VehicleModel {get; set;}
    private decimal _Value { get; set; }
    private int _SafetyRating {get; set;}
    private Driver _Driver {get; set;}

    public Vehicle(string vehicleType, string vehicleMark, string vehicleModel, decimal value, int safetyRating, Driver driver)
    {
        _VehicleType = vehicleType;
        _VehicleMark  = vehicleMark;
        _VehicleModel = vehicleModel;
        _Value  = value;
        _SafetyRating = safetyRating;
        _Driver = driver;
        
    }

    public string GetVehicleType()
    {
        return _VehicleType;
    }

    public string GetVehicleMark()
    {
        return _VehicleMark;
    }
    public string GetVehicleModel()
    {
        return _VehicleModel;
    }
    public decimal GetValue()
    {
        return _Value;
    }
    public int GetSafetyRating()
    {
        return _SafetyRating;
    }
    public Driver GetDriver()
    {
        return _Driver;
    }

}