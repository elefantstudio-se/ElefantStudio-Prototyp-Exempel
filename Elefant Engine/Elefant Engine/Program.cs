using System;

namespace SnabelEngine
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (PlatformEngine game = new PlatformEngine())
            {
                game.Run();
            }
        }
    }
#endif
}