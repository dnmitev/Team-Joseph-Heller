namespace Game
{
    using System;

    public class GameException: ApplicationException
    {
        //field
        public string ExMessage { get; set; }
        //construktors
        public GameException(string ExMessage)
        :base(ExMessage)
        {
            
        }

        public GameException(string ExMessage, Exception innerEx)
            : base(ExMessage, innerEx)
        {

        }
    }
}
