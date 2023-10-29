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
        //Override
    }

    protected virtual void ResetValues()
    {
        //Overrides
    }
}
