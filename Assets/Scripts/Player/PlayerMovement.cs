using UnityEngine;

namespace BGS.ProgrammerTask.Player
{

    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float _moveSpeed = 5f;
        [SerializeField]
        private float _lerpSpeed = 10f;
        [SerializeField]
        private Transform _pivotToRotate;

        private Rigidbody2D rb;
        private Vector2 movement;
        private Animator animator;
        private float targetScaleX = 1;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");

            if (movement.magnitude > 0)
            {
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }

            if (movement.x < 0)
            {
                targetScaleX = -1;
            }
            else if (movement.x > 0)
            {
                targetScaleX = 1;
            }

            float newScaleX = Mathf.Lerp(_pivotToRotate.localScale.x, targetScaleX, Time.deltaTime * _lerpSpeed);
            _pivotToRotate.localScale = new Vector3(newScaleX, _pivotToRotate.localScale.y, _pivotToRotate.localScale.z);
        }

        void FixedUpdate()
        {
            // Mover el jugador
            rb.MovePosition(rb.position + movement * _moveSpeed * Time.fixedDeltaTime);
        }
    }

}
