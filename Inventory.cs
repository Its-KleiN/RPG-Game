
using System;
using System.Collections.Generic;

public class Inventory
{
    public string Name { get; private set; }
    public string OwnerName { get; private set; }
    public string Type { get; private set; }
    public double MaxWeight { get; private set; }

    private readonly List<ItemStack> Items;

    public int CurrentItemsCount
    {
        get
        {
            int count = 0;

            foreach (ItemStack stack in Items)
            {
                count += stack.Quantity;
            }

            return count;
        }
    }

    public double CurrentWeight
    {
        get
        {
            double weight = 0;

            foreach (ItemStack stack in Items)
            {
                weight += stack.TotalWeight;
            }

            return weight;
        }
    }

    public bool IsFull
    {
        get { return IsFullInventory(); }
    }

    public Inventory(
        string name,
        double maxWeight,
        string ownerName,
        string type)
    {
        if (double.IsNaN(maxWeight) ||
            double.IsInfinity(maxWeight) ||
            maxWeight <= 0)
        {
            throw new ArgumentException(
                "Максимальна вага повинна бути додатним числом.");
        }

        Name = name;
        MaxWeight = maxWeight;
        OwnerName = ownerName;
        Type = type;

        Items = new List<ItemStack>();
    }

    private bool CanStack(Item item)
    {
        return item is Resource ||
               item is Food ||
               item is Potion;
    }

    private bool AreSameItem(Item first, Item second)
    {
        if (ReferenceEquals(first, second))
            return true;

        if (first.GetType() != second.GetType())
            return false;

        if (first is Resource && second is Resource)
        {
            return first.Name == second.Name &&
                   first.Description == second.Description &&
                   first.Weight == second.Weight &&
                   first.BasePrice == second.BasePrice;
        }

        if (first is Potion p1 && second is Potion p2)
        {
            return p1.Name == p2.Name &&
                   p1.Description == p2.Description &&
                   p1.Weight == p2.Weight &&
                   p1.BasePrice == p2.BasePrice &&
                   p1.HealingAmount == p2.HealingAmount;
        }

        return false;
    }

    public bool AddItem(Item item, int quantity = 1)
    {
        if (item == null || quantity <= 0)
            return false;

        if (!CanStack(item) && quantity > 1)
            return false;

        double additionalWeight = item.Weight * quantity;

        if (double.IsNaN(additionalWeight) ||
            double.IsInfinity(additionalWeight) ||
            additionalWeight > GetFreeSpace())
        {
            return false;
        }

        if (CanStack(item))
        {
            foreach (ItemStack stack in Items)
            {
                if (AreSameItem(stack.Item, item))
                {
                    stack.AddQuantity(quantity);
                    return true;
                }
            }
        }
        else if (HasItem(item))
        {
            return false;
        }

        Items.Add(new ItemStack(item, quantity));
        return true;
    }

    public int GetItemQuantity(Item item)
    {
        if (item == null)
            return 0;

        int total = 0;

        foreach (ItemStack stack in Items)
        {
            if (AreSameItem(stack.Item, item))
            {
                total += stack.Quantity;
            }
        }

        return total;
    }

    public bool HasItem(Item item, int quantity = 1)
    {
        if (item == null || quantity <= 0)
            return false;

        return GetItemQuantity(item) >= quantity;
    }

    public bool RemoveItem(Item item, int quantity = 1)
    {
        if (!HasItem(item, quantity))
            return false;

        int remaining = quantity;

        for (int i = Items.Count - 1; i >= 0; i--)
        {
            ItemStack stack = Items[i];

            if (!AreSameItem(stack.Item, item))
                continue;

            int amount = Math.Min(stack.Quantity, remaining);

            stack.RemoveQuantity(amount);
            remaining -= amount;

            if (stack.Quantity == 0)
            {
                Items.RemoveAt(i);
            }

            if (remaining == 0)
                break;
        }

        return true;
    }

    public bool DiscardItem(Item item, int quantity = 1)
    {
        if (item is QuestItem questItem)
        {
            if (!questItem.CanBeDiscarded)
                return false;
        }

        return RemoveItem(item, quantity);
    }

    public bool UseItem(int itemNumber, Player player)
    {
        if (player == null)
            return false;

        int index = itemNumber - 1;

        if (index < 0 || index >= Items.Count)
            return false;

        ItemStack stack = Items[index];

        if (stack.Item is not Consumable consumable)
            return false;

        bool success = consumable.Use(player);

        if (!success)
            return false;

        stack.RemoveQuantity(1);

        if (stack.Quantity == 0)
        {
            Items.RemoveAt(index);
        }

        return true;
    }

    public void AdvanceDays(int days)
    {
        if (days < 0)
        {
            throw new ArgumentException(
                "Кількість днів не може бути від'ємною.");
        }

        foreach (ItemStack stack in Items)
        {
            if (stack.Item is Food food)
            {
                food.AdvanceDays(days);
            }
        }
    }

    public bool IsFullInventory()
    {
        return CurrentWeight >= MaxWeight;
    }

    public double GetFreeSpace()
    {
        return Math.Max(0, MaxWeight - CurrentWeight);
    }

    public void DisplayInventory()
    {
        Console.WriteLine($"Інвентар: {Name}");
        Console.WriteLine($"Власник: {OwnerName}");
        Console.WriteLine($"Тип: {Type}");
        Console.WriteLine();

        Console.WriteLine(
            $"Загальна вага: {CurrentWeight:F2}/{MaxWeight:F2} кг");

        Console.WriteLine(
            $"Вільне місце: {GetFreeSpace():F2} кг");

        Console.WriteLine(
            $"Кількість предметів: {CurrentItemsCount}");

        Console.WriteLine();

        if (Items.Count == 0)
        {
            Console.WriteLine("Інвентар порожній.");
            return;
        }

        Console.WriteLine("Предмети:");

        for (int i = 0; i < Items.Count; i++)
        {
            ItemStack stack = Items[i];

            Console.WriteLine(
                $"{i + 1}. {stack.Item.Name} " +
                $"x{stack.Quantity} " +
                $"({stack.TotalWeight:F2} кг)");

            Console.WriteLine(
                $"   Тип: {stack.Item.GetItemType()}");

            if (stack.Item is Food food)
            {
                Console.WriteLine(
                    $"   Свіжість: {(food.IsSpoiled ? "Зіпсована" : "Придатна")}");

                Console.WriteLine(
                    $"   Поживність: {food.CurrentNutrition}");
            }

            if (stack.Item is Equipment equipment)
            {
                Console.WriteLine(
                    $"   Міцність: {equipment.DurabilityPercentage:F1}%");
            }
        }
    }

    public void ClearInventory()
    {
        Items.Clear();
    }
}
