
using System;

public class QuestItem : Item
{
    public string RelatedQuest { get; private set; }
    public bool CanBeDiscarded { get; private set; }

    public QuestItem(
        string name,
        string description,
        double weight,
        int basePrice,
        string relatedQuest,
        bool canBeDiscarded = false)
        : base(name, description, weight, basePrice)
    {
        if (string.IsNullOrWhiteSpace(relatedQuest))
            throw new ArgumentException(
                "Необхідно вказати пов'язаний квест.");

        RelatedQuest = relatedQuest;
        CanBeDiscarded = canBeDiscarded;
    }

    public override string GetDescription()
    {
        return base.GetDescription() + "\n" +
               $"Тип предмета: Квестовий\n" +
               $"Пов'язаний квест: {RelatedQuest}\n" +
               $"Можна викинути: {(CanBeDiscarded ? "Так" : "Ні")}";
    }

    public override string GetItemType()
    {
       return "Квестовий предмет" ;
    } 
}
