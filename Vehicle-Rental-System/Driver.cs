using System;

public class Driver {

    private int _DriverAge;
    private int _DriverExperience;
    private string _DriverName;

     public Driver (int driverAge, int driverExperience, string driverName){
        _DriverAge = driverAge;
        _DriverExperience = driverExperience;
        _DriverName = driverName;
    }

    public int GetDriverAge(){
        return _DriverAge;
    }

    public int GetDriverExperience(){
        return _DriverExperience;
    }

    public string GetDriverName(){
        return _DriverName;
    }
}