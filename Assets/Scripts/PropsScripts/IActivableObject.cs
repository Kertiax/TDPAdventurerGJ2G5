using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IActivableObject
{
    public void ActivateObject(ObjectTypeEnum objectType);

    public void DeactivateObject(ObjectTypeEnum objectType);
}
