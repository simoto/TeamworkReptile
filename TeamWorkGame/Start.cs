namespace TeamWorkGame
{
    using System;
    using TeamWorkGame.Data;
    using TeamWorkGame.GameObjects;
    using TeamWorkGame.Interfaces;

    class Start
    {
        const int Height = 20;
        const int Width = 50;
        const string Title = "ReptileMovingBox";
        static LevelLoader levelLoader;
        static IRenderer renderer;
        static Player player;
        static IUserInterface ui;

        static void Main()
        {
            Console.Title = Title;
            Console.WindowHeight = Height;
            Console.WindowWidth = Width;
            ui = new KeyboardInterface();

            //TODO: Here is the start point of the game

            //TODO: MainMenu must be here with user choose
            player = new Player("Test", 1);

            //TODO: MapLoader loads the current map with current user
            levelLoader = new LevelLoader();
            char[,] currentMap = levelLoader.LoadLevel(1);

            //TODO: Render current map
            renderer = new ConsoleRenderer();
            renderer.RenderMap(currentMap);
            

            //TODO: Here will be the game loop, KeyboardInterface usage
            while (true)
            {
                renderer.RenderPlayer(player);
                Console.SetCursorPosition(40, 0);
                ConsoleKeyInfo pressedKey = Console.ReadKey();

                ui.ProcessInput(pressedKey);
            }
        }
    }
}
