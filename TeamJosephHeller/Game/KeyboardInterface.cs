using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NinjaWars.Interfaces;

namespace NinjaWars
{
    class KeyboardInterface : IUserInterface
    {
        private static KeyboardInterface instance;

        // Initialize the single instance
        static KeyboardInterface()
        {
            instance = new KeyboardInterface();
        }

        // The property for taking the single instance
        public static KeyboardInterface Instance
        {
            get
            {
                return instance;
            }
        }

       // Private constructor – protects direct instantiation
        private KeyboardInterface()
        {
        }

        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey();

                if (keyInfo.Key.Equals(ConsoleKey.LeftArrow))
                {
                    if (this.OnLeftPressed != null)
                    {
                        this.OnLeftPressed(this, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.RightArrow))
                {
                    if (this.OnRightPressed != null)
                    {
                        this.OnRightPressed(this, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.Spacebar))
                {
                    if (this.OnActionPressed != null)
                    {
                        this.OnActionPressed(this, new EventArgs());
                    }
                }
            }
        }

        public event EventHandler OnLeftPressed;

        public event EventHandler OnRightPressed;

        public event EventHandler OnActionPressed;
    }
}
