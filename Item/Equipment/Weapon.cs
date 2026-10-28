
using System;

public enum DamageType
{
    Slashing,
    Piercing,
    Blunt
}

public class Weapon : Equipment
{
    public int Damage { get; private set; }
    public DamageType DamageType { get; private set; }

    public Weapon(
        string name,
        string description,
        double weight,
        int basePrice,
        int rank,
        int maxDurability,
        int damage,
        DamageType damageType)
        : base(name, description, weight, basePrice,
               rank, maxDurability)
    {
        if (damage <= 0)
            throw new ArgumentException("Шкода повинна бути більшою за нуль.");

        if (!Enum.IsDefined(damageType))
            throw new ArgumentException("Невідомий тип пошкоджень.");

        Damage = damage;
        DamageType = damageType;
    }

    public override string GetDescription()
    {
        return base.GetDescription() + "\n" +
               $"Шкода: {Damage}\n" +
               $"Тип пошкоджень: {GetDamageTypeName()}";
    }

    public string GetDamageTypeName()
    {
        switch (DamageType)
        {
            case DamageType.Slashing:
                return "Рубальні";

            case DamageType.Piercing:
                return "Колючі";

            case DamageType.Blunt:
                return "Дробильні";

            default:
                return "Невідомий";
        }
    }

    public override string GetItemType()
    {
        return "Зброя";
    }
}
