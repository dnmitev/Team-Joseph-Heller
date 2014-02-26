Enter file contents hereusing System;

namespace NinjaWars
{
    class InfoBox
    {
        private InfoBox()
        {

        }

        public static void GameInfo(uint numberOfLives)
        {
            Console.SetCursorPosition(65, 10);
            Console.Write("Lives left:{0}",numberOfLives);
        }
         
    }
}
