namespace NinjaWars
{
    using System;

    public class MaxScoreAchievedException : ApplicationException
    {

        public MaxScoreAchievedException(string msg)
            : base(msg)
        {           
        }

        public MaxScoreAchievedException(string exMessage, Exception innerEx)
            : base(exMessage, innerEx)
        {
        }
    }
}
