namespace NinjaWars
{
    using System.Collections.Generic;
    using System;
    using NinjaWars.Interfaces;

    public class PlayerInformation : DisplayableInformation
    {
        private const int fieldInfoMargin = 10;
        private const int linesToDisplay = 3;

        PlayerShip player;

        public PlayerInformation(PlayerShip player, GameBorder borders)
            : base(new MatrixCoord(borders.GetTopLeft().Row, borders.GetTopLeft().Col + borders.GetImage().GetUpperBound(1) + fieldInfoMargin))
        {
            this.player = player;
        }

        public override char[,] GetImage()
        {
            this.Information.Clear();
            this.Information.Add(string.Format("Lifes: {0}", player.Lifes));
            this.Information.Add(string.Format("Health: {0}", player.Health));
            this.Information.Add(string.Format("Score: {0}", player.Score));

            return base.GetImage();
        }
    }
}
