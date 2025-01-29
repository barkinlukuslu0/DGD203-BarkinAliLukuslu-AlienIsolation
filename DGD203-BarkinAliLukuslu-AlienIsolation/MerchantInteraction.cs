namespace FirstGame;

public class NPCInteraction : Interaction
{
    private GameMap _map;

    public NPCInteraction(string description, string[] choices, string[] responses, GameMap map)
        : base(description, choices, responses)
    {
        _map = map;
    }

    public override void Choose()
    {
        base.Choose();
        ExecuteChoice();
    }

    private void ExecuteChoice()
    {
        switch (_choiceIndex)
        {
            case 0:
                Console.WriteLine("NPC shares valuable information.");
                break;
            case 1:
                Console.WriteLine("NPC gives you an item.");
                break;
            case 2:
                Console.WriteLine("NPC ignores you.");
                break;
            default:
                Console.WriteLine("The NPC looks at you confused.");
                break;
        }
    }
}
