using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class SpawnPoint : KienroroMonobehavier
{
    [SerializeField] protected List<Transform> points;
    public List<Transform> Points { get => points; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoints();
    }

    protected virtual void LoadPoints()
    {
        if(this.points.Count > 0)return;
        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            this.points.Add(prefab);
        }

        
        Debug.Log(transform.name + " : LoadPoints", gameObject);
    }

    public virtual Transform GetRandom()
    {
        int r = Random.Range(0, points.Count);

        return points[r];
    }
}
