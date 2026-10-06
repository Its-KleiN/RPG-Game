using System;
using System.Collections.Generic;

public class Quest
{
    public string Name { get; set;}
    public string Description { get; set;}
    public int GoldReward { get; set; }

    public int ExperienceReward { get; set; }

    public int DifficultyLevel { get; set; }

    public bool IsCompleted { get; set; }

    public Quest(string name, string description, int goldReward, int experienceReward, int difficultyLevel)
    {
        Name = name;
        Description = description;
        GoldReward = goldReward;
        ExperienceReward = experienceReward;
        DifficultyLevel = difficultyLevel;
        IsCompleted = false;
    }

    public void DisplayQuestInfo()
    {
        Console.WriteLine($"Назва квесту: {Name}");
        Console.WriteLine($"Опис: {Description}");
        Console.WriteLine($"Золото в нагороду: {GoldReward}");
        Console.WriteLine($"Досвід в нагороду: {ExperienceReward}");
        Console.WriteLine($"Рівень складності: {DifficultyLevel}");
        Console.WriteLine($"Статус: {(IsCompleted ? "Виконано" : "Не виконано")}");
    }
}