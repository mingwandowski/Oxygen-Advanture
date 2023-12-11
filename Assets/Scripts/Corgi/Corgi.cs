using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corgi : MonoBehaviour
{
    public InputControl inputControl;
    [HideInInspector] public Animator anim;
    [HideInInspector] public Rigidbody2D rb;
    [SerializeField] private Transform groundDetect;
    [SerializeField] private float raycastDistance = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    #region Variables
    public Vector2 inputDirection;
    public float walkSpeed = 2;
    public float runSpeed = 5;
    public float jumpForce = 16;
    public int faceDir = 1;
    public bool isSniffing = false;
    #endregion

    #region States
    public CorgiStateMachine StateMachine;
    public CorgiIdleState idleState;
    public CorgiWalkState walkState;
    public CorgiRunState runState;
    public CorgiJumpState jumpState;
    public CorgiAirState airState;
    public CorgiSniffState sniffState;
    public CorgiSniffWalkState sniffWalkState;
    #endregion

    private void Awake() {
        inputControl = GameManager.instance.inputControl;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        StateMachine = new CorgiStateMachine();
        idleState = new CorgiIdleState(this, StateMachine, "idle");
        walkState = new CorgiWalkState(this, StateMachine, "walk");
        runState = new CorgiRunState(this, StateMachine, "run");
        jumpState = new CorgiJumpState(this, StateMachine, "jump");
        airState = new CorgiAirState(this, StateMachine, "jump");
        sniffState = new CorgiSniffState(this, StateMachine, "sniff");
        sniffWalkState = new CorgiSniffWalkState(this, StateMachine, "sniffWalk");
    }

    private void OnEnable() {
        inputControl.Enable();
    }

    private void OnDisable() {
        inputControl.Disable();
    }

    private void Start() {
        StateMachine.InitState(idleState);
    }

    private void Update() {
        StateMachine.CurrentState.Update();
        inputDirection = inputControl.Gameplay.Move.ReadValue<Vector2>();
        isSniffing = inputControl.Gameplay.Sniff.ReadValue<float>() > 0;
    }

    private void FixedUpdate() {
        StateMachine.CurrentState.FixedUpdate();
    }

    public bool IsMoving() => inputDirection.x != 0;
    public bool IsGrounded() => Physics2D.Raycast(groundDetect.position, Vector2.down, raycastDistance, groundLayer);

    public void SetVelocity(float xSpeed) {
        if (faceDir == 1 && xSpeed < 0 || faceDir == -1 && xSpeed > 0) {
            Flip();
            faceDir *= -1;
        }
        rb.velocity = new Vector2(xSpeed, rb.velocity.y);
    }

    private void Flip() {
        rb.transform.Rotate(0, 180, 0);
    }

    private void OnDrawGizmos() {
        Gizmos.DrawRay(groundDetect.position, Vector2.down * raycastDistance);
    }
}
