using System;
using UnityEngine;

namespace _Data.Damege
{
    public class DamageReceiver : KienroroMonobehavier
    {
        [SerializeField] protected float hp = 1;
        [SerializeField] protected float maxHp = 10;

        private void Start()
        {
            this.Reborn();
        }

        public virtual void Deduct(float damage)
        {
            this.hp -= damage;
            if (this.hp < 0) this.hp = 0;
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
    }
}