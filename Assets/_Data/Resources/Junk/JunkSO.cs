using System.Collections;
using System.Collections.Generic;
using _Data.Item;
using UnityEngine;

[CreateAssetMenu(fileName = "Junk", menuName = "SO/Junk")]
public class JunkSO : ScriptableObject
{
    public string junkName = "Junk";
    public int hpMax = 2;
    public List<DropRate> dropList;
}
