using UnityEngine;

namespace LD38.Gravity
{
    /// <summary>
    /// This compontent should be attached to the planet object.
    /// </summary>
    public class GravityAttractor : MonoBehaviour
    {

        #region PROTECTED_VARS

        /// <summary>
        /// The gravity factor
        /// </summary>
        [SerializeField] protected float Gravity = -9.8f;

        #endregion

        #region PUBLIC_METHODS

        /// <summary>
        /// Attract a specific rigidbody to this planet.
        /// </summary>
        /// <param name="body">The target</param>
        public void Attract(Rigidbody body)
        {
            var gravityUp = (body.position - transform.position).normalized;
            var localUp = body.transform.up;

            body.AddForce(gravityUp * Gravity);
            body.rotation = Quaternion.FromToRotation(localUp, gravityUp) * body.rotation;
        }

        #endregion

    }

}