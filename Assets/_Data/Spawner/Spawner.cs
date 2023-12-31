using System;
using System.Collections;
using System.Collections.Generic;
using _Data.Bullet;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Spawner : KienroroMonobehavier
{
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> poolObj;
    [SerializeField] protected int spawnerCount = 0;

    public List<Transform> Prefabs => prefabs;

    public int SpawnerCount => spawnerCount;


    protected override void LoadComponents()
    {
        this.LoadPrefabs();
        this.LoadHolders();
    }

    protected virtual void LoadHolders()
    {
        if(this.holder != null)return;
        this.holder = transform.Find("Holder");
        Debug.Log(transform.name + " : LoadHolders", gameObject);
    }

    protected virtual void LoadPrefabs()
    {
        if(this.prefabs.Count > 0)return;
        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }

        HidePrefabs();
        
        Debug.Log(transform.name + " : LoadPrefabs", gameObject);
    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation)
    {
        Transform prefab = this.GetPrefabByName(prefabName);

        if (prefab == null)
        {
            // Debug.LogWarning("Prefab is not found!!! " + prefabName); 
            return null;
        }

        return Spawn(prefab, spawnPos, rotation);
    }
    
    public virtual Transform RandomPrefabs()
    {
        int ran = Random.Range(0, this.Prefabs.Count);
        return this.Prefabs[ran];
    }

    public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform newPrefab = GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos, rotation);
        newPrefab.SetParent(this.holder);
        return newPrefab;
    }

    

    public virtual void Despawn(Transform obj)
    {
        this.poolObj.Add(obj);
        obj.gameObject.SetActive(false);
        spawnerCount--;
    }

    private Transform GetObjectFromPool(Transform prefab)
    {
        Transform result = null;
        foreach (Transform pref in poolObj)
        {
            if (pref.name == prefab.name)
            {
                result = pref;
                poolObj.Remove(pref);
                return result;
            }
        }

        result = Instantiate(prefab);
        result.name = prefab.name;
        spawnerCount++;
        return result;
    }

    private Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in prefabs)
        {
            if (prefab.name == prefabName) return prefab;
        }

        return null;
    }
}
