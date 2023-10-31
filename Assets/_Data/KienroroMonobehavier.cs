using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KienroroMonobehavier : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValues();
    }
    
    protected virtual void Awake()
    {
        this.LoadComponents();
        
    }

    protected virtual void LoadComponents()
    {
        //For override
    }

    protected virtual void ResetValues()
    {
        //For override
    }

    protected virtual void OnEnable()
    {
        //For override
    }

    protected virtual void OnDisable()
    {
        //For override
    }
}
