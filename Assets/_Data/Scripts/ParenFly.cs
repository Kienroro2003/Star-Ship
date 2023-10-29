using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParenFly : KienroroMonobehavier
{
    [SerializeField] protected float moveSpeed = 1;
    [SerializeField] protected Vector3 direction = Vector3.right;

    // Update is called once per frame
    void Update()
    {
        transform.parent.Translate(this.direction * moveSpeed * Time.deltaTime);
    }
}
