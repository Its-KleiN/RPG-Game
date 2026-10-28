
using System;

public enum SocialBonusType
{
    Charisma,
    Persuasion,
    Eloquence,
    Intimidation
}

public class Accessory : Equipment
{
    public SocialBonusType BonusType { get; private set; }
    public int BonusValue { get; private set; }

    public Accessory(
        string name,
        string description,
        double weight,
        int basePrice,
        int rank,
        int maxDurability,
        SocialBonusType bonusType,
        int bonusValue)
        : base(name, description, weight, basePrice,
               rank, maxDurability)
    {
        if (!Enum.IsDefined(bonusType))
            throw new ArgumentException("Невідомий тип бонусу.");

        if (bonusValue <= 0)
            throw new ArgumentException(
                "Бонус повинен бути більшим за нуль.");

        BonusType = bonusType;
        BonusValue = bonusValue;
    }

    public string GetBonusName()
    {
        switch (BonusType)
        {
            case SocialBonusType.Charisma:
                return "Харизма";

            case SocialBonusType.Persuasion:
                return "Переконання";

            case SocialBonusType.Eloquence:
                return "Красномовство";

            case SocialBonusType.Intimidation:
                return "Залякування";

            default:
                return "Невідомий бонус";
        }
    }

    public override string GetDescription()
    {
        return base.GetDescription() + "\n" +
               $"Бонус: +{BonusValue} до {GetBonusName()}";
    }

    public override string GetItemType()
    {
       return "Аксесуар" ;
    } 
}
