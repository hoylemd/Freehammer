using System;

namespace FreeHammer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (FreehammerCore game = new FreehammerCore())
            {
                game.Run();
            }
        }
    }
}

