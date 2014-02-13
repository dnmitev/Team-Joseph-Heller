namespace NinjaWars
{
    using System;

    public class GameException : ApplicationException
    {
        //field
        public string ExMessage { get; set; }

        //constructors
        public GameException(string ExMessage)
            : base(ExMessage)
        {

        }

        public GameException(string ExMessage, Exception innerEx)
            : base(ExMessage, innerEx)
        {

        }
    }
}
