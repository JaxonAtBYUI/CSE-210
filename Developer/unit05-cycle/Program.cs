using Unit05.Game.Casting;
using Unit05.Game.Directing;
using Unit05.Game.Scripting;
using Unit05.Game.Services;


namespace Unit05
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // create the cast
            Cast cast = new Cast();
            cast.AddActor("snake", new Snake(new Color(255, 0, 0), 300));
            cast.AddActor("snake", new Snake(new Color(0, 255, 0), 600));

            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
           
            // create the script
            Script script = new Script();
            script.AddAction("input", new ControlPlayerOne(keyboardService));
            script.AddAction("input", new ControlPlayerTwo(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new GrowPlayers());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}