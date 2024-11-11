namespace Lab11.Models;

public abstract class Vehicle
{
    public int VehicleId { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
}