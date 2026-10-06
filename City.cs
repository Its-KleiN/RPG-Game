using System;

public class City
{
    public string Name { get; set; }
    public int Population { get; set; }
    public int Gold { get; set; }
    public double TaxRate { get; set; }

    public double WeaponPriceMultiplier { get; set; }
    public double ArmorPriceMultiplier { get; set; }
    public double PotionPriceMultiplier { get; set; }
    public double ResourcePriceMultiplier { get; set; }
    public double FoodPriceMultiplier { get; set; }

    public bool IsCapital { get; set; }
    public int DangerLevel { get; set; }

    public City(string name, int population, int gold, double taxRate,
        double weaponPriceMultiplier, double armorPriceMultiplier,
        double potionPriceMultiplier, double resourcePriceMultiplier,
        double foodPriceMultiplier, bool isCapital, int dangerLevel)
    {
        Name = name;
        Population = population;
        Gold = gold;
        TaxRate = taxRate;
        WeaponPriceMultiplier = weaponPriceMultiplier;
        ArmorPriceMultiplier = armorPriceMultiplier;
        PotionPriceMultiplier = potionPriceMultiplier;
        ResourcePriceMultiplier = resourcePriceMultiplier;
        FoodPriceMultiplier = foodPriceMultiplier;
        IsCapital = isCapital;
        DangerLevel = dangerLevel;
    }

    public void DisplayCityInfo()
    {
        Console.WriteLine($"Місто: {Name}");
        Console.WriteLine($"Населення: {Population}");
        Console.WriteLine($"Золото: {Gold}");
        Console.WriteLine($"Податок: {TaxRate * 100}%");
        Console.WriteLine($"Множник ціни зброї: {WeaponPriceMultiplier}");
        Console.WriteLine($"Множник ціни обладунків: {ArmorPriceMultiplier}");
        Console.WriteLine($"Множник ціни зілль: {PotionPriceMultiplier}");
        Console.WriteLine($"Множник ціни ресурсів: {ResourcePriceMultiplier}");
        Console.WriteLine($"Множник ціни їжі: {FoodPriceMultiplier}");
        Console.WriteLine($"Рівень небезпеки: {DangerLevel}");

        if (IsCapital)
        {
            Console.WriteLine("Статус: Столиця");
        }
        else
        {
            Console.WriteLine("Статус: Звичайне місто");
        }
    }

    public int GetWeaponPrice(int basePrice)
    {
        return (int)(basePrice * WeaponPriceMultiplier);
    }

    public int GetArmorPrice(int basePrice)
    {
        return (int)(basePrice * ArmorPriceMultiplier);
    }

    public int GetPotionPrice(int basePrice)
    {
        return (int)(basePrice * PotionPriceMultiplier);
    }

    public int GetResourcePrice(int basePrice)
    {
        return (int)(basePrice * ResourcePriceMultiplier);
    }

    public int GetFoodPrice(int basePrice)
    {
        return (int)(basePrice * FoodPriceMultiplier);
    }

    public void ChangeWeaponPriceMultiplier(double multiplier)
    {
        WeaponPriceMultiplier = multiplier;
    }

    public void ChangeArmorPriceMultiplier(double multiplier)
    {
        ArmorPriceMultiplier = multiplier;
    }

    public void ChangePotionPriceMultiplier(double multiplier)
    {
        PotionPriceMultiplier = multiplier;
    }

    public void ChangeResourcePriceMultiplier(double multiplier)
    {
        ResourcePriceMultiplier = multiplier;
    }

    public void ChangeFoodPriceMultiplier(double multiplier)
    {
        FoodPriceMultiplier = multiplier;
    }

    public void ChangeTaxRate(double taxRate)
    {
        TaxRate = taxRate;
    }

    public void ChangeDangerLevel(int dangerLevel)
    {
        DangerLevel = dangerLevel;
    }
}