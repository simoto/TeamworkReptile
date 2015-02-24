namespace TeamWorkGame.Data
{
    using TeamWorkGame.GameObjects;

    public class MapReader
    {
        public static void SetPlayerPosition(Player player, SingleElement[,] map)
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

        public static bool CheckIfLevelIfOver(Player player, SingleElement[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j].Symbol == '*')
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
