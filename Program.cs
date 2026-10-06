using System;

class Program
{
    static void Main()
    {
        GameManager gameManager = new GameManager();

        gameManager.StartGame();

        Console.ReadKey();
    }
}