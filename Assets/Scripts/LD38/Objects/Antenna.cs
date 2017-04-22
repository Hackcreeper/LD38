using System;

namespace LD38.Objects
{
    /// <summary>
    /// The antenna is the primary object of this game. The goal is to repair it.
    /// Currently it has three states:
    ///  - Unknown (If the player has never inspected it)
    ///  - Inspected (The antenna is broken and the player needs to repair it)
    ///  - Repaired (The mission is done)
    /// </summary>
    public class Antenna : Interactable
    {
        #region PROTECTED_VARS

        /// <summary>
        /// The state of the antenna
        /// </summary>
        protected AntennaState State;

        #endregion

        #region PUBLIC_METHODS

        /// <summary>
        /// Return the current state
        /// </summary>
        /// <returns>State</returns>
        public virtual AntennaState GetState()
        {
            return State;
        }

        #endregion

        #region PROTECTED_METHODS

        /// <summary>
        /// If the player interacts with the antenna the state should be set to "Inspected" or
        /// "Repaired".
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        protected override void OnInteract()
        {
            switch (State)
            {
                case AntennaState.Unknown:
                    State = AntennaState.Inspected;
                    break;
                case AntennaState.Inspected:
                    State = AntennaState.Repaired;
                    break;
                case AntennaState.Repaired:
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion
    }

    /// <summary>
    /// All possible states that this antenna could have
    /// </summary>
    public enum AntennaState
    {
        /// <summary>
        /// The antenna was never inspected before
        /// </summary>
        Unknown,

        /// <summary>
        /// The antenna is broken and needs to be repaired
        /// </summary>
        Inspected,

        /// <summary>
        /// The antenna is repaired and the mission is complete
        /// </summary>
        Repaired
    }
}