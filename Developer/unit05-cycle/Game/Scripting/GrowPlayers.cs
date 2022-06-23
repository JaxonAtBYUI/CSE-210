using System.Collections.Generic;
using Unit05.Game.Casting;



namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that grows the tails of each player.</para>
    /// <para>The responsibility of GrowPlayers is to grow the tail of each player each frame.</para>
    /// </summary>
    public class GrowPlayers : Action
    {

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public GrowPlayers() {}

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            List<Actor> players = cast.GetActors("snake");
            foreach(Actor player in players) {
                Snake snake = (Snake)player;
                snake.GrowTail(1);
            }
        }
    }
}