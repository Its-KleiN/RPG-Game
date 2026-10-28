
using System;

public class Player
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int Gold { get; set; }
    public string CurrentLocation { get; set; }

    public int Satiety { get; private set; }
    public int MaxSatiety { get; private set; }

    public Player(string name, int level, int health,
                  int maxHealth, int gold, string currentLocation)
    {
        Name = name;
        Level = level;
        Health = health;
        MaxHealth = maxHealth;
        Gold = gold;
        CurrentLocation = currentLocation;

        MaxSatiety = 100;
        Satiety = 50;
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Level: {Level}");
        Console.WriteLine($"Health: {Health}/{MaxHealth}");
        Console.WriteLine($"Satiety: {Satiety}/{MaxSatiety}");
        Console.WriteLine($"Gold: {Gold}");
        Console.WriteLine($"Current Location: {CurrentLocation}");
    }

    public void AddGold(int amount)
    {
        if (amount < 0)
            throw new ArgumentException("Кількість золота не може бути від'ємною.");

        Gold = checked(Gold + amount);
    }

    public void SpendGold(int amount)
    {
        if (amount < 0)
            throw new ArgumentException("Кількість золота не може бути від'ємною.");

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
        if (amount < 0)
            throw new ArgumentException("Лікування не може бути від'ємним.");

        Health = (int)Math.Min(MaxHealth, (long)Health + amount);
    }

    public void TakeDamage(int amount)
    {
        if (amount < 0)
            throw new ArgumentException("Шкода не може бути від'ємною.");

        Health = (int)Math.Max(0L, (long)Health - amount);
    }

    public void Eat(int amount)
    {
        if (amount < 0)
            throw new ArgumentException("Поживність не може бути від'ємною.");

        Satiety = (int)Math.Min(MaxSatiety, (long)Satiety + amount);
    }

    public void ReduceSatiety(int amount)
    {
        if (amount < 0)
            throw new ArgumentException("Втрата ситості не може бути від'ємною.");

        Satiety = (int)Math.Max(0L, (long)Satiety - amount);
    }

    public void AdvanceDay()
    {
        ReduceSatiety(15);

        if (Satiety == 0)
        {
            TakeDamage(5);
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
