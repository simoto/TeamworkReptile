﻿namespace TeamWorkGame
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
            
            player = new Player("BaiIvan", 1, "somePass");
            SingleElement[,] currentMap = LevelLoader.LoadLevel(1);
            PushTheBox currentGame = new PushTheBox(renderer, player, currentMap);

            while (true)
            {
                ui.ProcessInput(currentGame);
            }
        }
    }
}
