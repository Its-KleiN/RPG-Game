
using System;

public class Food : Consumable
{
    public int BaseNutrition { get; private set; }
    public int ShelfLifeDays { get; private set; }
    public int DaysStored { get; private set; }
    public int PoisonDamage { get; private set; }

    public bool IsSpoiled
    {
        get { return DaysStored >= ShelfLifeDays; }
    }

    public int CurrentNutrition
    {
        get
        {
            if (IsSpoiled)
                return 0;

            double freshness = (double)(ShelfLifeDays - DaysStored)
                               / ShelfLifeDays;

            return (int)Math.Ceiling(BaseNutrition * freshness);
        }
    }

    public Food(
        string name,
        string description,
        double weight,
        int basePrice,
        int baseNutrition,
        int shelfLifeDays,
        int poisonDamage)
        : base(name, description, weight, basePrice)
    {
        if (baseNutrition <= 0)
            throw new ArgumentException(
                "Поживність повинна бути більшою за нуль.");

        if (shelfLifeDays <= 0)
            throw new ArgumentException(
                "Термін придатності повинен бути більшим за нуль.");

        if (poisonDamage < 0)
            throw new ArgumentException(
                "Шкода від отруєння не може бути від'ємною.");

        BaseNutrition = baseNutrition;
        ShelfLifeDays = shelfLifeDays;
        PoisonDamage = poisonDamage;
        DaysStored = 0;
    }

    public void AdvanceDays(int days)
    {
        if (days < 0)
            throw new ArgumentException(
                "Кількість днів не може бути від'ємною.");

        long newDays = (long)DaysStored + days;

        DaysStored = (int)Math.Min(newDays, ShelfLifeDays);
    }

    public override bool Use(Player player)
    {
        if (player == null)
            throw new ArgumentNullException(nameof(player));

        if (IsSpoiled)
        {
            player.TakeDamage(PoisonDamage);
            return true;
        }

        if (player.Satiety >= player.MaxSatiety)
            return false;

        player.Eat(CurrentNutrition);
        return true;
    }

    public override string GetDescription()
    {
        string condition = IsSpoiled ? "Зіпсована" : "Придатна";

        return base.GetDescription() + "\n" +
               $"Поживність: {CurrentNutrition}/{BaseNutrition}\n" +
               $"Термін придатності: {ShelfLifeDays} днів\n" +
               $"Минуло днів: {DaysStored}\n" +
               $"Стан: {condition}";
    }

    public override string GetItemType()
    {
       return "Їжа" ;
    } 
}
