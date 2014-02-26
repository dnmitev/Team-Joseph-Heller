namespace NinjaWars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NinjaWars.Interfaces;

    public class NinjaWarsMain
    {
        private static void Main()
        {
            //set console size and Intro
            Console.SetWindowSize(80, 35);

            Intro.Title();

            IRenderer renderer = new ConsoleRenderer(GameBorder.WorldRows, GameBorder.WorldCols);
            IUserInterface keyboard = KeyboardInterface.Instance;

            Engine gameEngine = new Engine(renderer, keyboard);

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

            PlayerShip player = new PlayerShip(5);
            gameEngine.AddPlayer(player);

            gameEngine.AddObject(player);

            EnemyShip enemy = new EnemyShip(5);
            gameEngine.AddObject(enemy);

            Item item = new Item(
                new MatrixCoord(
                    GameHouseKeeping.RandomGenerator.Next(0, GameBorder.WorldRows / 2),
                    GameHouseKeeping.RandomGenerator.Next(0, GameBorder.WorldCols - 1)));

            gameEngine.AddObject(item);

            List<GameObject> produced = GenerateRandomObject();

            foreach (var obj in produced)
            {
                gameEngine.AddObject(obj);
            }

            gameEngine.Run();
        }

        private static List<GameObject> GenerateRandomObject()
        {
            MatrixCoord initialCoord = new MatrixCoord(0, GameHouseKeeping.RandomGenerator.Next(0, GameBorder.WorldCols - 1));

            List<GameObject> produced = new List<GameObject>();

            int objetcTypeIndex = GameHouseKeeping.RandomGenerator.Next(0, 2);

            switch (objetcTypeIndex)
            {
                case 0:
                    produced.Add(new Item(initialCoord));
                    break;
                case 1:
                    produced.Add(new EnemyShip(initialCoord.Col));
                    break;
                default:
                    break;
            }

            return produced;
        }
    }
}