using System;

public class HuntQuest : Quest
{
    public string Location { get; set; }
    public string Target { get; set; }
    public int RequiredKills { get; set; }
    public int CurrentKills { get; set; }

    public HuntQuest(string name, string description, int goldReward, int experienceReward, int difficultyLevel, string location, string target, int requiredKills)
        : base(name, description, goldReward, experienceReward, difficultyLevel)
    {
        Location = location;
        Target = target;
        RequiredKills = requiredKills;
        CurrentKills = 0;
    }

    public void AddKill()
    { 
        if(IsCompleted)
        {
            return;
        }

        CurrentKills++;

        if (CurrentKills>= RequiredKills)
        {
            IsCompleted = true;
            Console.WriteLine($"Квест '{Name}' виконано! Ви вбили достатню кількість цілей.");
        }
    }
    public void DisplayHuntQuestInfo()
    {
        DisplayQuestInfo();
        Console.WriteLine($"Локація: {Location}");
        Console.WriteLine($"Ціль: {Target}");
        Console.WriteLine($"Необхідна кількість вбивств: {RequiredKills}");
        Console.WriteLine($"Поточна кількість вбивств: {CurrentKills}");
    }

}