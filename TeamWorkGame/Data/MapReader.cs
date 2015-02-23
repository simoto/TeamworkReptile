using TeamWorkGame.GameObjects;
namespace TeamWorkGame.Data
{
    public class MapReader
    {
        public static void SetPlayerPossition(Player player, SingleElement[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j].Symbol == 'H')
                    {
                        player.Position.Row = i;
                        player.Position.Col = j;
                        map[i, j].Symbol = ' ';
                        return;
                    }
                }
            }
        }
    }
}
