
using System;

public abstract class Item
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public double Weight { get; private set; }
    public int BasePrice { get; private set; }

    protected Item(string name, string description,
                   double weight, int basePrice)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Предмет повинен мати назву.");

        if (weight < 0)
            throw new ArgumentException("Вага не може бути від'ємною.");

        if (basePrice < 0)
            throw new ArgumentException("Ціна не може бути від'ємною.");

        Name = name;
        Description = description;
        Weight = weight;
        BasePrice = basePrice;
    }

    public virtual string GetDescription()
    {
        return $"{Name}\n" +
               $"{Description}\n" +
               $"Вага: {Weight} кг\n" +
               $"Базова ціна: {BasePrice} золота";
    }

    public abstract string GetItemType();
}
