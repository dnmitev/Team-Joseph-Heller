namespace NinjaWars
{
    using System;
    using System.Linq;
    using System.Media;
    using NinjaWars.Interfaces;

    internal class KeyboardInterface : IUserInterface
    {
        private static readonly KeyboardInterface instance;

        private readonly SoundPlayer shoot = new SoundPlayer(@"..\..\Sounds\Shot.wav");

        // Initialize the single instance
        static KeyboardInterface()
        {
            instance = new KeyboardInterface();
        }

        // Private constructor – protects direct instantiation
        private KeyboardInterface()
        {
        }

        public event EventHandler OnLeftPressed;

        public event EventHandler OnRightPressed;

        public event EventHandler OnActionPressed;

        // The property for taking the single instance
        public static KeyboardInterface Instance
        {
            get
            {
                return instance;
            }
        }

        public void ProcessInput()
        {
            while (Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey();

                if (keyInfo.Key.Equals(ConsoleKey.LeftArrow))
                {
                    if (this.OnLeftPressed != null)
                    {
                        this.OnLeftPressed(KeyboardInterface.Instance, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.RightArrow))
                {
                    if (this.OnRightPressed != null)
                    {
                        this.OnRightPressed(KeyboardInterface.Instance, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.Spacebar))
                {
                    if (this.OnActionPressed != null)
                    {
                        this.shoot.Play();
                        this.OnActionPressed(KeyboardInterface.Instance, new EventArgs());
                    }
                }
            }
        }
    }
}