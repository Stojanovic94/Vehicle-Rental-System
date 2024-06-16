using System;
public class Rental {

    private Vehicle _Vehicle;
    private DateTime _StartDate;
    private DateTime _EndDate;
    private DateTime _ActualReturnDate;

     public Rental (Vehicle vehicle, DateTime startDate, DateTime endDate, DateTime actulaRentalDate){
        _Vehicle = vehicle;
        _StartDate = startDate;
        _EndDate = endDate;
        _ActualReturnDate = actulaRentalDate;
    }

    public Vehicle GetVehicle(){ return _Vehicle;}
    public DateTime GetStartDate(){ return _StartDate;}
    public DateTime GetEndDate(){ return _EndDate;}
    public DateTime GetActualReturnDate(){ return _ActualReturnDate;}


}