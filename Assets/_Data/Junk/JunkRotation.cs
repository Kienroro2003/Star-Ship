using System;
using UnityEngine;

namespace _Data.Junk
{
    public class JunkRotation : JunkAbstract
    {
        [SerializeField] protected float speed = 9f;

        protected void FixedUpdate()
        {
            this.Rotating();
        }

        private void Rotating()
        {
            Vector3 eulers = new Vector3(0, 0, 1);
            junkCtrl.Model.Rotate(eulers * this.speed * Time.fixedDeltaTime);
        }
    }
}