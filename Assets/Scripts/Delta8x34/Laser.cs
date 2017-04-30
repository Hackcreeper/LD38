using System;
using System.Linq.Expressions;
using UnityEngine;

namespace LD38
{
    public class Laser : MonoBehaviour
    {
        #region PROTECTED_VARS

        protected ToolState State;

        [SerializeField] protected Transform Off;

        [SerializeField] protected Transform[] On;

        [SerializeField] protected Transform Pickaxe;

        protected float MiningTime;

        #endregion

        #region PUBLIC_METHODS

        public void ResetTimer()
        {
            MiningTime = 0f;
        }

        public bool IsMining()
        {
            return State == ToolState.Pickaxe && Input.GetMouseButton(0);
        }

        public float GetMineTime()
        {
            return MiningTime;
        }

        #endregion

        #region PROTECTED_METHODS

        protected virtual void Update()
        {
            if (Input.GetButtonDown("Tool"))
            {
                State = State == ToolState.Off ? ToolState.Pickaxe : ToolState.Off;

                UpdateGfx();
            }

            var mining = State == ToolState.Pickaxe && Input.GetMouseButton(0);
            GetComponent<Animator>().SetBool("mining", mining);

            if (mining)
            {
                MiningTime += Time.deltaTime;
            }
            else
            {
                MiningTime = 0f;
            }
        }

        protected virtual void UpdateGfx()
        {
            switch (State)
            {
                case ToolState.Off:
                    Off.gameObject.SetActive(true);
                    foreach (var obj in On)
                    {
                        obj.gameObject.SetActive(false);
                    }
                    Pickaxe.gameObject.SetActive(false);
                    break;

                case ToolState.Pickaxe:
                    Off.gameObject.SetActive(false);
                    foreach (var obj in On)
                    {
                        obj.gameObject.SetActive(true);
                    }
                    Pickaxe.gameObject.SetActive(true);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion
    }

    public enum ToolState
    {
        Off,

        Pickaxe
    }
}
