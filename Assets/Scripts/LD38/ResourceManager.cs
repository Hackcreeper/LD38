namespace LD38
{
    public class ResourceManager
    {
        #region PROTECTED_VARS

        protected int AmountMetal;

        #endregion

        #region PUBLIC_METHODS

        public ResourceManager IncreaseMetal(int amount)
        {
            AmountMetal += amount;

            return this;
        }

        public int Metal
        {
            get { return AmountMetal; }
        }

        #endregion
    }
}