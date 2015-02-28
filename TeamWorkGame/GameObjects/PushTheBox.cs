namespace TeamWorkGame.GameObjects
{
    using System;
    using System.Media;
    using TeamWorkGame.Data;
    using TeamWorkGame.Interfaces;

    public class PushTheBox : IGame
    {
        private IRenderer renderer;
        private Player player;
        private SingleElement[,] map;

        public PushTheBox(IRenderer renderer, Player player, SingleElement[,] map)
        {
            this.Renderer = renderer;
            this.Player = player;
            this.Map = map;
        }

        public IRenderer Renderer
        {
            get
            {
                return this.renderer;
            }
            set
            {
                this.renderer = value;
            }
        }

        public Player Player
        {
            get
            {
                return this.player;
            }
            set
            {
                this.player = value;
            }
        }

        public SingleElement[,] Map
        {
            get
            {
                return this.map;
            }
            set
            {
                this.map = value;
            }
        }

        public void Move(Direction direction)
        {
            // TODO check if ref is still needed
            if (direction == Direction.Left)
            {
                this.Move(0, -1, Direction.Left, this.player, ref map, renderer);
            }
            else if (direction == Direction.Right)
            {
                this.Move(0, 1, Direction.Right, player, ref map, renderer);
            }
            else if (direction == Direction.Up)
            {
                this.Move(-1, 0, Direction.Up, player, ref map, renderer);
            }
            else if (direction == Direction.Down)
            {
                this.Move(1, 0, Direction.Down, player, ref map, renderer);
            }
        }

        public void Save(Save save)
        {
            SaveManager.Save(this.map, this.player);
            SystemSounds.Asterisk.Play();
            Environment.Exit(0);
        }

        public Save Load(string userName, string password)
        {
            //TODO
            throw new System.NotImplementedException();
        }

        public void RestartLevel()
        {
            this.map = LevelLoader.LoadLevel(this.player.Level);
            this.SetPlayerPosition();
            renderer.RenderMap(this.map);
            renderer.RenderInGameMenu();
            renderer.RenderPlayer(this.player);
            renderer.RenderPlayerInfo(this.player);
        }

        public void StartNewGame()
        {
            this.map = LevelLoader.LoadLevel(1);
            this.SetPlayerPosition();
            player.Level = 1;
            player.Moves = 0;
            renderer.RenderMap(this.map);
            renderer.RenderInGameMenu();
            renderer.RenderPlayer(this.player);
            renderer.RenderPlayerInfo(this.player);
        }

        private void Move(int rowMove, int colMove, Direction direction, Player player, ref SingleElement[,] currentMap, IRenderer renderer)
        {
            int playerRow = player.Position.Row;
            int playerCol = player.Position.Col;
            int newRow = playerRow + rowMove;
            int newCol = playerCol + colMove;
            int rowNextToNewRow = playerRow + (2 * rowMove);
            int colNextToNewCol = playerCol + (2 * colMove);

            bool isNearBox = currentMap[newRow, newCol].Symbol == 'K';

            if (currentMap[newRow, newCol].IsSolid)
            {
                SystemSounds.Hand.Play();
            }
            else if (isNearBox && (currentMap[rowNextToNewRow, colNextToNewCol].IsSolid
                || currentMap[rowNextToNewRow, colNextToNewCol].Symbol == 'K'))
            {
                //// next to K is solid or another K
                SystemSounds.Hand.Play();
            }
            else if (isNearBox && currentMap[rowNextToNewRow, colNextToNewCol].Symbol == ' ')
            {
                currentMap[rowNextToNewRow, colNextToNewCol].Symbol = 'K';
                currentMap[rowNextToNewRow, colNextToNewCol].Color = ConsoleColor.Cyan;
                currentMap[newRow, newCol].Symbol = ' ';

                renderer.RenderSingleElement(currentMap[rowNextToNewRow, colNextToNewCol], rowNextToNewRow, colNextToNewCol);
                renderer.RenderSingleElement(currentMap[newRow, newCol], newRow, newCol);
                renderer.RenderSingleElement(currentMap[playerRow, playerCol], playerRow, playerCol);
                player.Move(direction);
                player.Moves++;
                renderer.RenderPlayerInfo(player);
            }
            else if (isNearBox && currentMap[rowNextToNewRow, colNextToNewCol].Symbol == '*')
            {
                currentMap[rowNextToNewRow, colNextToNewCol].Symbol = '@';
                currentMap[rowNextToNewRow, colNextToNewCol].IsSolid = true;
                currentMap[newRow, newCol].Symbol = ' ';

                renderer.RenderSingleElement(currentMap[rowNextToNewRow, colNextToNewCol], rowNextToNewRow, colNextToNewCol);
                renderer.RenderSingleElement(currentMap[newRow, newCol], newRow, newCol);
                renderer.RenderSingleElement(currentMap[playerRow, playerCol], playerRow, playerCol);

                player.Move(direction);
                player.Moves++;
                renderer.RenderPlayerInfo(player);
                SystemSounds.Asterisk.Play();
            }
            else if (!currentMap[newRow, newCol].IsSolid)
            {
                renderer.RenderSingleElement(currentMap[playerRow, playerCol], playerRow, playerCol);
                player.Move(direction);
                player.Moves++;
                renderer.RenderPlayerInfo(player);
            }
        }

        private void SetPlayerPosition()
        {
            for (int i = 0; i < this.map.GetLength(0); i++)
            {
                for (int j = 0; j < this.map.GetLength(1); j++)
                {
                    if (this.map[i, j].Symbol == 'H')
                    {
                        this.player.Position.Row = i;
                        this.player.Position.Col = j;
                        this.map[i, j].Symbol = ' ';
                        return;
                    }
                }
            }
        }

        private bool CheckIfLevelIfOver()
        {
            for (int i = 0; i < this.map.GetLength(0); i++)
            {
                for (int j = 0; j < this.map.GetLength(1); j++)
                {
                    if (this.map[i, j].Symbol == '*')
                    {
                        return false;
                    }
                }
            }

            int currentLevel = this.player.Level;

            if (currentLevel == 5)
            {
                //TODO
                //RankingManager.Save(this.player);
            }
            else
            {
                LoadNextLevel(currentLevel);
            }

            return true;
        }


        private void LoadNextLevel(int currentLevel)
        {
            int nextLevel = currentLevel + 1;
            this.map = LevelLoader.LoadLevel(nextLevel);
            this.player.Level = nextLevel;
            this.SetPlayerPosition();
            renderer.RenderMap(this.map);
            renderer.RenderInGameMenu();
            renderer.RenderPlayerInfo(this.player);
        }
    }
}
