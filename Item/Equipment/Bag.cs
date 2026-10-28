
using System;

public class Bag : Equipment
{
    public double AdditionalCapacity { get; private set; }

    public Bag(
        string name,
        string description,
        double weight,
        int basePrice,
        int rank,
        int maxDurability,
        double additionalCapacity)
        : base(name, description, weight, basePrice,
               rank, maxDurability)
    {
        if (double.IsNaN(additionalCapacity) ||
            double.IsInfinity(additionalCapacity) ||
            additionalCapacity <= 0)
        {
            throw new ArgumentException(
                "Додаткова вантажопідйомність повинна бути додатним скінченним числом.");
        }

        AdditionalCapacity = additionalCapacity;
    }

    public override string GetDescription()
    {
        return base.GetDescription() + "\n" +
               $"Додаткова вантажопідйомність: " +
               $"+{AdditionalCapacity} кг";
    }

    public override string GetItemType()
    {
       return "Сумка" ;
    } 
}
