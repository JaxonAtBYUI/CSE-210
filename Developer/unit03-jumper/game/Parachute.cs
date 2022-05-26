using System;

namespace unit03_jumper.game
{
    /// <summary>
    /// Keeps track of how long until the player falls to their untimely death.
    /// </summary>
    class Parachute
    {
        int durability;

        /// <summary>
        /// Define a standard faulty parachute that the player is jumping from a plane with.
        /// </summary>
        public Parachute() {
            durability = 5;
        }

        /// <summary>
        /// Checks how close we are to falling to our death.
        /// </summary>
        public int getDurability() {
            return durability;
        }

        /// <summary>
        /// Rip the parachute when the player makes a mistake and proves they aren't worthy of life.
        /// </summary>
        public void damageParachute() {
            durability -= 1;
        }
    }
}
