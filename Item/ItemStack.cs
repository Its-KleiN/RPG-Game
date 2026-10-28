
using System;

public class ItemStack
{
    public Item Item { get; }
    public int Quantity { get; private set; }

    public double TotalWeight
    {
        get { return Item.Weight * Quantity; }
    }

    public int TotalBasePrice
    {
        get { return checked(Item.BasePrice * Quantity); }
    }

    public ItemStack(Item item, int quantity)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        if (quantity <= 0)
            throw new ArgumentException("Кількість повинна бути більшою за нуль.");

        Item = item;
        Quantity = quantity;
    }

    public void AddQuantity(int amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Кількість повинна бути більшою за нуль.");

        Quantity = checked(Quantity + amount);
    }

    public bool RemoveQuantity(int amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Кількість повинна бути більшою за нуль.");

        if (amount > Quantity)
            return false;

        Quantity -= amount;
        return true;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Предмет: {Item.Name}");
        Console.WriteLine($"Кількість: {Quantity}");
        Console.WriteLine($"Загальна вага: {TotalWeight} кг");
        Console.WriteLine($"Загальна вартість: {TotalBasePrice} золота");
    }
}
