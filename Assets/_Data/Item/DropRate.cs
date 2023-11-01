using System;
using _Data.Resources.Item;


namespace _Data.Item
{
    [Serializable]
    public class DropRate
    {
        public ItemSO itemSO;
        public int dropRate;
        public int minDrop;
        public int maxDrop;
    }
}