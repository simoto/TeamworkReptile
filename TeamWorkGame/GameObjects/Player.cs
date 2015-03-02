namespace TeamWorkGame.GameObjects
{
    using System;
    using System.ComponentModel;
    using TeamWorkGame.Data;
    using TeamWorkGame.Interfaces;

    [Serializable()]
    public class Player : IMovable, INotifyPropertyChanged
    {
        public Player()
        {
        }

        public Player(string name, int level, string password)
        {
            this.Name = name;
            this.Password = password;
            this.Level = level;
            this.Moves = 0;
            this.Position = new Position(0, 0);
        }

        public Player(string name, int level, string password, int mooves) : this(name, level, password)
        {
            this.Moves = mooves;
            this.Position = new Position(0, 0);
        }

        public string Name { get; set; }

        public string Password { get; set; }

        public Position Position { get; set; }

        public int Level { get; set; }

        public int Moves { get; set; }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    this.Position.Row--;
                    break;
                case Direction.Down:
                    this.Position.Row++;
                    break;
                case Direction.Left:
                    this.Position.Col--;
                    break;
                case Direction.Right:
                    this.Position.Col++;
                    break;
                default:
                    break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
