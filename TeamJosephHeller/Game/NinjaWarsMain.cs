namespace NinjaWars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NinjaWars.Interfaces;

    public class NinjaWarsMain
    {

        static Engine gameEngine;
        static IUserInterface keyboard;

        private static void Main()
        {
            //set console size and Intro
            Console.SetWindowSize(80, 35);

            Intro.Title();

            InitializeGame();

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerShipLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerShipRight();
            };

            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                gameEngine.AddObject(gameEngine.EngagePlayerWeapons());
            };

            gameEngine.Run();

            End.Title();
        }

        static void InitializeGame()
        {
             GameBorder borders = new GameBorder();
            PlayerShip player = new PlayerShip(5);
            EnemyShip enemy = new EnemyShip(5, new MatrixCoord(0,0));
            Item item = new Item(
                new MatrixCoord(
                    GameHouseKeeping.RandomGenerator.Next(0, GameBorder.WorldRows / 2),
                    GameHouseKeeping.RandomGenerator.Next(0, GameBorder.WorldCols - 1)));

            IRenderer renderer = new GameRenderer(borders, new PlayerInformation(player, borders));
            keyboard = KeyboardInterface.Instance;

            gameEngine = new Engine(renderer, keyboard);

            gameEngine.AddPlayer(player);
            gameEngine.AddObject(player);
            gameEngine.AddObject(enemy);
            gameEngine.AddObject(item);
        }
    }
}