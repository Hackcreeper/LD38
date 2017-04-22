using LD38.Gravity;
using UnityEditor;
using UnityEngine;

namespace LD38.Editor
{
    public class RotateToPlanet
    {
        [MenuItem("Assets/Rotate to planet %y")]
        public static void Rotate()
        {
            var active = Selection.activeGameObject.transform;

            var planet = GameObject.FindGameObjectWithTag("Planet").transform;

            var gravityUp = (active.position - planet.position).normalized;
            var localUp = active.transform.forward * -1f;

            active.rotation = Quaternion.FromToRotation(localUp, gravityUp) * active.rotation;
        }

        [MenuItem("Assets/Rotate to planet (other) %x")]
        public static void RotateOther()
        {
            var active = Selection.activeGameObject.transform;

            var planet = GameObject.FindGameObjectWithTag("Planet").transform;

            var gravityUp = (active.position - planet.position).normalized;
            var localUp = active.transform.forward;

            active.rotation = Quaternion.FromToRotation(localUp, gravityUp) * active.rotation;
        }
    }
}
