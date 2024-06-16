using System;
using System.Runtime.ConstrainedExecution;

class Program
{
    static void Main()
    {
        IRentalService reantalService = new RentalService();
        
        Driver driver = new Driver(30, 5, "John Doe");
        Vehicle car = new Vehicle("car", "Mitsubishi", "Mirage", 15000, 3, driver);
        Rental rental = new Rental(car, DateTime.Parse("2024-06-03"), DateTime.Parse("2024-06-13"), DateTime.Parse("2024-06-13"));
        
        Invoice invoice = reantalService.generateInvoiceData(car, rental);
        reantalService.printInvoice(invoice);

        Driver driver1 = new Driver(20, 5, "Mary Johnson");
        Vehicle moto = new Vehicle("Motorcycle", "Triumph", "Tiger Sport 660", 10000, 3, driver1);
        Rental rental1 = new Rental(moto, DateTime.Parse("2024-06-03"), DateTime.Parse("2024-06-13"), DateTime.Parse("2024-06-13"));

        Invoice invoice1 = reantalService.generateInvoiceData(moto, rental1);
        reantalService.printInvoice(invoice1);

        Driver cargoDriver = new Driver(30, 8, "John Markson");
        Vehicle cargoVan = new Vehicle("Van", "Citroen", "Jumper", 20000, 8, cargoDriver);
        Rental rental2 = new Rental(cargoVan, new DateTime(2024, 6, 3), new DateTime(2024, 6, 18), new DateTime(2024, 6, 13));

        Invoice invoice2 = reantalService.generateInvoiceData(cargoVan, rental2);
        reantalService.printInvoice(invoice2);

        
        
    }
}