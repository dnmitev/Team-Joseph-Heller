namespace NinjaWars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NinjaWars.Interfaces;

    class NinjaWarsMain
    {
        static void Main()
        {
            //set console size and Intro
            Console.SetWindowSize(80, 35);            
            Intro.Title();
            //TODO player menu

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

            gameEngine.Run();
        }
    }
}
