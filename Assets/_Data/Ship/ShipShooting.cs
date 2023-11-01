using System;
using System.Collections;
using System.Collections.Generic;
using _Data.Bullet;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 1f;
    [SerializeField] protected float shootTimer = 0f;
    
    private void Update()
    {
        IsShooting();
    }

    private void FixedUpdate()
    {
        
        Shooting();
    }

    protected virtual void Shooting()
    {
        if (!isShooting) return;

        shootTimer += Time.fixedDeltaTime;
        if (shootTimer < shootDelay) return;
        shootTimer = 0;
        
        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne, spawnPos, rotation);
        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.Shooter = transform.parent;
        newBullet.gameObject.SetActive(true);
    }

    protected virtual bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFiring == 1;
        return this.isShooting;
    }
}
