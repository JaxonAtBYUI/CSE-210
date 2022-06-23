using System;
using System.Collections.Generic;
using System.Data;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool isGameOver = false;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                HandleSegmentCollisions(cast);
                HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Sets the game over flag if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            Snake snakeP1 = (Snake)cast.GetNthActor("snake", 0);
            Snake snakeP2 = (Snake)cast.GetNthActor("snake", 1);
            Actor headP1 = snakeP1.GetHead();
            Actor headP2 = snakeP2.GetHead();
            List<Actor> bodyP1 = snakeP1.GetBody();
            List<Actor> bodyP2 = snakeP2.GetBody();

            // Check for collision with player 1
            foreach (Actor segment in bodyP1)
            {
                if ((segment.GetPosition().Equals(headP1.GetPosition())) || (segment.GetPosition().Equals(headP2.GetPosition())))
                {
                    isGameOver = true;
                }
            }

            // Check for collision with player 2
            foreach (Actor segment in bodyP2) {
                if ((segment.GetPosition().Equals(headP1.GetPosition())) || (segment.GetPosition().Equals(headP2.GetPosition()))) {
                    isGameOver = true;
                }
            }
        }

        private void HandleGameOver(Cast cast)
        {
            if (isGameOver == true)
            {
                Snake snakeP1 = (Snake)cast.GetNthActor("snake", 0);
                List<Actor> segmentsP1 = snakeP1.GetSegments();

                Snake snakeP2 = (Snake)cast.GetNthActor("snake", 1);
                List<Actor> segmentsP2 = snakeP2.GetSegments();

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white
                foreach (Actor segment in segmentsP1)
                {
                    segment.SetColor(Constants.WHITE);
                }
                foreach (Actor segment in segmentsP2) {
                    segment.SetColor(Constants.WHITE);
                }
                snakeP1.SetColor(Constants.WHITE);
                snakeP2.SetColor(Constants.WHITE);

            }
        }

    }
}