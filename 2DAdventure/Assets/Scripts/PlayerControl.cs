using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public enum FaceDirection
    {
        FaceLeft = -1,
        FaceRight = 1
    }

    public FaceDirection facing = FaceDirection.FaceRight;
    public LayerMask groundLayer;
    private Rigidbody2D _thisBody = null;
    private Transform _thisTransform = null;
    public CircleCollider2D feetCollider = null;
    public bool isGrounded = false;
    public string horzAxis = "Horizontal";
    public string jumpButton = "Jump";
    public float maxSpeed = 30f;
    public float jumpPower = 500f;
    public float jumpTimeOut = 0.25f;
    private bool _canJump = true;
    public bool canControl = true;
    public static PlayerControl instance = null;
    [SerializeField] private static float _health = 100f;

    public static float Health
    {
        get
        {
            return _health;
        }

        set
        {
            _health = value;
            if (_health <= 0)
            {
                Die();
            }
        }
    }

    private void Awake()
    {
        _thisBody = GetComponent<Rigidbody2D>();
        _thisTransform = GetComponent<Transform>();

        instance = this;
    }

    private bool IsGrounded()
    {
        var circleCenter = new Vector2(_thisTransform.position.x, _thisTransform.position.y) + feetCollider.offset;
        var hitColliders = Physics2D.OverlapCircleAll(circleCenter, feetCollider.radius, groundLayer);
        return hitColliders.Length > 0;
    }

    private void FlipDirection()
    {
        facing = (FaceDirection) ((int) facing * -1f);
        var localScale = _thisTransform.localScale;
        localScale.x *= -1f;
        _thisTransform.localScale = localScale;
    }

    private void Jump()
    {
        if (!isGrounded || !_canJump)
        {
            return;
        }
        
        _thisBody.AddForce(Vector2.up * jumpPower);
        _canJump = false;
        Invoke("ActivateJump", jumpTimeOut);
    }

    private void ActivateJump()
    {
        _canJump = true;
    }

    private void Update()
    {
        if (Input.GetButton(jumpButton))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        if (!canControl || Health <= 0f)
        {
            return;
        }

        isGrounded = IsGrounded();
        var horz = Input.GetAxis(horzAxis);
        _thisBody.AddForce(Vector2.right * horz * maxSpeed);

        _thisBody.velocity = new Vector2(
            Mathf.Clamp(_thisBody.velocity.x, -maxSpeed, maxSpeed),
            Mathf.Clamp(_thisBody.velocity.y, -Mathf.Infinity, jumpPower));
        
        // Flip direction if required.
        if ((horz < 0f && facing != FaceDirection.FaceLeft) || (horz > 0f && facing != FaceDirection.FaceRight))
        {
            FlipDirection();
        }
    }

    private void OnDestroy()
    {
        instance = null;
    }

    private static void Die()
    {
        Destroy(instance.gameObject);
    }

    public static void ResetPlayer()
    {
        Health = 100f;
    }
}
