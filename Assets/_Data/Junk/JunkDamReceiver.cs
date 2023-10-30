using _Data.Damege;
using UnityEngine;

namespace _Data.Junk
{
    public class JunkDamReceiver : DamageReceiver
    {
        [SerializeField] protected JunkCtrl junkCtrl;
        public JunkCtrl JunkCtrl { get=>junkCtrl; private set=> junkCtrl = value; }
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadJunkCtrl();
        }
        
        protected virtual void LoadJunkCtrl()
        {
            if (this.junkCtrl != null) return;
            this.junkCtrl = transform.parent.GetComponent<JunkCtrl>();
            Debug.Log($"{transform.name}: LoadJunkCtrl{gameObject}");
        }

        protected override void OnDead()
        {
            this.junkCtrl.Despawn.DespawnObj();
        }
    }
}