using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : ParenFly
{
    protected override void ResetValues()
    {
        base.ResetValues();
        this.moveSpeed = 7;
    }
}
