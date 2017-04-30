using UnityEngine;

namespace LD38.Gravity
{
    /// <summary>
    /// This component controls the player. A player can move and jump.
    /// </summary>
    [RequireComponent(typeof(GravityBody))]
    public class PlayerController : MonoBehaviour
    {
        #region PROTECTED_VARS

        /// <summary>
        /// The sensitivity of the mouse (x-axis)
        /// </summary>
        [SerializeField] protected float MouseSensitivityX = 1;

        /// <summary>
        /// The sensitivity of the mouse (y-axis)
        /// </summary>
        [SerializeField] protected float MouseSensitivityY = 1;

        /// <summary>
        /// The walk speed of the player
        /// </summary>
        [SerializeField] protected float WalkSpeed = 6;

        /// <summary>
        /// The force, that is added to the player, while jumping
        /// </summary>
        [SerializeField] protected float JumpForce = 220;

        /// <summary>
        /// The mask of the ground (the planet)
        /// </summary>
        [SerializeField] protected LayerMask GroundedMask;

        /// <summary>
        /// Is the player currently on the ground?
        /// </summary>
        protected bool Grounded;

        /// <summary>
        /// The amount that the player want's to move
        /// </summary>
        protected Vector3 MoveAmount;

        /// <summary>
        /// The generated velocity of the smooth movement
        /// </summary>
        protected Vector3 SmoothMoveVelocity;

        /// <summary>
        /// The vertical rotation of the player
        /// </summary>
        protected float VerticalLookRotation;

        /// <summary>
        /// The main camera
        /// </summary>
        protected Transform Camera;

        /// <summary>
        /// A reference to the own rigidbody
        /// </summary>
        protected Rigidbody Rigidbody;

        #endregion

        #region PROTECTED_METHODS

        /// <summary>
        /// Fetch the main camera and the own rigidbody.
        /// </summary>
        protected virtual void Awake()
        {
            Camera = UnityEngine.Camera.main.transform;
            Rigidbody = GetComponent<Rigidbody>();
        }

        /// <summary>
        /// Update the player's position and rotation.
        /// </summary>
        protected virtual void Update()
        {
            if (!Main.Get.GetLockedState())
            {
                return;
            }

            RotateCamera();
            Move();
            Jump();
            CheckIfGrounded();
        }

        /// <summary>
        /// Set the grounded variable based on a raycast
        /// </summary>
        protected virtual void CheckIfGrounded()
        {
            var ray = new Ray(transform.position, -transform.up);
            RaycastHit hit;

            Grounded = Physics.Raycast(ray, out hit, 1 + .1f, GroundedMask);
        }

        /// <summary>
        /// If the player presses the jump button (default: space) the jump force will be
        /// added.
        /// </summary>
        protected virtual void Jump()
        {
            if (!Input.GetButtonDown("Jump")) return;
            if (!Grounded) return;

            Rigidbody.AddForce(transform.up * JumpForce);
        }

        /// <summary>
        /// Move the player, based on the input.
        /// </summary>
        protected virtual void Move()
        {
            var inputX = Input.GetAxisRaw("Horizontal");
            var inputY = Input.GetAxisRaw("Vertical");

            var moveDir = new Vector3(inputX, 0, inputY).normalized;
            var targetMoveAmount = moveDir * WalkSpeed;
            MoveAmount = Vector3.SmoothDamp(MoveAmount, targetMoveAmount, ref SmoothMoveVelocity, .15f);
        }

        /// <summary>
        /// Rotate the camera based on the mouse rotation
        /// </summary>
        protected virtual void RotateCamera()
        {
            if (Main.Get.Paused)
            {
                return;
            }

            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * MouseSensitivityX);
            VerticalLookRotation += Input.GetAxis("Mouse Y") * MouseSensitivityY;
            VerticalLookRotation = Mathf.Clamp(VerticalLookRotation, -60, 60);
            Camera.localEulerAngles = Vector3.left * VerticalLookRotation;
        }

        /// <summary>
        /// Every fixed tick the movement should be done within the rigidbody
        /// </summary>
        protected virtual void FixedUpdate()
        {
            var localMove = transform.TransformDirection(MoveAmount) * Time.fixedDeltaTime;
            Rigidbody.MovePosition(Rigidbody.position + localMove);
        }

        #endregion
    }
}