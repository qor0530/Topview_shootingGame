﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CollisionObject
{
    [SerializeField]
    private int Hp = 3;

    // Start is called before the first frame update
    private void Start()
    {
        MovementVector = new Vector2(0, -0.05f);
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Destroy(collision.gameObject);
        }
    }

    public void DecreaseHP(int value = 1)
    {
        Hp -= value;
        if (Hp <= 0)
        {
            var destroyEffectPrefab = Resources.Load("Prefab/Explosion") as GameObject;
            var destroyEffect = Instantiate(destroyEffectPrefab);
            destroyEffect.transform.position = transform.position;
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;

            Invoke("Destroyself", 1f);
            //Destroy(gameObject);
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}