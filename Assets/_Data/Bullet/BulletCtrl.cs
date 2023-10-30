using _Data.Damege;
using UnityEngine;

namespace _Data.Bullet
{
    public class BulletCtrl : KienroroMonobehavier
    {
        [SerializeField] protected DamageSender damageSender;
        [SerializeField] protected BulletDespawn bulletDespawn;

        public BulletDespawn BulletDespawn => bulletDespawn;

        public DamageSender DamageSender
        {
            get => damageSender;
            private set => damageSender = value;
        }
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadDamageSender();
            this.LoadBulletDespawn();
        }

        protected virtual void LoadDamageSender()
        {
            if (this.damageSender != null) return;
            this.damageSender = transform.GetComponentInChildren<DamageSender>();
            Debug.Log($"{transform.name}: LoadDamageSender{gameObject}");
        }
        
        protected virtual void LoadBulletDespawn()
        {
            if (this.bulletDespawn != null) return;
            this.bulletDespawn = transform.GetComponentInChildren<BulletDespawn>();
            Debug.Log($"{transform.name}: LoadBulletDespawn{gameObject}");
        }
    }
}