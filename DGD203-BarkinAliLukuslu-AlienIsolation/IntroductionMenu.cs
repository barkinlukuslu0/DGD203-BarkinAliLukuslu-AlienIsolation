using FirstGame;

public class IntroductionMenu
{
    public void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("=== INTRODUCTION MENU ===");
        Console.WriteLine("1. New Game");
        Console.WriteLine("2. Credits");
        Console.Write("Please select an option (1 or 2): ");

        string choice = Console.ReadLine();

        if (choice == "1")
        {
            StartNewGame();
        }
        else if (choice == "2")
        {
            ShowCredits();
        }
        else
        {
            Console.WriteLine("Invalid choice. Please choose 1 or 2.");
            Console.ReadKey();
            ShowMenu();
        }
    }

    private void StartNewGame()
    {
        Console.Clear();
        Console.WriteLine("Starting a new game...\n");
        Game controller = new Game();
        controller.StartGame();
    }

    private void ShowCredits()
    {
        Console.Clear();
        Console.WriteLine("=== CREDITS ===");
        Console.WriteLine("Game developed by: Barkýn Ali Lüküslü");
        Console.WriteLine("Special thanks to: Onur EREREN");
        Console.WriteLine("\nPress any key to return to the main menu.");
        Console.ReadKey();
        ShowMenu();
    }
}
