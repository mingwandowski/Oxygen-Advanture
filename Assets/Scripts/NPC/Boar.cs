using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class Boar : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public float patrolSpeed = 70f;
    public float chaseSpeed = 140f;
    public Transform player;
    public LayerMask playerLayer;
    public float playerDetectDistance = 10f;
    public LayerMask wallLayer;
    public float wallDetectDistance = 1f;
    public Transform cliffCheck;
    public float cliffDetectDistance = 1f;

    private enum State { Idle, Patrol, Chase }
    private State state = State.Patrol;
    private float idleTime = 2f;
    private float patrolTime = 3f;
    private float lostTargetTime = 5f;
    private float stateTimer;
    public int faceDir = -1;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate() {
        switch (state) {
            case State.Idle:
                IdleUpdate();
                break;
            case State.Patrol:
                PatrolUpdate();
                break;
            case State.Chase:
                ChaseUpdate();
                break;
        }
    }

    private void ChangeToState(State state) {
        this.state = state;
        anim.SetBool("idle", false);
        anim.SetBool("walk", false);
        anim.SetBool("run", false);

        switch (state) {
            case State.Idle:
                anim.SetBool("idle", true);
                stateTimer = idleTime;
                rb.velocity = Vector2.zero;
                break;
            case State.Patrol:
                anim.SetBool("walk", true);
                stateTimer = patrolTime;
                break;
            case State.Chase:
                anim.SetBool("run", true);
                stateTimer = lostTargetTime;
                break;
        }
    }

    private void IdleUpdate() {
        if (stateTimer <= 0) {
            ChangeToState(State.Patrol);
            Flip();
        } else {
            stateTimer -= Time.deltaTime;
        }

        if (PlayerInSight()) {
            ChangeToState(State.Chase);
        }
    }

    private void PatrolUpdate() {
        if (stateTimer <= 0 || IsWallDetected() || IsCliffDetected()) {
            ChangeToState(State.Idle);
        } else {
            rb.velocity = faceDir * patrolSpeed * Vector2.right;
            stateTimer -= Time.deltaTime;
        }

        if (PlayerInSight()) {
            ChangeToState(State.Chase);
        }
    }

    private void ChaseUpdate() {
        if (stateTimer <= 0 || IsWallDetected() || IsCliffDetected()) {
            ChangeToState(State.Idle);
            return;
        }

        rb.velocity = chaseSpeed * faceDir * Vector2.right;

        if (!PlayerInSight()) {
            stateTimer -= Time.deltaTime;
        } else {
            stateTimer = lostTargetTime;
        }
    }

    private bool PlayerInSight() => Physics2D.Raycast(transform.position, Vector2.right * faceDir, playerDetectDistance, playerLayer);
    private bool IsWallDetected() => Physics2D.Raycast(transform.position, Vector2.right * faceDir, wallDetectDistance, wallLayer);
    private bool IsCliffDetected() => !Physics2D.Raycast(cliffCheck.position, Vector2.down, cliffDetectDistance, wallLayer);

    private void Flip() {
        faceDir *= -1;
        transform.Rotate(0, 180, 0);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawRay(transform.position, faceDir * playerDetectDistance * Vector2.right);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + new Vector3(0, -0.1f), faceDir * wallDetectDistance * Vector2.right);
        Gizmos.DrawRay(cliffCheck.position, cliffDetectDistance * Vector2.down);
    }
}
