
using System;

public class Armor : Equipment
{
    public int SlashingDefense { get; private set; }
    public int PiercingDefense { get; private set; }
    public int BluntDefense { get; private set; }

    public Armor(
        string name,
        string description,
        double weight,
        int basePrice,
        int rank,
        int maxDurability,
        int slashingDefense,
        int piercingDefense,
        int bluntDefense)
        : base(name, description, weight, basePrice,
               rank, maxDurability)
    {
        if (slashingDefense < 0 ||
            piercingDefense < 0 ||
            bluntDefense < 0)
        {
            throw new ArgumentException(
                "Показники захисту не можуть бути від'ємними.");
        }

        SlashingDefense = slashingDefense;
        PiercingDefense = piercingDefense;
        BluntDefense = bluntDefense;
    }

    public int GetDefense(DamageType damageType)
    {
        switch (damageType)
        {
            case DamageType.Slashing:
                return SlashingDefense;

            case DamageType.Piercing:
                return PiercingDefense;

            case DamageType.Blunt:
                return BluntDefense;

            default:
                throw new ArgumentException(
                    "Невідомий тип пошкоджень.");
        }
    }

    public override string GetDescription()
    {
        return base.GetDescription() + "\n" +
               $"Захист від рубальних: {SlashingDefense}\n" +
               $"Захист від колючих: {PiercingDefense}\n" +
               $"Захист від дробильних: {BluntDefense}";
    }

    public override string GetItemType()
    {
        return "Броня";
    }
}
