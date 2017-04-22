using UnityEngine;

namespace LD38.Gravity
{
    [RequireComponent(typeof(GravityBody))]
    public class PlayerController : MonoBehaviour
    {
        #region PROTECTED_VARS

        [SerializeField] protected float MouseSensitivityX = 1;
        [SerializeField] protected float MouseSensitivityY = 1;
        [SerializeField] protected float WalkSpeed = 6;
        [SerializeField] protected float JumpForce = 220;

        [SerializeField] protected LayerMask GroundedMask;

        protected bool Grounded;
        protected Vector3 MoveAmount;
        protected Vector3 SmoothMoveVelocity;
        protected float VerticalLookRotation;
        protected Transform Camera;
        protected Rigidbody Rigidbody;

        #endregion

        #region PROTECTED_METHODS

        protected virtual void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Camera = UnityEngine.Camera.main.transform;
            Rigidbody = GetComponent<Rigidbody>();
        }

        protected virtual void Update()
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * MouseSensitivityX);
            VerticalLookRotation += Input.GetAxis("Mouse Y") * MouseSensitivityY;
            VerticalLookRotation = Mathf.Clamp(VerticalLookRotation, -60, 60);
            Camera.localEulerAngles = Vector3.left * VerticalLookRotation;

            var inputX = Input.GetAxisRaw("Horizontal");
            var inputY = Input.GetAxisRaw("Vertical");

            var moveDir = new Vector3(inputX, 0, inputY).normalized;
            var targetMoveAmount = moveDir * WalkSpeed;
            MoveAmount = Vector3.SmoothDamp(MoveAmount, targetMoveAmount, ref SmoothMoveVelocity, .15f);

            if (Input.GetButtonDown("Jump"))
            {
                if (Grounded)
                {
                    Rigidbody.AddForce(transform.up * JumpForce);
                }
            }

            var ray = new Ray(transform.position, -transform.up);
            RaycastHit hit;

            Grounded = Physics.Raycast(ray, out hit, 1 + .1f, GroundedMask);
        }

        protected virtual void FixedUpdate()
        {
            var localMove = transform.TransformDirection(MoveAmount) * Time.fixedDeltaTime;
            Rigidbody.MovePosition(Rigidbody.position + localMove);
        }

        #endregion
    }
}