namespace Lab11.Models;

public partial class Car
{
    
}

public partial class Car : Vehicle
{
    public int NumDoors { get; set; }
    public string Transmission { get; set; }
}