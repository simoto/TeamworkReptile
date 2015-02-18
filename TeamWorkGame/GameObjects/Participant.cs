namespace TeamWorkGame.GameObjects
{
    using System;

    public class Participant
    {
        public Participant(string name, int level, int moves)
        {
            this.Name = name;
            this.Level = level;
            this.Moves = moves;
        }

        public string Name { get; set; }

        public int Level { get; set; }

        public int Moves { get; set; }
    }
}