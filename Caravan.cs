using System;

public class Caravan
{
    public string Name { get; set; }
    public string StartLocation { get; set; }
    public string Destination { get; set; }
    public int TravelTime { get; set; }
    public bool IsTraveling { get; set; }
    public int CargoCapacity { get; set; }
    public int CurrentCargoLoad { get; set; }
    public int GoldProfit { get; set; }
    public bool IsArrived { get; set; }

    public Caravan(string name, string startLocation, string destination, int travelTime, int cargoCapacity, int goldProfit)
    {
        Name = name;
        StartLocation = startLocation;
        Destination = destination;
        TravelTime = travelTime;
        CargoCapacity = cargoCapacity;
        GoldProfit = goldProfit;

        IsTraveling = false;
        IsArrived = false;
        CurrentCargoLoad = 0;
    }

    public void StartTravel()
    {
        if (IsTraveling)
        {
            Console.WriteLine($"Караван '{Name}' вже в дорозі.");
            return;
        }

        if (IsArrived)
        {
            Console.WriteLine($"Караван '{Name}' вже прибув до {Destination}.");
            return;
        }

        IsTraveling = true;

        Console.WriteLine(
            $"Караван '{Name}' вирушив з {StartLocation} до {Destination}. " +
            $"Час дороги: {TravelTime} днів."
        );
    }

    public void Arrive()
    {
        if (!IsTraveling)
        {
            Console.WriteLine($"Караван '{Name}' не знаходиться в дорозі.");
            return;
        }

        IsTraveling = false;
        IsArrived = true;
        CurrentCargoLoad = 0;

        Console.WriteLine(
            $"Караван '{Name}' прибув до {Destination}. " +
            $"Виручка: {GoldProfit} золота."
        );
    }

    public void LoadCargo(int cargoAmount)
    {
        if (IsTraveling)
        {
            Console.WriteLine(
                $"Караван '{Name}' вже в дорозі. Неможливо завантажити вантаж."
            );
            return;
        }

        if (IsArrived)
        {
            Console.WriteLine(
                $"Караван '{Name}' вже прибув до {Destination}. " +
                $"Необхідно задати новий маршрут."
            );
            return;
        }

        if (cargoAmount <= 0)
        {
            Console.WriteLine("Кількість вантажу повинна бути більше нуля.");
            return;
        }

        if (CurrentCargoLoad + cargoAmount > CargoCapacity)
        {
            Console.WriteLine(
                $"Караван '{Name}' не може перевезти стільки вантажу. " +
                $"Максимальна вантажопідйомність: {CargoCapacity}."
            );
            return;
        }

        CurrentCargoLoad += cargoAmount;

        Console.WriteLine(
            $"Завантажено {cargoAmount} одиниць вантажу в караван '{Name}'. " +
            $"Поточне завантаження: {CurrentCargoLoad}/{CargoCapacity}."
        );
    }

    public void DisplayCaravanInfo()
    {
        Console.WriteLine($"Назва каравану: {Name}");
        Console.WriteLine($"Початкова локація: {StartLocation}");
        Console.WriteLine($"Місце призначення: {Destination}");
        Console.WriteLine($"Час дороги: {TravelTime} днів");
        Console.WriteLine($"Статус: {(IsTraveling ? "В дорозі" : IsArrived ? "Прибув" : "Не вирушив")}");
        Console.WriteLine($"Вантажопідйомність: {CargoCapacity}");
        Console.WriteLine($"Поточне завантаження: {CurrentCargoLoad}");
        Console.WriteLine($"Прибуток від подорожі: {GoldProfit} золота");
    }
}