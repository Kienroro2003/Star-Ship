using System;
using UnityEngine;

namespace _Data.Damege
{
    public abstract class DamageReceiver : KienroroMonobehavier
    {
        [SerializeField] protected float hp = 1;
        [SerializeField] protected float maxHp = 10;
        [SerializeField] protected SphereCollider sphereCollider;
        [SerializeField] protected bool isDead = false;
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadCollider();
        }

        protected virtual void LoadCollider()
        {
            if (this.sphereCollider != null) return;
            this.sphereCollider = GetComponent<SphereCollider>();
            this.sphereCollider.isTrigger = true;
            this.sphereCollider.radius = 0.6f;
            Debug.Log($"{transform.name}: LoadCollider{gameObject}");
        }

        private void OnEnable()
        {
            this.Reborn();
        }

        public virtual void Deduct(float damage)
        {
            this.hp -= damage;
            if (this.hp < 0) this.hp = 0;
            this.CheckIsDead();
        }

        public virtual void Reborn()
        {
            this.hp = this.maxHp;
        }

        public virtual void Add(float deduct)
        {
            this.hp += deduct;
            if (this.hp > this.maxHp) this.hp = this.maxHp;
        }

        public virtual bool IsDead()
        {
            return this.hp <= 0;
        }
        
        protected virtual void CheckIsDead()
        {
            if (!this.IsDead()) return;
            this.isDead = true;
            this.OnDead();
        }

        protected abstract void OnDead();
    }
}