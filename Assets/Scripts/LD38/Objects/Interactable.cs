using UnityEngine;

namespace LD38.Objects
{
    public abstract class Interactable : MonoBehaviour
    {
        #region PROTECTED_VARS

        [SerializeField] protected string Name;

        protected bool IsHovering = false;

        #endregion

        #region PROTECTED_METHODS

        protected virtual void OnMouseEnter()
        {
            IsHovering = true;
        }

        protected virtual void OnMouseExit()
        {
            IsHovering = false;
        }

        protected virtual void Update()
        {
            if (IsHovering && Input.GetButtonDown("Interact"))
            {

            }
        }

        #endregion
    }
}