using LD38.Objects;
using UnityEngine;

namespace LD38.Spaceship
{
    public class Ship : Interactable
    {
        #region PROTECTED_VARS

        [SerializeField] protected ParticleSystem[] Thrusters;

        #endregion

        #region PUBLIC_METHODS

        public virtual void EnableThrusters()
        {
            foreach (var thruster in Thrusters)
            {
                thruster.gameObject.SetActive(true);
                thruster.enableEmission = true;
            }
        }

        public virtual void DisableThrusters()
        {
            foreach (var thruster in Thrusters)
            {
                thruster.enableEmission = false;
            }
        }

        public virtual void KillThrusters()
        {
            foreach (var thruster in Thrusters)
            {
                thruster.gameObject.SetActive(false);
            }
        }

        public virtual void FinishGame()
        {
            Main.Get.Win();
        }

        #endregion

        #region PROTECTED_METHODS

        protected override void OnInteract()
        {
            Camera.main.transform.SetParent(transform);
            Main.Get.Player.gameObject.SetActive(false);

            GetComponent<Animator>().enabled = true;
            GetComponent<Animator>().SetBool("Away", true);
        }

        #endregion
    }
}
