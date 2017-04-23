using UnityEngine;

namespace LD38.Objects
{
    public class Furnace : Interactable
    {
        #region PROTECTED_VARS

        [SerializeField] protected Transform Iron;

        #endregion

        #region PROTECTED_METHODS

        protected override void OnInteract()
        {
            if (Main.Get.Resources.Metal > 0)
            {
                Iron.gameObject.SetActive(true);
            }
        }

        #endregion
    }
}