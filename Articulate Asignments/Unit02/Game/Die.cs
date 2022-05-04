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
        
        public int _points;
        public int _value;
        public int _faces;
        Random rnd = new Random();

        /// <summary>
        /// Constructs a new instance of Die.
        /// </summary>
        public Die() {
             _points = 0;
             _value = 2;
             _faces = 6;
        }
        public Die(int points, int value, int faces) {
            _points = points;
            _value = value;
            _faces = faces;
        }

        /// <summary>
        /// Generates a new random value and calculates the points for the die. Fives are 
        /// worth 50 points, ones are worth 100 points, everything else is worth 0 points.
        /// </summary>
        public void Roll() {
            _value = rnd.Next(1, (_faces + 1));
            if (_value == 1) {
                _points = 100;
            }
            else if (_value == 5) {
                _points = 50;
            }
            else {
                _points = 0;
            }
        }
        
    }
        
}