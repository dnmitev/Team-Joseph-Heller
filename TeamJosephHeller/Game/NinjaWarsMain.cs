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

            PlayerShip player = new PlayerShip(5);
            gameEngine.AddPlayer(player);

            gameEngine.AddObject(player);

            EnemyShip enemy = new EnemyShip(7);
            gameEngine.AddObject(enemy);

            gameEngine.Run();
        }
    }
}
