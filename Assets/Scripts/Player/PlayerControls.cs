using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour, IGravity
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpPower;
    private bool _isFalling = false;
    private Vector3 _impact { get; set; }
    public float Mass { get; set; } = 20f;

    private float _gravityForce;
    private Vector3 _moveVector;



    private CharacterController _characterController;
    private Animator _animator;
    private MobileController _mobileController;
    private bool _jumpButton;
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _mobileController = UIController.MobileController;
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            PhysicsExtensions.AddImpulse(this, 30f, transform.forward);
        }
        Impacts();
        Moving();
        Gravity();

    }


    private void Moving()
    {
        _animator.SetBool("IsFalling", _isFalling);

        if (_characterController.isGrounded)
        {
            _animator.ResetTrigger("Jump");
            if (_isFalling)
            {
                _isFalling = false;
                _animator.SetTrigger("Ground");
            }
            _moveVector = Vector3.zero;
            _moveVector.x = _mobileController.Horizontal();
            _moveVector.z = _mobileController.Vertical();
            _moveVector = (_moveVector.magnitude > 1.0f) ? _moveVector.normalized : _moveVector;
            _moveVector *= _moveSpeed;



            if (Vector3.Angle(Vector3.forward, _moveVector) > 1f || (Vector3.Angle(Vector3.forward, _moveVector) == 0))
            {
                Vector3 direction = Vector3.RotateTowards(transform.forward, _moveVector, _moveSpeed, 0f);
                transform.rotation = Quaternion.LookRotation(direction);
            }
        }
        else
        {
            if (_gravityForce < -3f )
            {
                _isFalling = true;
            }

        }

        if (_moveVector.x != 0 || _moveVector.z != 0)
        {
            _animator.SetFloat("Vertical", Mathf.Abs(_moveVector.x) / _moveSpeed + Mathf.Abs(_moveVector.z) / _moveSpeed);


        }
        
        if (_moveVector.x == 0 && _moveVector.y == 0)
        {
            if (_animator.GetFloat("Vertical") > 0)
            {
                _animator.SetFloat("Vertical", _animator.GetFloat("Vertical") - 5f * Time.deltaTime);
            }
            else
            {
                _animator.SetFloat("Vertical", 0);
            }

        }



        _moveVector.y = _gravityForce;
        


        _characterController.Move(_moveVector * Time.deltaTime);
    }

    public void Gravity()
    {
        if (!_characterController.isGrounded)
        {
            _gravityForce -= 20f * Time.deltaTime;
        }
        else
        {
            _gravityForce = -1f;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || _jumpButton) && _characterController.isGrounded)
        {
            _jumpButton = false;
            _gravityForce = _jumpPower; //убрать это, когда добавим вызов прыжка в анимацию
            _animator.SetTrigger("Jump");
        }
    }
    public void Impacts()
    {
        if (_impact.magnitude > 0.2) _characterController.Move(_impact * Time.deltaTime);
        _impact = Vector3.Lerp(_impact, Vector3.zero, Mass * Time.deltaTime);
    }

    //вызывать это в анимации
    private void Jumping()
    {
        _gravityForce = _jumpPower;
    }


    public void JumpButtonClick()
    {
        _jumpButton = true;
    }

    public void AddImapct(float impact, Vector3 direction)
    {
        direction.Normalize();
        if (direction.y < 0)
        {
            direction.y = -direction.y;
        }
        _impact += direction.normalized * impact / Mass;
    }
}
