using UnityEngine;
using UnityEngine.Serialization;

namespace _Data.Bullet
{
    
    public class BulletAbstract : KienroroMonobehavier
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
    }
}