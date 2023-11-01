using System.Collections.Generic;
using UnityEngine;

namespace _Data.Item
{
    public class DropManager : KienroroMonobehavier
    {
        private static DropManager instance;
        public static DropManager Instance => instance;
    
        protected override void Awake()
        {
            base.Awake();
            if (DropManager.instance != null) Debug.LogError("Only 1 DropManager allow to exist");
            DropManager.instance = this;
        }

        public virtual void Drop(List<DropRate> dropList)
        {
            Debug.Log(dropList[0].itemSO.itemName);
        }
    }
}