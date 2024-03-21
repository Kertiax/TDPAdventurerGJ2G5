using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAltar : MonoBehaviour
{
    [SerializeField] private GameObject activableDoor;
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
            ObjectTypeEnum objectType = ObjectTypeEnum.Default;

            if (other.TryGetComponent(out MinionStepInfo minionStepInfo))
            {
                targetColor = minionStepInfo.minionColor;
                objectType = minionStepInfo.minionColorType;
                targetColor.a = 1;
            }
            else
            {
                targetColor = new Color(1, 1, 1, 1);
            }

            ActivateObjects(objectType);
            amountObjectInCollision++;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & activableObjectsLayerMask) != 0)
        {
            ObjectTypeEnum objectType = ObjectTypeEnum.Default;

            if (other.TryGetComponent(out MinionStepInfo minionStepInfo))
            {
                objectType = minionStepInfo.minionColorType;
            }

            DeactivateObjects(objectType);

            amountObjectInCollision--;
        }

        if (amountObjectInCollision <= 0)
        {
            targetColor = new Color(1, 1, 1, 0);
        }
    }

    private void ActivateObjects(ObjectTypeEnum objectTypeEnum)
    {
        if (activableDoor != null)
        {
            if (activableDoor.TryGetComponent(out IActivableObject activableObject))
            {
                activableObject.ActivateObject(objectTypeEnum);
            }
        }
    }

    private void DeactivateObjects(ObjectTypeEnum objectTypeEnum)
    {
        if (activableDoor != null)
        {
            if (activableDoor.TryGetComponent(out IActivableObject activableObject))
            {
                activableObject.DeactivateObject(objectTypeEnum);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        if (activableDoor != null)
        {
            Gizmos.DrawLine(transform.position, activableDoor.transform.position);
        }
    }

}
