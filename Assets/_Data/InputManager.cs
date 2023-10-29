using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    [SerializeField] public Vector3 MouseWorldPos { get; private set; }
    [SerializeField] public float OnFiring;
    
    void Awake()
    {
        if (InputManager.Instance != null) Debug.LogError("Only 1 InputManager allow to exist");
        InputManager.Instance = this;
    }
    
    private void Update()
    {
        GetMouseDown();
    }

    private void FixedUpdate()
    {
        GetMousePos();
    }

    protected virtual void GetMousePos()
    {
        this.MouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    protected virtual void GetMouseDown()
    {
        this.OnFiring = Input.GetAxis("Fire1");
    }
}
