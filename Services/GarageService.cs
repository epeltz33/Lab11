
using Lab11.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab11.Services;

public class GarageService(GarageContext context)
{
    // Create
    public void AddVehicle<T>(T vehicle) where T : Vehicle
    {
        context.Set<T>().Add(vehicle);
        context.SaveChanges();
    }

    // Read
    public List<T> GetAllVehicles<T>() where T : Vehicle
    {
        return context.Set<T>().ToList();
    }

    public T? GetVehicleById<T>(int id) where T : Vehicle
    {
        return context.Set<T>().Find(id);
    }

    // Update
    public void UpdateVehicle<T>(T vehicle) where T : Vehicle
    {
        context.Entry(vehicle).State = EntityState.Modified;
        context.SaveChanges();
    }

    // Delete
    public void DeleteVehicle<T>(int id) where T : Vehicle
    {
        var vehicle = context.Set<T>().Find(id);
        if (vehicle != null)
        {
            context.Set<T>().Remove(vehicle);
            context.SaveChanges();
        }
    }

    // Search methods (Bonus Challenge)
    public List<T> SearchByMake<T>(string make) where T : Vehicle
    {
        return context.Set<T>()
            .Where(v => v.Make.ToLower().Contains(make.ToLower()))
            .ToList();
    }

    public List<T> SearchByModel<T>(string model) where T : Vehicle
    {
        return context.Set<T>()
            .Where(v => v.Model.ToLower().Contains(model.ToLower()))
            .ToList();
    }

    public List<T> SearchByYear<T>(int year) where T : Vehicle
    {
        return context.Set<T>()
            .Where(v => v.Year == year)
            .ToList();
    }
}