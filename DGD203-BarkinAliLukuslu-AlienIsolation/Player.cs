namespace FirstGame
{
    public class Player
    {
        public string? Name { get; private set; }
        
        public Player(string? name = "Amanda Ripley")
        {
            Name = name;
        }

        public void SetUp(string? name)
        {
            Name = name;
        }
    }
}