using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    private float speed;
    public float walkSpeed;
    public float sprintSpeed;
    public float crouchSpeed;
    public float groundDrag;
    public float jumpForce;
    public float airMultiplier;

    public PhotonView photonView;
    public Animator anim;
    public BoxCollider boxCollider;

    [HideInInspector]
    public float sensitivity;
    [HideInInspector]
    public bool stopLook;

    public Transform orientation;
    public PlayerCamera cam;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [HideInInspector]
    public bool stopMove = false;

    float hInput;
    float vInput;
    bool isGrounded;
    bool jumping;

    Vector3 moveDir;

    public Rigidbody rb;

    public MovementState state;
    public enum MovementState
    {
        walking,
        sprinting,
        crouching,
        air,
        idle
    }

    void Start()
    {
        rb.freezeRotation = true;
    }

    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        MyInput();
        SpeedControl();
        StateHandler();
        AnimationHandler();

        if (stopMove)
        {
            speed = 0;
        }

        if (isGrounded)
            rb.linearDamping = groundDrag;
        else
            rb.linearDamping = 0;

        cam.stopLook = stopLook;
        cam.initSenX = sensitivity;
        cam.initSenY = sensitivity;
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MyInput()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !stopMove)
        {
            StartCoroutine(Jump());
        }
    }

    void StateHandler()
    {
        if (Input.GetKey(KeyCode.LeftShift) )
        {
            state = MovementState.sprinting;
            speed = sprintSpeed;
            boxCollider.size = new Vector3(0.02034934f, 0.05043693f, 0.02f);
            cam.isSprinting = true;

        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            state = MovementState.crouching;
            boxCollider.size = new Vector3(0.02034934f, 0.04082843f, 0.02f);
            speed = crouchSpeed;
            cam.isSprinting = false;
        }
        else if (isGrounded)
        {
            state = MovementState.walking;
            speed = walkSpeed;
            boxCollider.size = new Vector3(0.02034934f, 0.05043693f, 0.02f);
            cam.isSprinting = false;
        }
        else
        {
            state = MovementState.air;
            boxCollider.size = new Vector3(0.02034934f, 0.05043693f, 0.02f);
            cam.isSprinting = false;
        }
    }

    void AnimationHandler()
    {
        if(Input.GetKey(KeyCode.W) && !jumping|| Input.GetKey(KeyCode.A) && !jumping|| Input.GetKey(KeyCode.S) && !jumping|| Input.GetKey(KeyCode.D) && !jumping)
        {
            if (Input.GetKey(KeyCode.LeftShift) && !stopMove)
            {
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsRunning", true);
                anim.SetBool("IsCrouching", false);
                anim.SetBool("IsCrouch", false);
                cam.isCrouching = false;

            }
            else if (Input.GetKey(KeyCode.LeftControl) && !stopMove)
            {
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsRunning", false);
                anim.SetBool("IsCrouching", true);
                anim.SetBool("IsCrouch", false);
                cam.isCrouching = true;
            }
            else
            {
                anim.SetBool("IsWalking", true);
                anim.SetBool("IsRunning", false);
                anim.SetBool("IsCrouching", false);
                anim.SetBool("IsCrouch", false);
                cam.isCrouching = false;
            }

            if(Input.GetKeyDown(KeyCode.Space) && !stopMove)
            {
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsRunning", false);
                anim.SetBool("IsCrouching", false);
                anim.SetBool("IsCrouch", false);
                cam.isCrouching = false;
            }
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsCrouching", false);
            anim.SetBool("IsCrouch", true);
            cam.isCrouching = true;
        }
        else
        {
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsCrouching", false);
            anim.SetBool("IsCrouch", false);
            cam.isCrouching = false;
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded && !jumping)
        {
            StartCoroutine(JumpAnimation());
        }
    }

    void MovePlayer()
    {
        moveDir = orientation.forward * vInput + orientation.right * hInput;

        if (isGrounded)
            rb.AddForce(moveDir.normalized * speed * 10f, ForceMode.Force);
        else if (!isGrounded)
            rb.AddForce(moveDir.normalized * speed * 10f * airMultiplier, ForceMode.Force);
    }

    void SpeedControl()
    {
        Vector3 flatvel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        if (flatvel.magnitude > speed)
        {
            Vector3 limitedVel = flatvel.normalized * speed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(0.15f);
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.y);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    IEnumerator JumpAnimation()
    {
        anim.SetBool("IsJumping", true);
        anim.SetBool("IsWalking", false);
        anim.SetBool("IsRunning", false);
        anim.SetBool("IsCrouching", false);
        anim.SetBool("IsCrouch", false);
        cam.isCrouching = false;
        jumping = true;
        yield return new WaitForSeconds(1.2f);
        anim.SetBool("IsJumping", false);
        jumping = false;
    }
}
