using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class JunkSpawnerRandom : KienroroMonobehavier
{
    [SerializeField] protected JunkSpawnerCtrl junkSpawnerCtrl;
    [SerializeField] protected int randomLimit = 9;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;

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

    protected void FixedUpdate()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        if (this.junkSpawnerCtrl.JunkSpawner.SpawnerCount >= randomLimit) return;
        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer < this.randomDelay) return;
        this.randomTimer = 0;
        Transform randomObj = this.junkSpawnerCtrl.SpawnPoint.GetRandom();
        Vector3 pos = randomObj.position;
        Quaternion rot = randomObj.rotation;
        Transform obj = this.junkSpawnerCtrl.JunkSpawner.Spawn(JunkSpawner.meteoriteOne, pos, rot);
        obj.gameObject.SetActive(true);
    }
}
