using _Data.Item;
using UnityEngine;

namespace _Data.Resources.Item
{
    [CreateAssetMenu(fileName = "Item", menuName = "SO/Item")]
    public class ItemSO : ScriptableObject
    {
        public ItemCode itemCode = ItemCode.NoItem;
        public string itemName = "Item";
    }
}