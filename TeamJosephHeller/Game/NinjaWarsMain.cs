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

            //Item item = new Item(
            //            new MatrixCoord(
            //                  GameHouseKeeping.RandomGenerator.Next(0, GameBorder.WorldRows / 2),
            //                  GameHouseKeeping.RandomGenerator.Next(0, GameBorder.WorldCols - 1)
            //                           ));

            //gameEngine.AddObject(item);

            //List<GameObject> produced =  GenerateRandomObject();

            //foreach (var item in produced)
            //{
            //    gameEngine.AddObject(item);
            //}

            gameEngine.Run();

        }

        //    static List<GameObject> GenerateRandomObject()
        //    {
        //        MatrixCoord initialCoord = new MatrixCoord(0, GameHouseKeeping.RandomGenerator.Next(0, GameBorder.WorldCols - 1));

        //        List<GameObject> produced = new List<GameObject>();

        //        int objetcTypeIndex = GameHouseKeeping.RandomGenerator.Next(0, 2);

        //        switch (objetcTypeIndex)
        //        {
        //            case 0:
        //                produced.Add(new Item(initialCoord));
        //                break;
        //            case 1:
        //                produced.Add(new EnemyShip(initialCoord.Col));
        //                break;
        //            default:
        //                break;
        //        }

        //        return produced;
        //        //MatrixCoord particlePos = objectParameter.Position;

        //        //int itemRowSpeed = GameHouseKeeping.RandomGenerator.Next(objectParameter.MinSpeedCoord, objectParameter.MaxSpeedCoord + 1);
        //        //int itemColSpeed = .Next(objectParameter.MinSpeedCoord, objectParameter.MaxSpeedCoord + 1);

        //        //MatrixCoords particleSpeed = new MatrixCoords(itemRowSpeed, itemColSpeed);

        //        //Particle generated = null;

        //        //int particleTypeIndex = objectParameter.RandomGenerator.Next(0, 2);

        //        //switch (particleTypeIndex)
        //        //{
        //        //    case 0: 
        //        //        generated = new Particle(particlePos, particleSpeed); break;
        //        //    case 1:
        //        //        uint lifespan = (uint)objectParameter.RandomGenerator.Next(8);
        //        //        generated = new DyingParticle(particlePos, particleSpeed, lifespan);
        //        //        break;
        //        //    default:
        //        //        throw new Exception("No such particle for this particleTypeIndex");
        //        //        break;
        //        //}

        //        //return generated;
        //    }
        //}
    }
}
