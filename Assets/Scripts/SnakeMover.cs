using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum MoveSequence {
    Left,
    DownOnLeft,
    Right,
    DownOnRight
};

public class SnakeMover : MonoBehaviour {
    public float width = 1f;
    public float verticalStep = -1f;
    public float moveSpeed = 1f;

    private MoveSequence moveSequence;
    private Vector3 originalPosition = new Vector3(0f, 0f, 0f);
    private Vector3 targetPosition;

    void Start() {
        originalPosition = gameObject.transform.position;
        moveSequence = MoveSequence.Left;
        targetPosition = originalPosition += new Vector3(0f - width / 2f, 0f, 0f);
    }

    void Update() {
        MoveTowardsTarget();
        if (TargetReached())
            targetPosition = NewTarget();
    }

    void MoveTowardsTarget() {
        Vector3 newPostion = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        transform.position = newPostion;
    }

    bool TargetReached() {
        float sqrRemainingDistance = (transform.position - targetPosition).sqrMagnitude;
        return sqrRemainingDistance <= float.Epsilon;
    }

    Vector3 NewTarget() {
        switch(moveSequence) {
            case MoveSequence.Left:
                moveSequence = MoveSequence.DownOnLeft;
                return transform.position + new Vector3(0f, verticalStep, 0f);
            case MoveSequence.DownOnLeft:
                moveSequence = MoveSequence.Right;
                return transform.position + new Vector3(width, 0f, 0f);
            case MoveSequence.Right:
                moveSequence = MoveSequence.DownOnRight;
                return transform.position + new Vector3(0f, verticalStep, 0f);
            default: // MoveSequence.DownOnRight
                moveSequence = MoveSequence.Left;
                return transform.position + new Vector3(-width, 0f, 0f);
        }
    }
}
