

public class Invoice {
    private decimal _TotalRenatlCost;
    private decimal _RenatlPrice;
    private decimal _TotalRentalInsurance;
    private int _ReservedDays;

    private decimal _RentalDiscount;
    private decimal _InsurancAddition;
    private decimal _DailyRentalCost;
    private decimal _InsuranceDiscount;
    private Vehicle _Vehicle;
    private Rental _Renatal;

    public Invoice(decimal totalRenatlCost, decimal totalRenatlPrice, decimal totalInsuranceCost, int reservedDays, decimal rentalDiscount, decimal insuranceAddition, decimal dailyRentalCost, decimal insuranceDiscount, Vehicle vehicle, Rental rental){
        _TotalRenatlCost = totalRenatlCost;
        _RenatlPrice = totalRenatlPrice;
        _TotalRentalInsurance = totalInsuranceCost;
        _ReservedDays = reservedDays;
        _RentalDiscount = rentalDiscount;
        _InsurancAddition = insuranceAddition;
        _DailyRentalCost = dailyRentalCost;
        _InsuranceDiscount = insuranceDiscount;
        _Vehicle = vehicle;
        _Renatal = rental;
    }
    public decimal GetInsuranceDiscount(){return _InsuranceDiscount;}
    public decimal GetInsurancAddition(){return _InsurancAddition;}
    public decimal GetTotalRentalInsurance(){return _TotalRentalInsurance;}
    
    public decimal GetRentalDiscount(){return _RentalDiscount;}

    public decimal GetDailyRentalCost() {return _DailyRentalCost;}
    public Vehicle GetVehicle(){return _Vehicle;}
    public Rental GetRenatal(){return _Renatal;}

    public int GetReservedDays(){return _ReservedDays;}

    internal decimal GetRenatlPrice()
    {
        return _RenatlPrice;
    }

    internal object GetTotalRenatlCost()
    {
        return _TotalRenatlCost;
    }
}