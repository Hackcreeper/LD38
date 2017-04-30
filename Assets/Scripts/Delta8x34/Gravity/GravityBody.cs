using UnityEngine;

namespace LD38.Gravity
{
    /// <summary>
    /// Every object that should be able to "move" around the planet does need this component.
    /// It handles gravity and rotation.
    /// </summary>
    public class GravityBody : MonoBehaviour
    {
        #region PROTECTED_VARS

        /// <summary>
        /// The planet (This variable will be fetched automatically in the "Awake" method)
        /// </summary>
        protected GravityAttractor Planet;

        /// <summary>
        /// The own rigidbody (This variable will be fetched automatically in the "Awake" method)
        /// </summary>
        protected Rigidbody Rigidbody;

        #endregion

        #region PROTECTED_METHODS

        /// <summary>
        /// Fetch the planet and the own rigidbody. Also modifiy some values of the rigidbody.
        /// </summary>
        protected virtual void Awake()
        {
            Planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<GravityAttractor>();
            Rigidbody = GetComponent<Rigidbody>();

            Rigidbody.useGravity = false;
            Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }

        /// <summary>
        /// Every fixed tick the planet should attract the own object
        /// </summary>
        protected virtual void FixedUpdate()
        {
            Planet.Attract(Rigidbody);
        }

        #endregion
    }
}