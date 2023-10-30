using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerCtrl : KienroroMonobehavier
{
    [SerializeField] protected JunkSpawner junkSpawner;

    public JunkSpawner JunkSpawner
    {
        get => junkSpawner;
    }

    [SerializeField] protected SpawnPoint spawnPoints;
    public SpawnPoint SpawnPoint { get => spawnPoints; }

    protected override void LoadComponents()
    {
        // base.LoadComponents();
        this.LoadJunkSpawner();
        this.LoadPoints();
    }

    protected virtual void  LoadJunkSpawner()
    {
        if (this.junkSpawner != null) return;
        this.junkSpawner = GetComponent<JunkSpawner>();
        Debug.Log($"{transform.name} : LoadJunkSpawner{gameObject}");
    }
    
    private void LoadPoints()
    {
        if(this.spawnPoints != null)return;
        this.spawnPoints = Transform.FindObjectOfType<JunkSpawnPoint>();
        Debug.Log($"{transform.name}: LoadPoints{gameObject}");
    }
}
