namespace TeamWorkGame.GameObjects
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Media;
    using TeamWorkGame.Data;
    using TeamWorkGame.Interfaces;

    [Serializable]
    public class PushTheBox : IGame
    {
        private string gameName = "PushTheBox";
        private IRenderer renderer;
        private Player player;
        private SingleElement[,] map;

        public PushTheBox(IRenderer renderer, Player player, SingleElement[,] map)
        {
            this.Renderer = renderer;
            this.Player = player;
            this.Map = map;
            this.Init();
        }

        public event PropertyChangedEventHandler PropertyChanged;

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

        public string GameName
        {
            get
            {
                return this.gameName;
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

        public void Init()
        {
            this.SetPlayerPosition();
            this.renderer.RenderMap(this.map);
            this.renderer.RenderInGameMenu();
            this.renderer.RenderPlayer(this.player);
            this.renderer.RenderPlayerInfo(this.player);
        }

        public void Exit()
        {
            SystemSounds.Beep.Play();
            Environment.Exit(0);
        }

        public void Move(Direction direction)
        {
            // TODO check if ref is still needed
            if (direction == Direction.Left)
            {
                this.Move(0, -1, Direction.Left);
            }
            else if (direction == Direction.Right)
            {
                this.Move(0, 1, Direction.Right);
            }
            else if (direction == Direction.Up)
            {
                this.Move(-1, 0, Direction.Up);
            }
            else if (direction == Direction.Down)
            {
                this.Move(1, 0, Direction.Down);
            }

            bool isLevelOver = this.CheckIfLevelIfOver();

            if (isLevelOver)
            {
                this.ProcessLevel();
            }
        }

        public void Save(IStorage storage)
        {
            bool isSaved = storage.Save(this);
            if (isSaved)
            {
                SystemSounds.Asterisk.Play();
            }
            else
            {
                // TODO not saved message
            }
        }

        public void Load(IStorage storage, string gameName, string userName, string password)
        {
            PushTheBox game = (PushTheBox)storage.Load(gameName, userName, password);
            if (game != null)
            {
                this.renderer = game.renderer;
                this.player = game.player;
                this.map = game.map;
                this.Init();
            }
            else
            {
                // TODO error message
            }
        }

        public void RestartLevel()
        {
            this.map = LevelLoader.LoadLevel(this.player.Level);
            this.SetPlayerPosition();
            this.renderer.RenderMap(this.map);
            this.renderer.RenderInGameMenu();
            this.renderer.RenderPlayer(this.player);
            this.renderer.RenderPlayerInfo(this.player);
        }

        public void StartNewGame()
        {
            this.map = LevelLoader.LoadLevel(1);
            this.SetPlayerPosition();
            this.player.Level = 1;
            this.player.Moves = 0;
            this.renderer.RenderMap(this.map);
            this.renderer.RenderInGameMenu();
            this.renderer.RenderPlayer(this.player);
            this.renderer.RenderPlayerInfo(this.player);
        }

        private void Move(int rowMove, int colMove, Direction direction)
        {
            int playerRow = this.player.Position.Row;
            int playerCol = this.player.Position.Col;
            int newRow = playerRow + rowMove;
            int newCol = playerCol + colMove;
            int rowNextToNewRow = playerRow + (2 * rowMove);
            int colNextToNewCol = playerCol + (2 * colMove);

            bool isNearBox = this.map[newRow, newCol].Symbol == 'K';

            if (this.map[newRow, newCol].IsSolid)
            {
                SystemSounds.Hand.Play();
            }
            else if (isNearBox && (this.map[rowNextToNewRow, colNextToNewCol].IsSolid
                || this.map[rowNextToNewRow, colNextToNewCol].Symbol == 'K'))
            {
                //// next to K is solid or another K
                SystemSounds.Hand.Play();
            }
            else if (isNearBox && this.map[rowNextToNewRow, colNextToNewCol].Symbol == ' ')
            {
                this.map[rowNextToNewRow, colNextToNewCol].Symbol = 'K';
                this.map[rowNextToNewRow, colNextToNewCol].Color = ConsoleColor.Cyan;
                this.map[newRow, newCol].Symbol = ' ';

                this.renderer.RenderSingleElement(this.map[rowNextToNewRow, colNextToNewCol], rowNextToNewRow, colNextToNewCol);
                this.renderer.RenderSingleElement(this.map[newRow, newCol], newRow, newCol);
                this.renderer.RenderSingleElement(this.map[playerRow, playerCol], playerRow, playerCol);
                this.player.Move(direction);
                this.player.Moves++;
                this.renderer.RenderPlayer(this.player);
                this.renderer.RenderPlayerInfo(this.player);
            }
            else if (isNearBox && this.map[rowNextToNewRow, colNextToNewCol].Symbol == '*')
            {
                this.map[rowNextToNewRow, colNextToNewCol].Symbol = '@';
                this.map[rowNextToNewRow, colNextToNewCol].IsSolid = true;
                this.map[newRow, newCol].Symbol = ' ';

                this.renderer.RenderSingleElement(this.map[rowNextToNewRow, colNextToNewCol], rowNextToNewRow, colNextToNewCol);
                this.renderer.RenderSingleElement(this.map[newRow, newCol], newRow, newCol);
                this.renderer.RenderSingleElement(this.map[playerRow, playerCol], playerRow, playerCol);

                this.player.Move(direction);
                this.player.Moves++;
                this.renderer.RenderPlayer(this.player);
                this.renderer.RenderPlayerInfo(this.player);
                SystemSounds.Asterisk.Play();
            }
            else if (!this.map[newRow, newCol].IsSolid)
            {
                this.renderer.RenderSingleElement(this.map[playerRow, playerCol], playerRow, playerCol);
                this.player.Move(direction);
                this.player.Moves++;
                this.renderer.RenderPlayer(this.player);
                this.renderer.RenderPlayerInfo(this.player);
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

            return true;
        }

        private void ProcessLevel()
        {
            int currentLevel = this.player.Level;

            if (currentLevel == 5)
            {
                this.EvalRanking();
            }
            else
            {
                this.LoadNextLevel(currentLevel);
            }
        }

        private void LoadNextLevel(int currentLevel)
        {
            int nextLevel = currentLevel + 1;
            this.map = LevelLoader.LoadLevel(nextLevel);
            this.player.Level = nextLevel;
            this.SetPlayerPosition();
            this.renderer.RenderMap(this.map);
            this.renderer.RenderInGameMenu();
            this.renderer.RenderPlayer(this.player);
            this.renderer.RenderPlayerInfo(this.player);
        }

        private void EvalRanking()
        {
            Participant participant = new Participant(this.player.Name, this.player.Level, this.player.Moves);
            List<Participant> ranking = RankingManager.Save(participant);
            this.renderer.RenderGameOver(ranking);
        }
    }
}
