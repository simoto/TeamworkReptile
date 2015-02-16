namespace TeamWorkGame.GameObjects
{
    using System;

    public class SingleElement
    {
        public SingleElement(ConsoleColor color, char symbol)
        {
            this.Color = color;
            this.Symbol = symbol;
        }

        public ConsoleColor Color { get; set; }

        public char Symbol { get; set; }
    }
}
