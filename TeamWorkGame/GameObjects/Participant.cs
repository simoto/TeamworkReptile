namespace TeamWorkGame.GameObjects
{
    using System;

    public class Participant
    {
        public Participant(string name, int level, int score)
        {
            this.Name = name;
            this.Level = level;
            this.Score = score;
        }

        public string Name { get; set; }

        public int Level { get; set; }

        public int Score { get; set; }
    }
}