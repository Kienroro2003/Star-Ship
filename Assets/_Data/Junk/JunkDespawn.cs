using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDespawn : DespawnByDistance
{
    protected override void DespawnObj()
    {
        JunkSpawner.Instance.Despawn(transform.parent);
    }
}           
