namespace TeamWorkGame
{
    using System;
    using System.Collections.Generic;
    using TeamWorkGame.Data;
    using TeamWorkGame.GameObjects;
    using TeamWorkGame.Interfaces;

    internal class Start
    {
        private const int Height = 20;
        private const int Width = 50;
        private const string Title = "ReptileMovingBox";
        private static IRenderer renderer;
        private static Player player;
        private static IUserInterface ui;
        private static List<Participant> ranking;

        internal static void Main()
        {
            Console.Title = Title;
            Console.WindowHeight = Height;
            Console.WindowWidth = Width;

            ui = new KeyboardInterface();
            ranking = RankingManager.Load();
            renderer = new ConsoleRenderer();
            ////TODO: Here is the start point of the game
            
            ////TODO: MainMenu must be here with user choose
            
            player = new Player("Test", 1, "somePass");
            ////TODO: MapLoader loads the current map with current user
            SingleElement[,] currentMap = LevelLoader.LoadLevel(1);
            MapReader.SetPlayerPosition(player, currentMap);

            ////TODO: Render current map
            
            renderer.RenderMap(currentMap);
            renderer.RenderInGameMenu();
            renderer.RenderMoves(player.Moves);
            ////TODO: Here will be the game loop, KeyboardInterface usage
            while (true)
            {
                renderer.RenderPlayer(player);
                Console.SetCursorPosition(20, 11);
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                if (MapReader.CheckIfLevelIfOver(player, currentMap))
                {
                    int currentLevel = player.Level;
                    if (currentLevel == 5)
                    {
                        RankingManager.Save(ranking, new Participant(player.Name, player.Level, player.Moves));
                        return;
                    }
                    else
                    {
                        currentMap = LevelLoader.LoadLevel(currentLevel + 1);
                        player.Level = currentLevel + 1;
                        MapReader.SetPlayerPosition(player, currentMap);
                        renderer.RenderMap(currentMap);
                        renderer.RenderInGameMenu();
                    }
                }

                ui.ProcessInput(pressedKey, player, ref currentMap, renderer);
            }
        }
    }
}
