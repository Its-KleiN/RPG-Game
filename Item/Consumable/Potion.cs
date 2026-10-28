
using System;

public class Potion : Consumable
{
    public int HealingAmount { get; private set; }

    public Potion(
        string name,
        string description,
        double weight,
        int basePrice,
        int healingAmount)
        : base(name, description, weight, basePrice)
    {
        if (healingAmount <= 0)
        {
            throw new ArgumentException(
                "Лікувальний ефект повинен бути більшим за нуль.");
        }

        HealingAmount = healingAmount;
    }

    public override bool Use(Player player)
    {
        if (player == null)
            throw new ArgumentNullException(nameof(player));

        if (player.Health >= player.MaxHealth)
            return false;

        player.Heal(HealingAmount);

        return true;
    }

    public override string GetDescription()
    {
        return base.GetDescription() + "\n" +
               $"Відновлення здоров'я: +{HealingAmount} HP";
    }

    public override string GetItemType()
    {
       return "Зілля" ;
    } 
}
