using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkFly : ParenFly
{
    protected override void ResetValues()
    {
        base.ResetValues();
        this.moveSpeed = 0.5f;
    }
}
