using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class JunkFly : ParenFly
{
    [SerializeField] protected float minCamPos =  -16f;
    [SerializeField] protected float maxCamPos =  16f;
    
    protected override void ResetValues()
    {
        base.ResetValues();
        this.moveSpeed = 0.5f;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.GetFlyDirection();
    }

    private void GetFlyDirection()
    {
        Vector3 camPos = GameController.Instance.Camera.transform.position;
        Vector3 objPos = transform.parent.position;

        camPos.x += Random.Range(minCamPos, maxCamPos);
        camPos.z += Random.Range(minCamPos, maxCamPos);

        Vector3 diff = camPos - objPos;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z);
        
        Debug.DrawLine(objPos, objPos + diff * 10, Color.red, Mathf.Infinity);
    }
}
