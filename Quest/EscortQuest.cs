using System;

public class EscortQuest : Quest
{
    public string EscortTargetLocation { get; set; }
    public string EscortTargetName { get; set; }
    public int EscortDistance { get; set; }
    public string CurrentLocation { get; set; }
    public bool IsEscortAlive { get; set; }

    public EscortQuest(string name, string description, int goldReward, int experienceReward, int difficultyLevel, string escortTargetLocation, string escortTargetName, int escortDistance)
        : base(name, description, goldReward, experienceReward, difficultyLevel)
    {
        EscortTargetLocation = escortTargetLocation;
        EscortTargetName = escortTargetName;
        EscortDistance = escortDistance;
        CurrentLocation = CurrentLocation;
        IsEscortAlive = true;
    }

    public void ArriveAtLocation(string Location)
    {
        if (IsCompleted)
        {
            return;
        }

        CurrentLocation = Location;

        if (CurrentLocation == EscortTargetLocation)
        {
            IsCompleted = true;
            Console.WriteLine($"Квест '{Name}' виконано! Ви успішно доставили {EscortTargetName} до {EscortTargetLocation}.");
        }
    }

    public void FailEscort()
    {
        if (IsCompleted)
        {
            return;
        }

        IsEscortAlive = false;
        Console.WriteLine($"Квест '{Name}' не виконано! {EscortTargetName} загинув під час подорожі.");
    }
}
