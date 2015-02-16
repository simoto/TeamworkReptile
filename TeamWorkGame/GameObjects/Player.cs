namespace TeamWorkGame.GameObjects
{
    using TeamWorkGame.Data;
    using TeamWorkGame.Interfaces;

    public class Player : IMovable
    {
        public Player(string name, int level)
        {
            this.Name = name;
            this.Level = level;
        }

        public string Name { get; set; }

        public Position Position { get; set; }

        public int Level { get; set; }

        public int Score { get; set; }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    this.Position.Row += -1;
                    break;
                case Direction.Down:
                    this.Position.Row += 1;
                    break;
                case Direction.Left:
                    this.Position.Col += -1;
                    break;
                case Direction.Right:
                    this.Position.Col += 1;
                    break;
                default:
                    break;
            }
        }
    }
}
