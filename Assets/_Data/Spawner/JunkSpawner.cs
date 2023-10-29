using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawner : Spawner
{
    public static JunkSpawner Instance { get; private set; }

    public static string meteoriteOne = "Meteorite_1"; 
    protected override void Awake()
    {
        base.Awake();
        if (JunkSpawner.Instance != null) Debug.LogError("Only 1 JunkSpawner allow to exist");
        JunkSpawner.Instance = this;
    }
}
