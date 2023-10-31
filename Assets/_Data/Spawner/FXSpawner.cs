using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    public static FXSpawner Instance { get; private set; }

    public string smokeOne = "Smoke_1"; 
    protected override void Awake()
    {
        base.Awake();
        if (FXSpawner.Instance != null) Debug.LogError("Only 1 FXSpawner allow to exist");
        FXSpawner.Instance = this;
    }
}
