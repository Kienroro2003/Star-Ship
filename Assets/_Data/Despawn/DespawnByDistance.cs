using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLimit = 70f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected Transform camera;

    protected override void LoadComponents()
    {
        // base.LoadComponents();
        this.LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (this.camera != null)
        {
            return;
        }
        this.camera = Transform.FindObjectOfType<Camera>().transform;
        Debug.Log(transform.parent.parent.name +": LoadCamera", camera);
    }

    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(this.transform.position, camera.position);
        // Debug.Log($"Camera: {camera.position}, transform: {transform.position}, result {distance}");
        if (this.distance > this.disLimit) return true;
        return false;
    }

}
