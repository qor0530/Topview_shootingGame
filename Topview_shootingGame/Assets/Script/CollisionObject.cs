using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollisionObject : MonoBehaviour
{
    public Vector2 MovementVector;

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.Translate(MovementVector);
    }

    protected abstract void OnCollisionEnter(Collision collision);
}