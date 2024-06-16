using System;

public class RentalService : IRentalService {

   public decimal GetDailyRentalCost(int rentalDays, Vehicle vehicle){

        if(vehicle.GetVehicleType().Contains("car")){

            return rentalDays <= 7 ? 20 : 15;
        }

        else if(vehicle.GetVehicleType().Contains("Motorcycle")){

            return rentalDays <= 7 ? 15 : 10;
        }

        else
            return rentalDays <= 7 ? 50 : 40;
    
   }

   public decimal calculateInsurance(int rentalDays, Vehicle vehicle)
   {
        if(vehicle.GetVehicleType().Contains("car")){

            decimal baseRate = vehicle.GetValue() * 0.0001m;
            if (vehicle.GetSafetyRating() >= 4)
            {
                baseRate *= 0.9m;
            }

            return baseRate * rentalDays;
        }

        else if(vehicle.GetVehicleType().Contains("Motorcycle")){

            decimal baseRate = vehicle.GetValue() * 0.0002m;
            
            return baseRate * rentalDays;

        }
        else vehicle.GetVehicleType().Contains("Van");{

            decimal baseRate = vehicle.GetValue() * 0.003m;

            if (vehicle.GetDriver().GetDriverExperience() > 5) {
                return baseRate *= 0.85m;
            }

            return baseRate * rentalDays;

        }
   }

   public decimal CalculateRentalCost(Vehicle vehicle, Rental rental, decimal dailyRentalCost)
    {
        int reservedDays = (rental.GetEndDate() - rental.GetStartDate()).Days;
        int actualDays = (rental.GetActualReturnDate() - rental.GetStartDate()).Days;

        decimal totalRentalCost = dailyRentalCost * actualDays;

        if (actualDays < reservedDays)
        {
            int remainingDays = reservedDays - actualDays;
            totalRentalCost += dailyRentalCost * remainingDays * 0.5m;
        }

        return totalRentalCost;
    }

     public decimal CalculateInsuranceCost(Vehicle vehicle, Rental reantal)
    {
        int reservedDays = (reantal.GetEndDate() - reantal.GetStartDate()).Days;
        int actualDays = (reantal.GetActualReturnDate() - reantal.GetStartDate()).Days;

        decimal insuranceCost = calculateInsurance(actualDays, vehicle);

        if (actualDays < reservedDays)
        {
            insuranceCost += calculateInsurance((reservedDays - actualDays), vehicle) * 0.5m;
        }

        return insuranceCost;
    }

    public Invoice generateInvoiceData(Vehicle vehicle, Rental rental)
    {
        int dayesReserved = (rental.GetEndDate() - rental.GetStartDate()).Days;

        decimal dailyRentalCost = GetDailyRentalCost((rental.GetActualReturnDate() - rental.GetStartDate()).Days, vehicle);
        decimal rentalCost = CalculateRentalCost(vehicle, rental, dailyRentalCost);

        decimal insuranceCost = CalculateInsuranceCost(vehicle, rental);
        decimal insuranceAddition = CalculateInsuranceAddition(vehicle);
        
        
        decimal rentalDiscount = CalculateRentalDiscount(rental, dailyRentalCost,dayesReserved );
        decimal insuranceDiscount = CalculateInsuranceDiscount(insuranceCost, insuranceAddition, dayesReserved, rental);

        decimal totalRenatlCost = rentalCost + insuranceCost + insuranceAddition - insuranceDiscount;
        decimal totalInsuranceCost = insuranceCost + insuranceAddition - insuranceDiscount;

        Invoice invoice = new Invoice(totalRenatlCost,rentalCost, totalInsuranceCost, dayesReserved, rentalDiscount, insuranceAddition, dailyRentalCost, insuranceDiscount, vehicle, rental);

        return invoice;
    }

    private decimal CalculateInsuranceDiscount(decimal totalInsuranceCost, decimal insuranceAddition, int dayesReserved, Rental rental)
    {
        decimal insuranceDiscount = 0;
        decimal dailyInsuranceCost = (totalInsuranceCost/dayesReserved) + insuranceAddition;
        int actualRentalDays = (rental.GetActualReturnDate() - rental.GetStartDate()).Days;
        for (int i = actualRentalDays + 1; i <= dayesReserved; i++)
        {
            insuranceDiscount += dailyInsuranceCost;
        }

        return insuranceDiscount;
    }

    private decimal CalculateInsuranceAddition(Vehicle vehicle)
    {
        decimal value = vehicle.GetValue();
        if (vehicle.GetDriver().GetDriverAge() < 25)
            {
                return value *= 0.0004m;
            }
        return 0;
    }

    private decimal CalculateRentalDiscount(Rental rental, decimal dailyRentalCost, int dayesReserved)
    {
        decimal rentalDiscount = 0;
        int actualRentalDays = (rental.GetActualReturnDate() - rental.GetStartDate()).Days;

        for (int i = actualRentalDays + 1; i <= dayesReserved; i++)
        {
            rentalDiscount += dailyRentalCost / 2;
        }

        return rentalDiscount;
    }

    public void printInvoice(Invoice invoice){
            int actualRentalDays = (invoice.GetRenatal().GetActualReturnDate() - invoice.GetRenatal().GetStartDate()).Days;
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine($"  Date:                                  {DateTime.Now:yyyy-MM-dd}");
            Console.WriteLine($"  Customer Name:                         {invoice.GetVehicle().GetDriver().GetDriverName()}");
            Console.WriteLine($"  Rented Vehicle:                        {invoice.GetVehicle().GetVehicleMark()} {invoice.GetVehicle().GetVehicleModel()}");
            Console.WriteLine();
            Console.WriteLine($"  Reservation Start Date:                {invoice.GetRenatal().GetStartDate():yyyy-MM-dd}");
            Console.WriteLine($"  Reservation End Date:                  {invoice.GetRenatal().GetEndDate():yyyy-MM-dd}");
            Console.WriteLine($"  Reserved rental days:                  {invoice.GetReservedDays()} days");
            Console.WriteLine();
            Console.WriteLine($"  Actual Return Date:                    {invoice.GetRenatal().GetActualReturnDate():yyyy-MM-dd}");
            Console.WriteLine($"  Actual Rental Days:                    {(invoice.GetRenatal().GetActualReturnDate() - invoice.GetRenatal().GetStartDate()).Days} days");
            Console.WriteLine();
            Console.WriteLine($"  Rental Cost Per Day:                   ${invoice.GetDailyRentalCost():F2}");
            if (invoice.GetRentalDiscount() > 0)
            {
                Console.WriteLine($"  Early Return Discount For Rent:        ${invoice.GetRentalDiscount():F2}");
            }

            Console.WriteLine($"  Insurance Per Day:                     ${(invoice.GetTotalRentalInsurance() - invoice.GetInsurancAddition()) / actualRentalDays:F2}");
            if (invoice.GetVehicle().GetDriver().GetDriverAge() < 25)
            {
                Console.WriteLine($"  Initial Insurance Per Day:             ${invoice.GetTotalRentalInsurance() / invoice.GetReservedDays():F2}");
                Console.WriteLine($"  Insurance Addition Per Day:            ${invoice.GetInsurancAddition() / invoice.GetReservedDays():F2}");
                Console.WriteLine($"  Insurance Per Day:                     ${invoice.GetTotalRentalInsurance()  / invoice.GetReservedDays():F2}");
            }
            if (invoice.GetVehicle().GetDriver().GetDriverExperience() > 5)
            {
                Console.WriteLine($"  Early Return Discount For Insurance:   ${invoice.GetInsuranceDiscount():F2}");
            }
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine($"  Total Rent:                            ${invoice.GetRenatlPrice():F2}");
            Console.WriteLine($"  Total Insurance:                       ${invoice.GetTotalRentalInsurance():F2}");
            Console.WriteLine();
            Console.WriteLine($"  Total:                                 ${invoice.GetTotalRenatlCost():F2}");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine();

}
}
