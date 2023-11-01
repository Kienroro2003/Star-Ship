using System;
using UnityEngine;

namespace _Data.Bullet
{
    [RequireComponent(typeof(SphereCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class BulletImpart : BulletAbstract
    {
        [SerializeField] protected SphereCollider sphereCollider;
        [SerializeField] protected Rigidbody _rigidbody;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadCollider();
            this.LoadRigibody();
        }

        protected virtual void LoadRigibody()
        {
            if (this._rigidbody != null) return;
            this._rigidbody = GetComponent<Rigidbody>();
            this._rigidbody.isKinematic = true;
            Debug.Log($"{transform.name}: LoadRigibody{gameObject}");
        }

        protected virtual void LoadCollider()
        {
            if (this.sphereCollider != null) return;
            this.sphereCollider = GetComponent<SphereCollider>();
            this.sphereCollider.isTrigger = true;
            this.sphereCollider.radius = 0.09f;
            Debug.Log($"{transform.name}: LoadCollider{gameObject}");
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.transform.parent.name == this.bulletCtrl.Shooter.name) return;
            this.bulletCtrl.DamageSender.Send(other.transform);
            this.CreateImpactFX();
        }

        protected virtual void CreateImpactFX()
        {
            
            string fxName = this.GetImpactName();
            Transform impactFX = ImpactSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
            impactFX.gameObject.SetActive(true);
        }

        protected virtual string GetImpactName()
        {
            return ImpactSpawner.Instance.impactOne;
        }
    }
}