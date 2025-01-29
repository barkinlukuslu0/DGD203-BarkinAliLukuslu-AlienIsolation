namespace FirstGame;

public class MapLocations
{
    #region REFERENCES

    private GameMap _map;

    #endregion

    #region VARIABLES


    public Dictionary<Vector2Int, MapLocationData> Locations;

    #endregion

    #region CONSTRUCTOR
    public MapLocations(GameMap gameMap)
    {
        _map = gameMap;
        Locations = new Dictionary<Vector2Int, MapLocationData>();
        AddLocations();
    }

    #endregion

    #region METHODS

    private void AddLocations()
    {
        AddSevastopolStation();
        AddMedicalBay();
        AddSyntheticLab();
        AddEscapePod();
        AddCreatureEncounter();
    }

    #region Location Generation

    private void AddSevastopolStation()
    {
        Vector2Int coordinates = new Vector2Int { X = 0, Y = 0 };

        MapLocationData sevastopol = new MapLocationData();
        sevastopol.Coordinates = coordinates;
        sevastopol.Name = "Sevastopol Station";
        sevastopol.Description =
            "A massive and deteriorating space station, Sevastopol drifts in the vast emptiness of space. " +
            "Dimly lit corridors echo with the sounds of distant machinery, and the tension in the air is palpable. " +
            "Scattered remnants of human life paint a grim story of desperation and survival.";
        sevastopol.IsAccessible = true;
        sevastopol.IsInteractable = true;
        sevastopol.Items = new Item[1];

        Item flare = GenerateFlare();
        sevastopol.Items[0] = flare;

        Interaction engineer = GenerateEngineer();
        sevastopol.Interaction = engineer;

        sevastopol.AllowsTravel = new bool[] { true, true, false, true };

        Locations[coordinates] = sevastopol;
    }

    private void AddMedicalBay()
    {
        Vector2Int coordinates = new Vector2Int { X = 1, Y = 0 };

        MapLocationData medicalBay = new MapLocationData();
        medicalBay.Coordinates = coordinates;
        medicalBay.Name = "Medical Bay";
        medicalBay.Description =
            "The once pristine medical facility is now a dimly lit maze of overturned gurneys and shattered glass. " +
            "Emergency lights flicker ominously, and distant whispers echo through the halls. " +
            "Something is watching... or waiting.";
        medicalBay.IsAccessible = true;
        medicalBay.IsInteractable = true;
        medicalBay.Items = new Item[1];

        Item medkit = GenerateMedkit();
        medicalBay.Items[0] = medkit;

        Interaction doctor = GenerateDoctor();
        medicalBay.Interaction = doctor;

        medicalBay.AllowsTravel = new bool[] { true, true, true, false };

        Locations[coordinates] = medicalBay;
    }

    private void AddSyntheticLab()
    {
        Vector2Int coordinates = new Vector2Int { X = 0, Y = 1 };

        MapLocationData syntheticLab = new MapLocationData();
        syntheticLab.Coordinates = coordinates;
        syntheticLab.Name = "Synthetic Lab";
        syntheticLab.Description =
            "A research facility dedicated to the development of advanced AI and synthetic lifeforms. " +
            "Monitors flicker with distorted video feeds, and the silence is broken only by the mechanical hum of inactive androids. " +
            "Are they truly inactive?";
        syntheticLab.IsAccessible = true;
        syntheticLab.IsInteractable = true;
        syntheticLab.Items = new Item[1];

        Item accessKey = GenerateAccessKey();
        syntheticLab.Items[0] = accessKey;

        Interaction android = GenerateAndroid();
        syntheticLab.Interaction = android;

        syntheticLab.AllowsTravel = new bool[] { false, true, true, true };

        Locations[coordinates] = syntheticLab;
    }

    private void AddCreatureEncounter()
    {
        Vector2Int coordinates = new Vector2Int { X = 1, Y = 1 };

        MapLocationData creatureEncounter = new MapLocationData();
        creatureEncounter.Coordinates = coordinates;
        creatureEncounter.Name = "Creature Encounter";
        creatureEncounter.Description =
            "The air is thick with the stench of decay. A low growl echoes from the shadows as the creature approaches. " +
            "Before you can react, the monster lunges, and everything goes black...";
        creatureEncounter.IsAccessible = false;
        creatureEncounter.IsInteractable = true;
        creatureEncounter.Items = new Item[0];

        Interaction creature = GenerateCreature();
        creatureEncounter.Interaction = creature;

        creatureEncounter.AllowsTravel = new bool[] { false, false, false, false };

        Locations[coordinates] = creatureEncounter;
    }

    private void AddEscapePod()
    {
        Vector2Int coordinates = new Vector2Int { X = 2, Y = 1 };

        MapLocationData escapePod = new MapLocationData();
        escapePod.Coordinates = coordinates;
        escapePod.Name = "Escape Pod";
        escapePod.Description =
            "You’ve made it to the escape pod. The hum of the engines fills the air as you prepare to launch. " +
            "The hatch closes, and with a roar, the pod ejects from the station, leaving the horrors behind...";
        escapePod.IsAccessible = true;
        escapePod.IsInteractable = true;
        escapePod.Items = new Item[0];

        Interaction escape = GenerateEscape();
        escapePod.Interaction = escape;

        escapePod.AllowsTravel = new bool[] { false, true, true, false };

        Locations[coordinates] = escapePod;
    }

    #endregion // Location Generation

    #region Item Generation
    private Item GenerateFlare()
    {
        return new Item { Type = ItemType.Tool, Description = "A small emergency flare. It might come in handy in dark places." };
    }

    private Item GenerateMedkit()
    {
        return new Item { Type = ItemType.Healing, Description = "A standard medkit. Essential for survival in hostile environments." };
    }

    private Item GenerateAccessKey()
    {
        return new Item { Type = ItemType.KeyItem, Description = "An access keycard for restricted areas of the station." };
    }
    #endregion

    #region Interaction Generation

    private Interaction GenerateEngineer()
    {
        return new NPCInteraction(
            "A weary engineer, barely holding onto his sanity. 'Do you have a way out of here?' he asks.",
            new[] { "Ask about station status", "Ask about the Xenomorph", "Leave" },
            new[] { "The station is falling apart... it's only a matter of time.", "Something is hunting us. Stay quiet.", "Good luck out there." },
            _map);
    }

    private Interaction GenerateDoctor()
    {
        return new NPCInteraction(
            "A doctor in a tattered lab coat. 'I can help you, but supplies are running low.'",
            new[] { "Ask for medical supplies", "Ask about recent incidents", "Leave" },
            new[] { "Here, take this medkit. Use it wisely.", "People have been disappearing... be careful.", "Stay safe out there." },
            _map);
    }

    private Interaction GenerateAndroid()
    {
        return new NPCInteraction(
            "A synthetic stands motionless, its lifeless eyes staring into the void. 'How can I assist you?'",
            new[] { "Ask about station logs", "Attempt to disable", "Leave" },
            new[] { "Accessing logs... Most files are corrupted.", "Warning: Unauthorized action detected.", "Standing by." },
            _map);
    }

    private Interaction GenerateCreature()
    {
        return new NPCInteraction(
            "A monstrous creature emerges from the shadows, its eyes gleaming with hunger. 'You shouldn't have come here,' it growls.",
            new[] { "Try to fight", "Attempt to run", "Scream for help" },
            new[] { "The creature overpowers you. There's no escaping it...", "You manage to break free and flee, but you're still in danger.", "The creature's attack is fatal. Game over." },
            _map);
    }

    private Interaction GenerateEscape()
    {
        return new NPCInteraction(
            "You have successfully entered the escape pod. As the station fades into the distance, you can't help but feel relief. 'We made it,' you whisper to yourself.",
            new[] { "Exit the pod", "Check the pod systems", "Leave" },
            new[] { "You safely exit the pod on a nearby station.", "The pod's systems are stable. It's time to leave this nightmare behind.", "The escape was successful, but the journey is far from over." },
            _map);
    }

    #endregion

    #endregion // METHODS
}

public struct MapLocationData
{
    public Vector2Int Coordinates;
    public string Name;
    public string Description;
    public bool IsAccessible;
    public bool IsInteractable;
    public Interaction Interaction;
    public Item[] Items;
    public bool[] AllowsTravel;

    public MapLocationData()
    {
        Coordinates = new Vector2Int();
        Name = "";
        Description = "";
        IsAccessible = false;
        IsInteractable = false;
        Interaction = null;
        Items = new Item[0];
        AllowsTravel = new bool[4];
    }
}