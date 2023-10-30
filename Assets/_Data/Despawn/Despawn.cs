using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : KienroroMonobehavier
{

    protected void FixedUpdate()
    {
        this.Despawning();
    }

    protected virtual void Despawning()
    {
        if (!CanDespawn()) return;
        this.DespawnObj();
    }
    
    public virtual void DespawnObj()
    {
        Destroy(this.transform.parent.gameObject);
    }

    

    protected abstract bool CanDespawn();
}
