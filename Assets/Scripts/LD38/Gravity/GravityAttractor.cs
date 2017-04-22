using UnityEngine;

namespace LD38.Gravity
{
    public class GravityAttractor : MonoBehaviour
    {

        #region PROTECTED_VARS

        [SerializeField] protected float Gravity = -9.8f;

        #endregion

        #region PUBLIC_METHODS

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