namespace TeamWorkGame
{
    using System;
    using TeamWorkGame.Data;

    class Start
    {
        static int height = 50, width = 50;
        static LevelLoader levelLoader;
        static ConsoleRenderer renderer;

        static void Main()
        {
            Console.Title = "ReptileMovingBox";
            Console.WindowHeight = height;
            Console.WindowWidth = width;

            //TODO: Here is the start point of the game
            //TODO: MainMenu must be here with user choose

            //TODO: MapLoader loads the current map with current user
            levelLoader = new LevelLoader();
            char[,] currentMap = levelLoader.LoadLevel(1);

            //TODO: Render current map
            renderer = new ConsoleRenderer();
            renderer.RenderMap(currentMap);

            //TODO: Here will be the game loop, KeyboardInterface
        }
    }
}
