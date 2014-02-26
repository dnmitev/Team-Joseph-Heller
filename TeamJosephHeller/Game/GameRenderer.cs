namespace NinjaWars
{
    using NinjaWars.Interfaces;
    using System;

    public class GameRenderer : ConsoleRenderer
    {

        private static MatrixCoord GetWindowSizes(GameBorder border, PlayerInformation playerInformation)
        {
            int rows = Math.Max(border.GetTopLeft().Row + border.GetImage().GetUpperBound(0), playerInformation.GetTopLeft().Row + playerInformation.GetImage().GetUpperBound(0));
            int cols = Math.Max(border.GetTopLeft().Col + border.GetImage().GetUpperBound(1), playerInformation.GetTopLeft().Col + playerInformation.GetImage().GetUpperBound(1));

            return new MatrixCoord(rows, cols);
        }

        GameBorder gameFieldBorders;
        PlayerInformation playerInformation;

        public GameRenderer(GameBorder border, PlayerInformation playerInformation)
            : base(GameRenderer.GetWindowSizes(border, playerInformation).Row + 5, GameRenderer.GetWindowSizes(border, playerInformation).Col + 5)
             
        {
            this.gameFieldBorders = border;
            this.playerInformation = playerInformation;      
        }


        public override void EnqueueForRendering(IRenderable obj)
        {
            if(this.IsInsideGameArea(obj))
                    base.EnqueueForRendering(obj);
        }

        public override void ClearQueue()
        {
            base.ClearQueue();
            if(this.gameFieldBorders != null)   base.EnqueueForRendering(this.gameFieldBorders);
            if (this.playerInformation != null) base.EnqueueForRendering(this.playerInformation);
        }

        private bool IsInsideGameArea(IRenderable obj)
        {
            if (obj.GetTopLeft().Row < this.gameFieldBorders.GetTopLeft().Row || obj.GetTopLeft().Col < this.gameFieldBorders.GetTopLeft().Col) return false;
            if (obj.GetTopLeft().Row + obj.GetImage().GetUpperBound(0) > this.gameFieldBorders.GetTopLeft().Row + this.gameFieldBorders.GetImage().GetUpperBound(0)) return false;
            if (obj.GetTopLeft().Col + obj.GetImage().GetUpperBound(1) > this.gameFieldBorders.GetTopLeft().Col + this.gameFieldBorders.GetImage().GetUpperBound(1)) return false;
            else return true;
        }
    }
}

