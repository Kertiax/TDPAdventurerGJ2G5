using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private float minDistance;
    [SerializeField] private Animator animator;
    private bool isMoving = false;
    private bool lookingRight = true;

    private void Update()
    {
        if (target == null)
        {
            isMoving = false;
            return;
        }

        TurnCheck(target.position.x);

        float distanceBtwTarget = Vector2.Distance(transform.position, target.position);

        if (distanceBtwTarget > minDistance)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        animator.SetBool("isMoving", isMoving);

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (distanceBtwTarget < minDistance && !target.gameObject.CompareTag("Player"))
        {
            Destroy(target.gameObject);
        }
    }


    public void StartFollowTarget(Transform newTarget)
    {
        if (target != null)
        {
            if (!target.gameObject.CompareTag("Player"))
            {
                Destroy(target.gameObject);
            }
        }

        target = newTarget;
    }

    private void TurnCheck(float targetXPosition)
    {
        if (targetXPosition > transform.position.x && !lookingRight)
        {
            Turn();
        }
        else if (targetXPosition < transform.position.x && lookingRight)
        {
            Turn();
        }
    }

    private void Turn()
    {
        lookingRight = !lookingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
