using System;
using System.Collections.Generic;

public class QuestManager
{
    private List<Quest> ActiveQuests { get; set; }
    private Dictionary<string, int> CompletedQuests { get; set; }
    public QuestManager()
    {
        ActiveQuests = new List<Quest>();
        CompletedQuests = new Dictionary<string, int>();
    }
    public void AddQuest(Quest quest)
    {
        ActiveQuests.Add(quest);
    }

    public void RemoveQuest(Quest quest)
    {
        if (ActiveQuests.Contains(quest))
        {
            ActiveQuests.Remove(quest);
        }
        else
        {
            Console.WriteLine("Квест не знайдено серед активних квестів.");
        }
    }

    public void CompleteQuest(Quest quest)
    {
        if (ActiveQuests.Contains(quest))
        {
            ActiveQuests.Remove(quest);
            quest.IsCompleted = true;

            if (CompletedQuests.ContainsKey(quest.Name))
            {
                CompletedQuests[quest.Name]++;
            }
            else
            {
                CompletedQuests[quest.Name] = 1;
            }
        }
        else
        {
            Console.WriteLine("Квест не знайдено серед активних квестів.");
        }
    }
    public void DisplayActiveQuests()
    {
        Console.WriteLine("=== Активні квести ===");
        foreach (Quest quest in ActiveQuests)
        {
            quest.DisplayQuestInfo();
            Console.WriteLine();
        }
    }

    public void DisplayCompletedQuests()
    {
        Console.WriteLine("=== Виконані квести ===");

        foreach (var quest in CompletedQuests)
        {
            Console.WriteLine($"{quest.Key} - виконано {quest.Value} разів");
        }
    }
    
    

}