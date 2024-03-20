using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAltar : MonoBehaviour
{
    [SerializeField] private List<GameObject> activableObjects;
    [SerializeField] private List<SpriteRenderer> runes;
    [SerializeField] private float lerpSpeed;
    [SerializeField] private LayerMask activableObjectsLayerMask;
    [SerializeField] private int amountObjectInCollision = 0;

    private Color curColor;
    private Color targetColor;

    private void Update()
    {
        curColor = Color.Lerp(curColor, targetColor, lerpSpeed * Time.deltaTime);

        foreach (SpriteRenderer rune in runes)
        {
            rune.color = curColor;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & activableObjectsLayerMask) != 0)
        {
            ActivateObjects();
            targetColor = new Color(1, 1, 1, 1);
            amountObjectInCollision++;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & activableObjectsLayerMask) != 0)
        {
            amountObjectInCollision--;
        }

        if (amountObjectInCollision <= 0)
        {
            DeactivateObjects();
            targetColor = new Color(1, 1, 1, 0);
        }
    }

    private void ActivateObjects()
    {
        if (activableObjects.Count != 0)
        {
            foreach (GameObject item in activableObjects)
            {
                if (item.TryGetComponent(out IActivableObject activableObject))
                {
                    activableObject.ActivateObject();
                }
            }
        }
    }

    private void DeactivateObjects()
    {
        if (activableObjects.Count != 0)
        {
            foreach (GameObject item in activableObjects)
            {
                if (item.TryGetComponent(out IActivableObject activableObject))
                {
                    activableObject.DeactivateObject();
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        if (activableObjects.Count != 0)
        {
            foreach (GameObject item in activableObjects)
            {
                Gizmos.DrawLine(transform.position, item.transform.position);
            }
        }
    }

}
