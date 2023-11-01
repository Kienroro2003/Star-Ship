using System.Collections.Generic;
using UnityEngine;

namespace _Data.Item
{
    public class ItemDropSpawner : Spawner
    {
        public static ItemDropSpawner Instance { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            if (ItemDropSpawner.Instance != null) Debug.LogError("Only 1 ItemDropSpawner allow to exist");
            ItemDropSpawner.Instance = this;
        }

        public virtual void Drop(List<DropRate> dropList, Vector3 pos, Quaternion rot)
        {
            ItemCode itemCode = dropList[0].itemSO.itemCode;
            Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);
            itemDrop.gameObject.SetActive(true);
        }
    }
}