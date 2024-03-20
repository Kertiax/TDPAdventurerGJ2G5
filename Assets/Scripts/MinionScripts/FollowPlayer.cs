using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private float minDistance;

    private void Update()
    {
        if (target == null)
        {
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < minDistance && !target.gameObject.CompareTag("Player"))
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
}
