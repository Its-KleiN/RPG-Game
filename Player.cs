using System;

public class Player
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int Gold { get; set; }
    public string CurrentLocation { get; set; }

    public Player(string name, int level, int health, int maxHealth, int gold, string currentLocation)
    {
        Name = name;
        Level = level;
        Health = health;
        MaxHealth = maxHealth;
        Gold = gold;
        CurrentLocation = currentLocation;
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Level: {Level}");
        Console.WriteLine($"Health: {Health}/{MaxHealth}");
        Console.WriteLine($"Gold: {Gold}");
        Console.WriteLine($"Current Location: {CurrentLocation}");
    }

    public void AddGold(int amount)
    {
        Gold += amount;
    }

    public void SpendGold(int amount)
    {
        if (amount <= Gold)
        {
            Gold -= amount;
        }
        else
        {
            Console.WriteLine("Недостатньо золота.");
        }
    }

    public void Heal(int amount)
    {
        Health += amount;

        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }

    public void ChangeLocation(string location)
    {
        CurrentLocation = location;
    }

    public void LevelUp()
    {
        Level++;
        MaxHealth += 10;
        Health = MaxHealth;
    }
}