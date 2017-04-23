using UnityEngine;

namespace LD38.Objects
{
    /// <summary>
    /// Every object which should be interactable (with the (E) key) should
    /// extend from this class.
    /// </summary>
    public abstract class Interactable : MonoBehaviour
    {
        #region PROTECTED_VARS

        /// <summary>
        /// The maximum distance the player can have to interact with the object
        /// </summary>
        [SerializeField] protected float MaxDistance = 5f;

        /// <summary>
        /// The name of the object (will be shown in the UI)
        /// </summary>
        [SerializeField] protected string Name;

        /// <summary>
        /// Is this object currently interactable?
        /// </summary>
        [SerializeField] protected bool IsInteractive = true;

        /// <summary>
        /// Does this object needs to be mined?
        /// </summary>
        [SerializeField] protected bool NeedToMine;

        /// <summary>
        /// Does the player currently hover over it?
        /// </summary>
        protected bool IsHovering;

        #endregion

        #region PUBLIC_METHODS

        /// <summary>
        /// Set the "IsInteractive" state to true
        /// </summary>
        public virtual void Enable()
        {
            IsInteractive = true;
        }

        /// <summary>
        /// Set the "IsInteractive" state to false
        /// </summary>
        public virtual void Disable()
        {
            IsInteractive = false;
        }

        #endregion

        #region PROTECTED_METHODS

        /// <summary>
        /// If the player hovers over the object the "hovering" state should be set to
        /// true.
        /// </summary>
        protected virtual void OnMouseEnter()
        {
            IsHovering = true;
        }

        /// <summary>
        /// If the player leaves object, the "hovering" state should be set to
        /// false.
        /// </summary>
        protected virtual void OnMouseExit()
        {
            IsHovering = false;
        }

        /// <summary>
        /// If the player:
        /// - Is pointing to the object
        /// - Is near enough
        /// - And presses the "Interact" button
        /// Then the method "OnInteract" is called
        /// </summary>
        protected virtual void Update()
        {
            if (IsHovering && IsInteractive)
            {
                Main.Get.SetObjectText(string.Empty);

                if (Main.Get.Player == null)
                {
                    return;
                }

                var distance = Vector3.Distance(Main.Get.Player.position, transform.position);
                if (!(distance <= MaxDistance)) return;

                if (!NeedToMine)
                {
                    Main.Get.SetObjectText("Press (E) to interact with: " + Name);

                    if (Input.GetButtonDown("Interact"))
                    {
                        OnInteract();
                        Main.Get.SetObjectText(string.Empty);
                    }
                }
                else
                {
                    Main.Get.SetObjectText("Activate pickaxe (Q) and press (Left Mouse) to mine: " + Name);

                    var tool = FindObjectOfType<Laser>();
                    if (tool.IsMining() && tool.GetMineTime() >= 1.5f)
                    {
                        OnInteract();
                        Main.Get.SetObjectText("");
                    }
                }
            }
        }

        protected abstract void OnInteract();

        #endregion
    }
}