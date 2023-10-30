using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : KienroroMonobehavier
{
    [SerializeField] protected static GameController instance;
    public static GameController Instance
    {
        get => instance;
        set => instance = value;
    }

    [SerializeField] protected Camera camera;
    public Camera Camera
    {
        get => camera;
        private set => camera = value;
    }

    protected override void Awake()
    {
        base.Awake();
        if (GameController.Instance != null) Debug.LogError("Only 1 GameController allow to exist");
        GameController.Instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCamera();
    }
    
    

    private void LoadCamera()
    {
        if (this.Camera != null) return;
        this.Camera = GameController.FindObjectOfType<Camera>();
        Debug.Log($"{transform.name} : LoadCamera{gameObject}");
    }
}
