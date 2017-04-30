using UnityEngine;

namespace LD38.Objects
{
    public class Door : Interactable
    {
        #region PROTECTED_VARS

        protected bool IsOpen = false;

        protected Vector3 TargetRotation = new Vector3(-90, 0, 0);

        #endregion

        #region PROTECTED_METHODS

        protected override void OnInteract()
        {
            IsOpen = !IsOpen;
            TargetRotation = IsOpen ? new Vector3(-90, 0, -135) : new Vector3(-90, 0, 0);
        }

        protected override void Update()
        {
            base.Update();

            transform.parent.localRotation = Quaternion.Slerp(
                transform.parent.localRotation, Quaternion.Euler(TargetRotation), 0.5f * Time.deltaTime
            );
        }

        #endregion
    }
}