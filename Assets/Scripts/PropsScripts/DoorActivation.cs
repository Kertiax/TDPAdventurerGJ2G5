using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActivation : MonoBehaviour, IActivableObject
{
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private bool isClosed = true;
    [SerializeField] private Collider2D doorCollider;
    [SerializeField] private List<SpriteRenderer> sidePillarGlowObjects;
    [SerializeField] private List<SidePillarInfo> sidePillarInfo;

    private void Start()
    {
        SetGlowPillar();
    }

    private void SetGlowPillar()
    {
        if (sidePillarInfo.Count > 2 || sidePillarInfo.Count == 0)
        {
            Debug.LogError("The max amount of pillar info is 2 and minimun 1");
        }
        else if (sidePillarInfo.Count == 1)
        {
            foreach (SpriteRenderer item in sidePillarGlowObjects)
            {
                item.color = sidePillarInfo[0].ReturnRGBColor();
            }
        }
        else if (sidePillarInfo.Count == 2)
        {
            for (int i = 0; i < sidePillarGlowObjects.Count; i++)
            {
                sidePillarGlowObjects[i].color = sidePillarInfo[i].ReturnRGBColor();
            }
        }

    }

    public void DeactivateObject(ObjectTypeEnum objectType)
    {
        foreach (SidePillarInfo sidePillar in sidePillarInfo)
        {
            if ((sidePillar.pillarType == ObjectTypeEnum.Default || sidePillar.pillarType == objectType) && sidePillar.isPillarActive)
            {
                sidePillar.isPillarActive = false;
                break;
            }
        }

        CheckCloseDoor();
    }

    public void ActivateObject(ObjectTypeEnum objectType)
    {
        foreach (SidePillarInfo sidePillar in sidePillarInfo)
        {
            if ((sidePillar.pillarType == ObjectTypeEnum.Default || sidePillar.pillarType == objectType) && !sidePillar.isPillarActive)
            {
                sidePillar.isPillarActive = true;
                break;
            }
        }

        CheckOpenDoor();
    }

    private void CheckOpenDoor()
    {
        foreach (SidePillarInfo sidePillar in sidePillarInfo)
        {
            if (!sidePillar.isPillarActive)
            {
                return;
            }
        }

        isClosed = false;

        doorAnimator.SetBool("isClosed", isClosed);

        doorCollider.enabled = false;
    }

    private void CheckCloseDoor()
    {
        foreach (SidePillarInfo sidePillar in sidePillarInfo)
        {
            if (!sidePillar.isPillarActive)
            {
                isClosed = true;

                doorAnimator.SetBool("isClosed", isClosed);

                doorCollider.enabled = true;

                break;
            }
        }
    }

}

[Serializable]
public class SidePillarInfo
{
    public ObjectTypeEnum pillarType;
    public bool isPillarActive = false;

    public Color ReturnRGBColor()
    {
        var pillarColor = pillarType switch
        {
            ObjectTypeEnum.Default => new Color(1, 1, 1, 1),
            ObjectTypeEnum.Green => new Color(0, 1, 0, 1),
            ObjectTypeEnum.Blue => new Color(0, 0, 1, 1),
            ObjectTypeEnum.Red => new Color(1, 0, 0, 1),
            _ => new Color(1, 1, 1, 1),
        };

        return pillarColor;
    }
}
