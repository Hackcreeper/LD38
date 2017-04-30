using UnityEngine;

namespace LD38.Objects
{
    public class Furnace : Interactable
    {
        #region PROTECTED_VARS

        [SerializeField] protected Transform Iron;

        [SerializeField] protected Transform[] Fires;

        protected bool IsOn;

        #endregion

        #region PUBLIC_METHODS

        public bool On
        {
            get { return IsOn; }
        }

        #endregion

        #region PROTECTED_METHODS

        protected override void OnInteract()
        {
            if (Main.Get.Resources.Metal > 0)
            {
                Iron.gameObject.SetActive(true);
            }

            foreach (var fire in Fires)
            {
                fire.gameObject.SetActive(true);
            }

            IsOn = true;
        }

        #endregion
    }
}