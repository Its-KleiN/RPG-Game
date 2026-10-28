
using System;

public abstract class Equipment : Item
{
    public int Rank { get; private set; }
    public int Durability { get; private set; }
    public int MaxDurability { get; private set; }

    protected Equipment(
        string name,
        string description,
        double weight,
        int basePrice,
        int rank,
        int maxDurability)
        : base(name, description, weight, basePrice)
    {
        if (rank < 1 || rank > 3)
            throw new ArgumentException("Ранг повинен бути від 1 до 3.");

        if (maxDurability <= 0)
            throw new ArgumentException("Максимальна міцність повинна бути більшою за нуль.");

        Rank = rank;
        MaxDurability = maxDurability;
        Durability = maxDurability;
    }

    public double DurabilityPercentage
    {
        get
        {
            return (double)Durability / MaxDurability * 100;
        }
    }

    public bool IsBroken
    {
        get
        {
            return Durability == 0;
        }
    }

    public void ReduceDurability(int amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Значення повинно бути більшим за нуль.");

        Durability = Math.Max(0, Durability - amount);
    }

    public void Repair(int amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Значення повинно бути більшим за нуль.");

        Durability += Math.Min(amount, MaxDurability - Durability);
    }

    public override string GetDescription()
    {
        return base.GetDescription() + "\n" +
               $"Ранг: {Rank}\n" +
               $"Міцність: {Durability}/{MaxDurability} " +
               $"({DurabilityPercentage:F1}%)";
    }
}
