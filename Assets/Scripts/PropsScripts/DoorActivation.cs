using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActivation : MonoBehaviour, IActivableObject
{
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private bool isClosed = true;
    [SerializeField] private Collider2D doorCollider;
    [SerializeField] private List<GameObject> sidePillarGlow;

    public void ActivateObject()
    {
        isClosed = false;

        doorAnimator.SetBool("isClosed", isClosed);

        doorCollider.enabled = false;

        ChangeSidePillarGlow(true);
    }

    public void DeactivateObject()
    {
        isClosed = true;

        doorAnimator.SetBool("isClosed", isClosed);

        doorCollider.enabled = true;

        ChangeSidePillarGlow(false);
    }

    private void ChangeSidePillarGlow(bool state)
    {
        if (sidePillarGlow.Count != 0)
        {
            foreach (GameObject item in sidePillarGlow)
            {
                item.SetActive(state);
            }
        }
    }
}
