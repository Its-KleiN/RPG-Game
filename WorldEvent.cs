using System;

public class WorldEvent
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public string AffectedLocation { get; set; }
    public bool IsActive { get; set; }

    public WorldEvent( string name, string description, int duration, string affectedLocation)
    {
        Name = name;
        Description = description;
        Duration = duration;
        AffectedLocation = affectedLocation;
        IsActive = false;
    }

    public void StartEvent()
    {
        IsActive = true;
    }

    public void EndEvent()
    {
        IsActive = false;
    }

    public void DisplayEventInfo()
    {
        Console.WriteLine($"Назва події: {Name}");
        Console.WriteLine($"Опис: {Description}");
        Console.WriteLine($"Тривалість: {Duration} днів");
        Console.WriteLine($"Локація: {AffectedLocation}");
        Console.WriteLine($"Статус: {(IsActive ? "Активний" : "Неактивний")}");
    }

}