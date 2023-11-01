using UnityEngine;

namespace _Data.Damege
{
    // [RequireComponent(typeof(SphereCollider))]
    public class DamageSender : KienroroMonobehavier
    {
        [SerializeField] protected float damage = 1;

        public virtual void Send(Transform obj)
        {
            DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
            if (damageReceiver == null) return;
            this.Send(damageReceiver);
        }

        public virtual void Send(DamageReceiver damageReceiver)
        {
            damageReceiver.Deduct(damage);
            DestroyObject();
        }

        protected virtual void DestroyObject()
        {
            Destroy(transform.parent.gameObject);
        }
    }
}