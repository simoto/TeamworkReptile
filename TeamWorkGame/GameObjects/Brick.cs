namespace TeamWorkGame.GameObjects
{
    using System;

    class Brick
    {
        public Brick(ConsoleColor color, char symbol)
        {
            this.Color = color;
            this.Symbol = symbol;
        }

        public ConsoleColor Color { get; set; }

        public char Symbol { get; set; }
    }
}
