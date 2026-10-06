using System;
using System.Collections.Generic;

public class Inventory
{
    public string Name { get; set; }
    public int Capacity { get; set; }

    public int CurrentItemsCount { get; set; }

    public string OwnerName { get; set; }

    public string Type { get; set; }

    public bool IsFull { get; set; }

    private List<string> Items { get; set; }

    public Inventory(string name, int capacity, int currentItemsCount, string ownerName, string type, bool isFull)
    {
        Name = name;
        Capacity = capacity;
        CurrentItemsCount = currentItemsCount;
        OwnerName = ownerName;
        Type = type;
        IsFull = isFull;

        Items = new List<string>();
    }

    public void AddItem(string item)
    {
        if (CurrentItemsCount < Capacity)
        {
            Items.Add(item);
            CurrentItemsCount++;

            if (CurrentItemsCount == Capacity)
            {
                IsFull = true;
            }
        }
        else
        {
            Console.WriteLine("Інвентар заповнений.");
        }
    }

    public void RemoveItem(string item)
    {
        if (Items.Contains(item))
        {
            Items.Remove(item);
            CurrentItemsCount--;
            IsFull = false;
        }
        else
        {
            Console.WriteLine("Предмет не знайдено в інвентарі.");
        }
    }

    public bool IsFullInventory()
    {
        return CurrentItemsCount >= Capacity;
    }

    public int GetFreeSpace()
    {
        return Capacity - CurrentItemsCount;
    }

    public void DisplayInventory()
    {
        Console.WriteLine($"Інвентар: {Name}");
        Console.WriteLine($"Власник: {OwnerName}");
        Console.WriteLine($"Тип: {Type}");
        Console.WriteLine($"Місткість: {Capacity}");
        Console.WriteLine($"Кількість предметів: {CurrentItemsCount}");
        Console.WriteLine($"Вільне місце: {GetFreeSpace()}");
        Console.WriteLine("Предмети:");

        foreach (var item in Items)
        {
            Console.WriteLine($" - {item}");
        }
    }

    public void ClearInventory()
    {
        Items.Clear();
        CurrentItemsCount = 0;
        IsFull = false;
    }

    
}