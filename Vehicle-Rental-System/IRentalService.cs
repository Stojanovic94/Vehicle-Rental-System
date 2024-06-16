public interface IRentalService{

     public Invoice generateInvoiceData(Vehicle vehicle, Rental rental);

     public void printInvoice(Invoice invoice);
     
}