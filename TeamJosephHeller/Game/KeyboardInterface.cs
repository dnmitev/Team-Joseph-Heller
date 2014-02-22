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
                        this.OnActionPressed(KeyboardInterface.Instance, new EventArgs());
                    }
                }
            }
        }

        public event EventHandler OnLeftPressed;

        public event EventHandler OnRightPressed;

        public event EventHandler OnActionPressed;
    }
}
