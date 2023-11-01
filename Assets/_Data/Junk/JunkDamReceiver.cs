using _Data.Damege;
using _Data.Item;
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
            this.OnDeadFX();
            this.OnDeadDrop();
            this.junkCtrl.Despawn.DespawnObj();
            
        }

        protected virtual void OnDeadDrop()
        {
            Vector3 pos = transform.parent.position;
            Quaternion rot = transform.parent.rotation;
            ItemDropSpawner.Instance.Drop(this.junkCtrl.JunkSO.dropList, pos, rot);
        }

        protected virtual void OnDeadFX()
        {
            string fxName = this.GetOnDeadFXName();
            Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
            fxOnDead.gameObject.SetActive(true);
        }

        protected virtual string GetOnDeadFXName()
        {
            return FXSpawner.Instance.smokeOne;
        }

        public override void Reborn()
        {
            this.maxHp = this.junkCtrl.JunkSO.hpMax;
            base.Reborn();
        }
    }
}