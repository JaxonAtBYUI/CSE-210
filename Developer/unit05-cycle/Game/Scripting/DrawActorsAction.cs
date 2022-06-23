using System.Collections.Generic;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Snake snakeP1 = (Snake)cast.GetNthActor("snake", 0);
            Snake snakeP2 = (Snake)cast.GetNthActor("snake", 1);
            List<Actor> segmentsP1 = snakeP1.GetSegments();
            List<Actor> segmentsP2 = snakeP2.GetSegments();
            List<Actor> messages = cast.GetActors("messages");
            
            videoService.ClearBuffer();
            videoService.DrawActors(segmentsP1);
            videoService.DrawActors(segmentsP2);
            videoService.DrawActors(messages);
            videoService.FlushBuffer();
        }
    }
}