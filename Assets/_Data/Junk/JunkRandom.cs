using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRandom : KienroroMonobehavier
{
    [SerializeField] protected JunkCtrl junkCtrl;
    [SerializeField] protected float timeRandom = 2f;

    protected override void LoadComponents()
    {
        // base.LoadComponents();
        this.LoadJunkCtrl();
    }

    private void LoadJunkCtrl()
    {
        if(this.junkCtrl != null)return;
        this.junkCtrl = GetComponent<JunkCtrl>();
        Debug.Log($"{transform.transform}: LoadJunkCtrl{gameObject}");
    }

    protected void Start()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        Transform randomObj = this.junkCtrl.SpawnPoint.GetRandom();
        Vector3 pos = randomObj.position;
        Quaternion rot = randomObj.rotation;
        Transform obj = this.junkCtrl.JunkSpawner.Spawn(JunkSpawner.meteoriteOne, pos, rot);
        obj.gameObject.SetActive(true);
        Invoke(nameof(this.JunkSpawning), timeRandom);
    }
}
