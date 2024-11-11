using Lab11.Models;
using Lab11.Services;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Garage Application...");

        using var context = new GarageContext();
        var garageService = new GarageService(context);

        try
        {
            // Ensure database is created
            Console.WriteLine("Creating database if it doesn't exist...");
            context.Database.EnsureCreated();
            
            if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "garage.db")))
            {
                Console.WriteLine("Database file created successfully!");
            }
            else
            {
                Console.WriteLine("Error: Database file was not created!");
                return;
            }

            // Add some test data
            Console.WriteLine("\nAdding test vehicles...");
            
            // Only add test data if the database is empty
            if (!context.Vehicles.Any())
            {
                var car = new Car
                {
                    Make = "Toyota",
                    Model = "Camry",
                    Year = 2020,
                    NumDoors = 4,
                    Transmission = "Automatic"
                };
                garageService.AddVehicle(car);
                Console.WriteLine("Added car");

                var motorcycle = new Motorcycle
                {
                    Make = "Honda",
                    Model = "CBR600RR",
                    Year = 2021,
                    EngineDisplacement = 600,
                    HasABS = true
                };
                garageService.AddVehicle(motorcycle);
                Console.WriteLine("Added motorcycle");
            }

            // Display all vehicles in database
            Console.WriteLine("\nCurrent vehicles in database:");
            var vehicles = context.Vehicles.ToList();
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine($"- {vehicle.GetType().Name}: {vehicle.Year} {vehicle.Make} {vehicle.Model}");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine($"Stack trace: {ex.StackTrace}");
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}