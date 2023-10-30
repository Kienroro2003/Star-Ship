using _Data.Damege;
using UnityEngine;

namespace _Data.Bullet
{
    public class BulletCtrl : KienroroMonobehavier
    {
        [SerializeField] protected DamageSender damageSender;
        public DamageSender DamageSender
        {
            get => damageSender;
            private set => damageSender = value;
        }
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadDamageSender();
        }

        protected virtual void LoadDamageSender()
        {
            if (this.damageSender != null) return;
            this.damageSender = transform.GetComponentInChildren<DamageSender>();
            Debug.Log($"{transform.name}: LoadDamageSender{gameObject}");
        }
    }
}