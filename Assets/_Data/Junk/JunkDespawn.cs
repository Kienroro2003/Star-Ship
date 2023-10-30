using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDespawn : DespawnByDistance
{
    protected override void ResetValues()
         {
             base.ResetValues();
             this.disLimit = 50f;
         }

    protected override void DespawnObj()
    {
        JunkSpawner.Instance.Despawn(transform.parent);
    }
}           
