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
            if (State == AntennaState.Unknown)
            {
                State = AntennaState.Inspected;
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