using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unit04.Game.Casting;
using Unit04.Game.Directing;
using Unit04.Game.Services;


namespace Unit04
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        private static int FRAME_RATE = 12;
        private static int MAX_X = 900;
        private static int MAX_Y = 600;
        private static int CELL_SIZE = 15;
        private static int FONT_SIZE = 15;
        private static int COLS = 60;
        private static int ROWS = 40;
        private static int[] POSSIBLES_SPEEDS = new int[] {1, 2, 3, 5, 6, 10, 15, 19};
        private static string CAPTION = "Greed";
        private static Color WHITE = new Color(255, 255, 255);
        private static int DEFAULT_ARTIFACTS = 140;


        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // create the cast
            Cast cast = new Cast();

            // create the banner
            Actor banner = new Actor();
            banner.SetText("");
            banner.SetFontSize(FONT_SIZE);
            banner.SetColor(WHITE);
            banner.SetPosition(new Point(CELL_SIZE, 0));
            cast.AddActor("banner", banner);

            // create the robot
            Artifact robot = new Artifact();
            robot.SetText("#");
            robot.SetFontSize(FONT_SIZE);
            robot.SetColor(WHITE);
            robot.SetPosition(new Point(MAX_X / 2, MAX_Y-CELL_SIZE));
            robot.SetScore(0);
            cast.AddActor("robot", robot);

            // create the rocks
            Random random = new Random();
            for (int i = 0; i < DEFAULT_ARTIFACTS / 2; i++)
            {
                string text = "O";
                int score = -1;

                int x = random.Next(1, COLS);
                int y = random.Next(1, ROWS - 5);
                int dy = POSSIBLES_SPEEDS[random.Next(0, POSSIBLES_SPEEDS.Length - 1 )];
                Point position = new Point(x, y);
                position = position.Scale(CELL_SIZE);
                Point direction = new Point(0, dy);

                int r = 255;
                int g = 255;
                int b = 0;
                Color color = new Color(r, g, b);

                Artifact artifact = new Artifact();
                artifact.SetText(text);
                artifact.SetFontSize(FONT_SIZE);
                artifact.SetColor(color);
                artifact.SetPosition(position);
                artifact.SetScore(score);
                artifact.SetVelocity(direction);
                cast.AddActor("artifacts", artifact);
            }

            // create the gems
            for (int i = 0; i < DEFAULT_ARTIFACTS / 2; i++)
            {
                string text = "*";
                int score = 1;

                int x = random.Next(1, COLS);
                int y = random.Next(1, ROWS - 5);
                int dy = POSSIBLES_SPEEDS[random.Next(0, POSSIBLES_SPEEDS.Length - 1)];
                Point position = new Point(x, y);
                position = position.Scale(CELL_SIZE);
                Point direction = new Point(0, dy);

                int r = 160;
                int g = 32;
                int b = 240;
                Color color = new Color(r, g, b);

                Artifact artifact = new Artifact();
                artifact.SetText(text);
                artifact.SetFontSize(FONT_SIZE);
                artifact.SetColor(color);
                artifact.SetPosition(position);
                artifact.SetScore(score);
                artifact.SetVelocity(direction);
                cast.AddActor("artifacts", artifact);
            }

            // start the game
            KeyboardService keyboardService = new KeyboardService(CELL_SIZE);
            VideoService videoService 
                = new VideoService(CAPTION, MAX_X, MAX_Y, CELL_SIZE, FRAME_RATE, false);
            Director director = new Director(keyboardService, videoService);
            director.StartGame(cast);

            // test comment
        }
    }
}