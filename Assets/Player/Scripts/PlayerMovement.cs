using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController2D _characterController;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _runSpeedDecrease;

    private Rigidbody2D _myRigidbody;
    private Animator _animator;
    private float horizontalMove;

    private bool _jump;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * _runSpeed;
        
        _animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        _animator.SetFloat("VerticalMove", _myRigidbody.velocity.y);
        
        if(Input.GetButtonDown("Jump"))
        {   
            _jump = true;
            _animator.SetBool("isJumping", true);
            
        }

        CheckIsFalling();
    }

    public void IsGrounded()
    {
        _animator.SetBool("isJumping", false);
    }

    
    private void FixedUpdate()
    {        
        _characterController.Move(horizontalMove * Time.fixedDeltaTime, false, _jump);

        _jump = false;
    }

    public void PutBoxEvent()
    {
        _runSpeed -= _runSpeedDecrease;
    }


    private void CheckIsFalling()
    {
        if(transform.position.y < -10f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}


/*
 * 
 * 
 * public class PlayerMovement : MonoBehaviour
    {
        [Header("Move")]
        [SerializeField] float _playerSpeed;

        [Header("Jump")]
        [SerializeField] float _jumpForce;
        [Range(0f, 5f)]
        [SerializeField] float _jumpSensibility;


        private Rigidbody2D _myRigidbody;

        private void Awake()
        {
            _myRigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            PlayerMove();
            PlayerJump();

            if (Input.GetKeyDown(KeyCode.A))
                Debug.Log(_myRigidbody.velocity);
        }

        private void PlayerMove()
        {
            float move = Input.GetAxis("Horizontal");

            transform.position += new Vector3(move, 0f, 0f) * _playerSpeed * Time.deltaTime;
        }

        private void PlayerJump()
        {
            if (Input.GetButtonDown("Jump") && Mathf.Abs(_myRigidbody.velocity.y) < _jumpSensibility)
            {
                _myRigidbody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
            } 
        }
    }
*/

/*
 * 
 * public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] float _thrust;

        private Rigidbody2D _myRigidbody;

        private void Awake()
        {
            _myRigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Move();
            }
        }
        private void Move()
        {
            _myRigidbody.velocity = Vector2.zero;

            _myRigidbody.AddForce(MoveDirection() * _thrust, ForceMode2D.Impulse);
        }

        private Vector3 MoveDirection()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            return transform.position - mousePosition;
        }
    }

 */