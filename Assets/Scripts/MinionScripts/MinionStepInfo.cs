using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionStepInfo : MonoBehaviour
{
    public ObjectTypeEnum minionColorType;
    public Color minionColor;

    public MinionStepInfo GetMinionColor()
    {
        return this;
    }
}

