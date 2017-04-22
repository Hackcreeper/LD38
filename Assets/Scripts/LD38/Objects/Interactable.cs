using UnityEngine;

namespace LD38.Objects
{
    public abstract class Interactable : MonoBehaviour
    {
        #region PROTECTED_VARS

        protected const float MaxDistance = 5f;

        [SerializeField] protected string Name;

        [SerializeField] protected bool IsInteractive = true;

        protected bool IsHovering;

        #endregion

        #region PUBLIC_METHODS

        public virtual void Enable()
        {
            IsInteractive = true;
        }

        public virtual void Disable()
        {
            IsInteractive = false;
        }

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
            if (IsHovering && IsInteractive)
            {
                Main.Get.SetObjectText(string.Empty);

                var distance = Vector3.Distance(Main.Get.Player.position, transform.position);
                if (!(distance <= MaxDistance)) return;

                Main.Get.SetObjectText("Press (E) to interact with: " + Name);

                if (Input.GetButtonDown("Interact"))
                {
                    OnInteract();
                    Main.Get.SetObjectText(string.Empty);
                }
            }
        }

        protected abstract void OnInteract();

        #endregion
    }
}