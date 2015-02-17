namespace TeamWorkGame.GameObjects
{
    using System.Collections.Generic;

    public class Ranking
    {
        public Ranking()
        {
            this.TopPlayers = new Dictionary<string, int[]>();
        }

        public Dictionary<string, int[]> TopPlayers { get; set; }
    }
}
