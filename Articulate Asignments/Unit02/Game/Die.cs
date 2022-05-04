using System;


namespace Unit02.Game
{
    /// <summary>
    /// A small cube with a different number of spots on each of its six sides.
    /// 
    /// The responsibility of Die is to keep track of its currently rolled value and the points its
    /// worth.
    /// </summary>
    class Die {

        /// <summary>
        /// Constructs a new instance of Die.
        /// </summary>
        public Die() {
            int points = 0;
            int value = 0;
            int faces = 6;
            Random rnd = new Random();
        }



        /// <summary>
        /// Generates a new random value and calculates the points for the die. Fives are 
        /// worth 50 points, ones are worth 100 points, everything else is worth 0 points.
        /// </summary>
        public void Roll() {
            value = rnd.Next(1, (faces + 1));
        }
        
    }
        
}