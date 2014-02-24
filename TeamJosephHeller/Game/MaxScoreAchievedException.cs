namespace NinjaWars
{
    using System;

    public class MaxScoreAchievedException : ApplicationException
    {

        public MaxScoreAchievedException(string msg)
            : base(msg)
        {
           
        }


        public MaxScoreAchievedException(string ExMessage, Exception innerEx)
            : base(ExMessage, innerEx)
        {

        }
    }
}
