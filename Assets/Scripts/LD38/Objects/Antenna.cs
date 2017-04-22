using System;

namespace LD38.Objects
{
    public class Antenna : Interactable
    {
        #region PROTECTED_VARS

        protected AntennaState State;

        #endregion

        #region PUBLIC_METHODS

        public virtual AntennaState GetState()
        {
            return State;
        }

        #endregion

        #region PROTECTED_METHODS

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

    public enum AntennaState
    {
        Unknown,

        Inspected,

        Repaired
    }
}