using _Data.Damege;
using UnityEngine;

namespace _Data.Bullet
{
    public class BulletDamSender : DamageSender
    {
        [SerializeField] protected BulletCtrl bulletCtrl;
        public BulletCtrl JunkCtrl { get=>bulletCtrl; private set=> bulletCtrl = value; }
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadBulletCtrl();
        }

        protected virtual void LoadBulletCtrl()
        {
            if (this.bulletCtrl != null) return;
            this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
            Debug.Log($"{transform.name}: LoadBulletCtrl{gameObject}");
        }

        protected override void DestroyObject()
        {
            this.bulletCtrl.BulletDespawn.DespawnObj();
        }
    }
}