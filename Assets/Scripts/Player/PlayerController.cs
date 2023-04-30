using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Move Settings")]
    [SerializeField] private float _speed;
    [SerializeField] private ParticleSystem _dust;

    [Header("Jump Settings")]
    [SerializeField] private float _jumpingPower;
    [SerializeField] private float _coyoteTime = 0.2f;
    [SerializeField] private float _jumpBufferTime = 0.2f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    [Header("Dash Settings")]
    [SerializeField] private float _dashingPower;
    [SerializeField] private float _dashingTime = 0.2f;

    private float _jumpBufferTimeCounter;

    private float _coyoteTimeCounter;

    private bool _canDash = true;
    private bool _isDashing;
    private const float _dashingCoolDown = 1f;

    private bool isFacingRight = true;
    private float horizontal;

    private Animator _am;
    private Rigidbody2D _rb;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _am = GetComponent<Animator>();
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (IsGrounded())
        {
            _coyoteTimeCounter = _coyoteTime;
        }
        else
        {
            _coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            _jumpBufferTimeCounter = _jumpBufferTime;
        }
        else
        {
            _jumpBufferTimeCounter -= Time.deltaTime;
        }

        if (_jumpBufferTimeCounter > 0f && _coyoteTimeCounter > 0f)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpingPower);
            CreateDust();
            _jumpBufferTimeCounter = 0f;
        }

        if (_rb.velocity.y < 0f)
        {
            _rb.velocity += 1.5f * Physics2D.gravity.y * Time.deltaTime * Vector2.up;
        }
        else if (_rb.velocity.y > 0f && !Input.GetButton("Jump"))
        {
            _rb.velocity += 1f * Physics2D.gravity.y * Time.deltaTime * Vector2.up;
        }

        if (_rb.velocity.y > 0f)
        {
            _am.SetBool("IsFalling", false);
            _am.SetBool("IsJumping", true);
        }
        else if (_rb.velocity.y < -2f)
        {
            _am.SetBool("IsFalling", true);
            _am.SetBool("IsJumping", false);
        }
        else
        {
            _am.SetBool("IsFalling", false);
            _am.SetBool("IsJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) & _canDash)
        {
            CreateDust();
            StartCoroutine(Dash());
        }

        Flip();
    }

    private void FixedUpdate()
    {
        if (_isDashing)
        {
            return;
        }
        _rb.velocity = new Vector2(horizontal * _speed, _rb.velocity.y);
        _am.SetFloat("Speed", Mathf.Abs(horizontal));
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.02f, _groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            CreateDust();
        }
    }

    private IEnumerator Dash()
    {
        _canDash = false;
        _isDashing = true;
        float originalGravity = _rb.gravityScale;
        _rb.gravityScale = 0f;
        _rb.velocity = new Vector2(transform.localScale.x * _dashingPower, 0f);
        yield return new WaitForSeconds(_dashingTime);
        _rb.gravityScale = originalGravity;
        _isDashing = false;
        yield return new WaitForSeconds(_dashingCoolDown);
        _canDash = true;
    }

    private void CreateDust()
    {
        _dust.Play();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_groundCheck.position, 0.02f);
    }
}