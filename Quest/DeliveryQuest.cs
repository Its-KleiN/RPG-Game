using System;

public class DeliveryQuest : Quest
{
    public string TargetDeliveryLocation { get; set;}
    public string ItemToDeliver { get; set; }
    public int RequiredQuantity { get; set; }
    public int DeliveredQuantity { get; set; }
    public bool IsItemsDelivered { get; set; }
    
    public DeliveryQuest(string name, string description, int goldReward, int experienceReward, int difficultyLevel, int requiredQuantity, string targetDeliveryLocation, string itemToDeliver)
        : base(name, description, goldReward, experienceReward, difficultyLevel)
    {
        TargetDeliveryLocation = targetDeliveryLocation;
        ItemToDeliver = itemToDeliver;
        RequiredQuantity = requiredQuantity;
        DeliveredQuantity = 0;
        IsItemsDelivered = false;
    }

    public void DeliverItem(string deliveryLocation, int quantity)
    {
        if (IsCompleted)
        {
            return;
        }

        if (deliveryLocation != TargetDeliveryLocation)
        {
            Console.WriteLine($"Квест '{Name}' не виконано! Ви доставили {ItemToDeliver} не в ту локацію.");
            return;
        }

        DeliveredQuantity += quantity;

        if (DeliveredQuantity >= RequiredQuantity)
        {
            IsItemsDelivered = true;
            IsCompleted = true;
            Console.WriteLine($"Квест '{Name}' виконано! Ви успішно доставили {ItemToDeliver} до {TargetDeliveryLocation}.");
        }
        
        else
        {
            Console.WriteLine($"Доставлено {ItemToDeliver}: {DeliveredQuantity}/{RequiredQuantity}.");
        }
    }
   


}