using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : KienroroMonobehavier
{
    [SerializeField] protected Transform model;
    public Transform Model { get=>model; private set=> model = value; }
    [SerializeField] protected JunkDespawn despawn;

    public JunkDespawn Despawn => despawn;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadJunkDespawn();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log($"{transform.name}: LoadModel{gameObject}");
    }
    
    protected virtual void LoadJunkDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = transform.GetComponentInChildren<JunkDespawn>();
        Debug.Log($"{transform.name}: LoadJunkDespawn{gameObject}");
    }
}
