using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private Corgi corgi;
    private bool runToTarget = false;
    private int faceDir = -1;
    [SerializeField] private float runSpeed = 6f;
    [SerializeField] private Transform targetPosition;
    private bool jumpOnBranch = false;
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private Transform BranchPosition;

    private void Awake() {
        anim = GetComponent<Animator>();
    }

    private void Start() {
        anim.SetBool("idle", true);
    }

    private void Update() {
        if (!runToTarget && !jumpOnBranch) {
            FaceToCorgi();
        }
    }

    private void FixedUpdate() {
        if (runToTarget) {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, runSpeed);
            if (Vector2.Distance(transform.position, targetPosition.position) < 0.1f) {
                runToTarget = false;
                anim.SetBool("run", false);
                TriggerJumpOnBranch();
            }
        }

        if (jumpOnBranch) {
            transform.position = Vector3.MoveTowards(transform.position, BranchPosition.position, jumpSpeed);
            if (Vector2.Distance(transform.position, BranchPosition.position) < 0.1f) {
                jumpOnBranch = false;
                anim.SetBool("jump", false);
                anim.SetBool("idle", true);
                Rotate();
            }
        }
    }

    private void FaceToCorgi() {
        if (corgi.transform.position.x < transform.position.x && faceDir == 1 ||
            corgi.transform.position.x > transform.position.x && faceDir == -1) {
             Rotate();
        }
    }

    public void TriggerRunAway() {
        anim.SetBool("idle", false);
        anim.SetBool("run", true);
        runToTarget = true;
        Rotate();
    }

    private void TriggerJumpOnBranch() {
        anim.SetBool("jump", true);
        jumpOnBranch = true;
    }

    private void Rotate() {
        faceDir *= -1;
        transform.Rotate(0, 180, 0);
    }
}
