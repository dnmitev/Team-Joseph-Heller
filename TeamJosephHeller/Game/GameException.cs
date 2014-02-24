namespace NinjaWars
{
    using System;

    public class GameException : ApplicationException
    {
        //field
        public string ExMessage { get; set; }

        //constructors
        public GameException(string еxMessage)
            : base(ExMessage)
        {

        }

        public GameException(string еxMessage, Exception innerEx)
            : base(ExMessage, innerEx)
        {

        }
    }
}
