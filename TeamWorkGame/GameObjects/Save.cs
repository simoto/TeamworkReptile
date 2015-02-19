namespace TeamWorkGame.GameObjects
{
    using System;

    public class Save
    {
        public Save()
        {
        }

        public Save(char[,] matrix, int level, int moves)
        {
            this.Matrix = matrix;
            this.Level = level;
            this.Moves = moves;
        }

        public char[,] Matrix { get; set; }

        public int Level { get; set; }

        public int Moves { get; set; }
    }
}
