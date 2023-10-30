using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class JunkRandom : KienroroMonobehavier
{
    [SerializeField] protected JunkSpawnerCtrl junkSpawnerCtrl;
    [SerializeField] protected float timeRandom = 2f;

    protected override void LoadComponents()
    {
        // base.LoadComponents();
        this.LoadJunkSpawnerCtrl();
    }

    private void LoadJunkSpawnerCtrl()
    {
        if(this.junkSpawnerCtrl != null)return;
        this.junkSpawnerCtrl = GetComponent<JunkSpawnerCtrl>();
        Debug.Log($"{transform.transform}: LoadJunkSpawnerCtrl{gameObject}");
    }

    protected void Start()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        Transform randomObj = this.junkSpawnerCtrl.SpawnPoint.GetRandom();
        Vector3 pos = randomObj.position;
        Quaternion rot = randomObj.rotation;
        Transform obj = this.junkSpawnerCtrl.JunkSpawner.Spawn(JunkSpawner.meteoriteOne, pos, rot);
        obj.gameObject.SetActive(true);
        Invoke(nameof(this.JunkSpawning), timeRandom);
    }
}
