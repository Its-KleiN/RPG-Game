using System;
using System.Collections.Generic;

public class GameManager
{
    public Player Player { get; set; }
    public Inventory Inventory { get; set; }
    public QuestManager QuestManager { get; set; }

    public List<City> Cities { get; set; }
    public List<WorldEvent> WorldEvents { get; set; }
    public List<Caravan> Caravans { get; set; }

    public int CurrentDay { get; set; }

    public GameManager()
    {
        Cities = new List<City>();
        WorldEvents = new List<WorldEvent>();
        Caravans = new List<Caravan>();

        CurrentDay = 1;
    }

    public void StartGame()
    {
        Console.Clear();

        Console.WriteLine("=== RPG Game ===");

        CreatePlayer();

        City westholm = new City(
            "Вестхолм",
            5000,
            10000,
            0.1,
            1.0,
            1.0,
            1.0,
            1.0,
            1.0,
            true,
            1
        );

        City dustford = new City(
            "Дастфорд",
            3000,
            6000,
            0.1,
            1.0,
            1.0,
            1.0,
            1.0,
            1.0,
            false,
            2
        );

        AddCity(westholm);
        AddCity(dustford);

        Player.ChangeLocation("Вестхолм");

        WorldEvent drought = new WorldEvent(
            "Засуха",
            "Через тривалу відсутність дощів місто страждає від нестачі їжі.",
            10,
            "Дастфорд"
        );

        AddWorldEvent(drought);

        drought.StartEvent();
        dustford.ChangeFoodPriceMultiplier(2.0);

        DeliveryQuest foodQuest = new DeliveryQuest(
            "Доставка їжі",
            "Доставити їжу до Дастфорда, який постраждав від засухи.",
            200,
            100,
            2,
            20,
            "Дастфорд",
            "Їжа"
        );

        QuestManager.AddQuest(foodQuest);

        Console.WriteLine();
        Console.WriteLine("Гру розпочато!");
        Console.WriteLine("Ви знаходитесь у Вестхолмі.");

        Console.WriteLine();
        Console.WriteLine("Натисніть будь-яку клавішу...");
        Console.ReadKey();

        GameLoop();
    }

    public void CreatePlayer()
    {
        Console.WriteLine("Введіть ім'я гравця:");

        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            name = "Player";
        }

        Player = new Player(
            name,
            1,
            100,
            100,
            100,
            "Вестхолм"
        );

        Inventory = new Inventory(
            "Інвентар гравця",
            20,
            0,
            Player.Name,
            "Player",
            false
        );

        QuestManager = new QuestManager();
    }

    public void AddCity(City city)
    {
        Cities.Add(city);
    }

    public void AddWorldEvent(WorldEvent worldEvent)
    {
        WorldEvents.Add(worldEvent);
    }

    public void AddCaravan(Caravan caravan)
    {
        Caravans.Add(caravan);
    }

    public void DisplayGameInfo()
    {
        Console.WriteLine("=== Інформація про гру ===");

        Player.DisplayPlayerInfo();

        Console.WriteLine();
        Console.WriteLine($"Поточний день: {CurrentDay}");
        Console.WriteLine($"Кількість міст: {Cities.Count}");
        Console.WriteLine($"Кількість подій: {WorldEvents.Count}");
        Console.WriteLine($"Кількість караванів: {Caravans.Count}");
    }

    public void GameLoop()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();

            Console.WriteLine("================================");
            Console.WriteLine("           RPG GAME");
            Console.WriteLine("================================");
            Console.WriteLine($"День: {CurrentDay}");
            Console.WriteLine($"Місце: {Player.CurrentLocation}");
            Console.WriteLine($"Золото: {Player.Gold}");
            Console.WriteLine();

            Console.WriteLine("1. Інформація про персонажа");
            Console.WriteLine("2. Інвентар");
            Console.WriteLine("3. Активні квести");
            Console.WriteLine("4. Виконані квести");
            Console.WriteLine("5. Міста");
            Console.WriteLine("6. Світові події");
            Console.WriteLine("7. Каравани");
            Console.WriteLine("8. Перейти до іншого міста");
            Console.WriteLine("9. Наступний день");
            Console.WriteLine("0. Вийти");

            Console.WriteLine();
            Console.Write("Виберіть дію: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Player.DisplayPlayerInfo();
                    Pause();
                    break;

                case "2":
                    Console.Clear();
                    Inventory.DisplayInventory();
                    Pause();
                    break;

                case "3":
                    Console.Clear();
                    QuestManager.DisplayActiveQuests();
                    Pause();
                    break;

                case "4":
                    Console.Clear();
                    QuestManager.DisplayCompletedQuests();
                    Pause();
                    break;

                case "5":
                    Console.Clear();

                    foreach (City city in Cities)
                    {
                        city.DisplayCityInfo();
                        Console.WriteLine();
                    }

                    Pause();
                    break;

                case "6":
                    Console.Clear();

                    foreach (WorldEvent worldEvent in WorldEvents)
                    {
                        worldEvent.DisplayEventInfo();
                        Console.WriteLine();
                    }

                    Pause();
                    break;

                case "7":
                    Console.Clear();

                    if (Caravans.Count == 0)
                    {
                        Console.WriteLine("Караванів поки немає.");
                    }
                    else
                    {
                        foreach (Caravan caravan in Caravans)
                        {
                            caravan.DisplayCaravanInfo();
                            Console.WriteLine();
                        }
                    }

                    Pause();
                    break;

                case "8":
                    TravelMenu();
                    break;

                case "9":
                    CurrentDay++;

                    Console.Clear();
                    Console.WriteLine($"Настав новий день.");
                    Console.WriteLine($"Зараз день {CurrentDay}.");

                    Pause();
                    break;

                case "0":
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Невірний вибір.");
                    Pause();
                    break;
            }
        }

        Console.Clear();
        Console.WriteLine("Гру завершено.");
    }

    public void TravelMenu()
    {
        Console.Clear();

        Console.WriteLine("=== ПОДОРОЖ ===");
        Console.WriteLine();
        Console.WriteLine($"Поточне місце: {Player.CurrentLocation}");
        Console.WriteLine();

        int number = 1;

        foreach (City city in Cities)
        {
            if (city.Name != Player.CurrentLocation)
            {
                Console.WriteLine($"{number}. {city.Name}");
                number++;
            }
        }

        Console.WriteLine("0. Назад");
        Console.WriteLine();
        Console.Write("Виберіть місто: ");

        string choice = Console.ReadLine();

        if (choice == "0")
        {
            return;
        }

        int selectedNumber;

        if (!int.TryParse(choice, out selectedNumber))
        {
            Console.WriteLine("Невірний вибір.");
            Pause();
            return;
        }

        number = 1;

        foreach (City city in Cities)
        {
            if (city.Name != Player.CurrentLocation)
            {
                if (number == selectedNumber)
                {
                    Console.Clear();

                    Console.WriteLine(
                        $"Ви вирушили з {Player.CurrentLocation} до {city.Name}."
                    );

                    Console.WriteLine();
                    Console.WriteLine("Подорож займає 3 дні.");

                    CurrentDay += 3;

                    Player.ChangeLocation(city.Name);

                    Console.WriteLine();
                    Console.WriteLine($"Минуло 3 дні.");
                    Console.WriteLine($"Зараз день {CurrentDay}.");
                    Console.WriteLine();
                    Console.WriteLine($"Ви прибули до {city.Name}.");

                    Pause();
                    return;
                }

                number++;
            }
        }

        Console.WriteLine("Місто не знайдено.");
        Pause();
    }

    public void Pause()
    {
        Console.WriteLine();
        Console.WriteLine("Натисніть будь-яку клавішу...");
        Console.ReadKey();
    }
}