using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickMinion : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator;

    [Header("Pick Minion")]
    [SerializeField] private Transform minionNewLocation;
    [SerializeField] private bool hasAMinion = false;
    [SerializeField] private FollowPlayer minionPicked;
    [SerializeField] private Vector2 boxDimentions;
    [SerializeField] private LayerMask minionMask;
    [SerializeField] private Transform boxCenter;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!hasAMinion)
            {
                TryToPickMinion();
            }
            else if (hasAMinion)
            {
                ChangeMinionLocation();
            }
        }
    }

    private void ChangeMinionLocation()
    {
        if (minionPicked != null)
        {
            GameObject minionNewLocationInstance = Instantiate(minionNewLocation.gameObject, transform.position, transform.rotation);

            minionPicked.StartFollowTarget(minionNewLocationInstance.transform);

            minionPicked = null;

            hasAMinion = false;
        }
    }

    private void TryToPickMinion()
    {
        animator.SetTrigger("Catch");

        Collider2D[] objectsTouched = Physics2D.OverlapBoxAll(boxCenter.position, boxDimentions, 0f, minionMask);

        foreach (Collider2D objectTouched in objectsTouched)
        {
            if (objectTouched.TryGetComponent(out FollowPlayer followPlayer))
            {
                followPlayer.StartFollowTarget(transform);
                hasAMinion = true;
                minionPicked = followPlayer;
                break;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireCube(boxCenter.position, boxDimentions);
    }
}
