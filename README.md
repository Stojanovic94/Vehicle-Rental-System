# Vehicle Rental System
## Overview
This project is a simple yet functional vehicle rental system designed to manage the rental and return processes of different types of vehicles. The system calculates rental and insurance costs based on specific business rules and generates an invoice for the customers upon the return of the rented vehicle.

# Features
 - Supports three types of vehicles: Cars, Motorcycles, and Cargo Vans.
 - Calculates rental and insurance costs based on vehicle type, rental duration, and additional parameters.
 - Generates a detailed invoice upon return of the vehicle.
 - Implements a command-line interface (CLI) for easy interaction.

# Business Rules
## Daily Rental Cost:

Cars: $20/day (1 week or less), $15/day (more than 1 week)
Motorcycles: $15/day (1 week or less), $10/day (more than 1 week)
Cargo Vans: $50/day (1 week or less), $40/day (more than 1 week)

## Insurance Cost:

Cars: 0.01% of vehicle value per day
Motorcycles: 0.02% of vehicle value per day
Cargo Vans: 0.03% of vehicle value per day
Insurance Adjustments:

Cars with a high safety rating (4 or 5): 10% reduction
Motorcycles with riders under 25 years old: 20% increase
Cargo Vans with drivers having more than 5 years of experience: 15% reduction

## Early Return Policy:

Rental costs: Full price for elapsed days, half price for remaining days.
Insurance costs: Full price for elapsed days, no charge for remaining days.

# To build and run
## Prerequisites
Ensure you have the .NET SDK installed on your system.
If you're using an integrated development environment (IDE) like Visual Studio, ensure it is installed and updated to the latest version.

# Using Visual Studio
## Open Visual Studio:
Launch Visual Studio on your system.

# Open the Solution:

 - Go to File > Open > Project/Solution.
 - Navigate to the directory containing your .sln file.
 - Select the .sln file and click Open.

# Build the Solution:

 - In the Solution Explorer, right-click on the solution (or project) and select Build.
 - Alternatively, you can go to the Build menu at the top and select Build Solution.

# Run the Application:

 - To run the application, press F5 or click the Start button in the toolbar.
 - Ensure that the correct project is set as the startup project (right-click the project in Solution Explorer and select Set as StartUp Project).

# Brief Approach to the Solution
To achieve the desired output format for the invoices, the approach involved the following steps:

## Understanding the Structure:
First, we identified the structure and contents of the project by listing the files. The key files include Program.cs, RentalService.cs, Invoice.cs, and Vehicle.cs.

## Invoice Class Enhancements:
 - Ensure that the Invoice class has properties to store all the necessary details, including customer name, vehicle details, reservation dates, costs, and totals.
 - Add any additional properties that are required to calculate and display discounts or special charges.

## RentalService Class Implementation:
 - generateInvoiceData Method: This method is responsible for creating an Invoice object by calculating rental days, costs, and any applicable discounts or insurance charges.
 - printInvoice Method: This method formats and prints the invoice details as per the required format.

## Main Program Adjustments:
 - Modify the main program in Program.cs to create instances of drivers, vehicles, and rentals.
 - Generate invoices using the RentalService and print them in the specified format.

## Detailed Implementation:
 - Invoice.cs: Ensure the Invoice class can hold all necessary data
 - RentalService.cs: Implement methods to generate and print invoices
 - Program.cs: Create instances and generate invoices
   
# Conclusion
This project demonstrates a vehicle rental system with a CLI interface. It calculates rental and insurance costs based on business rules and generates an invoice upon the return of a vehicle. Follow the provided instructions to build and run the application, and explore the code structure to understand its implementation.
