namespace NinjaWars.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IObjectProducer
    {
        IEnumerable<GameObject> ProduceObjects();
    }
}
