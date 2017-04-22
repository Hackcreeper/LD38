using UnityEngine;

namespace LD38.Gravity
{
    public class GravityBody : MonoBehaviour
    {
        #region PROTECTED_VARS

        protected GravityAttractor Planet;

        protected Rigidbody Rigidbody;

        #endregion

        #region PROTECTED_METHODS

        protected virtual void Awake()
        {
            Planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<GravityAttractor>();
            Rigidbody = GetComponent<Rigidbody>();

            Rigidbody.useGravity = false;
            Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }

        protected virtual void FixedUpdate()
        {
            Planet.Attract(Rigidbody);
        }

        #endregion
    }
}