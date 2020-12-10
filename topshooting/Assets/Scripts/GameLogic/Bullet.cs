using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : CollisionObject
{
    // Start is called before the first frame update
    private void Start()
    {
        MovementVector = new Vector2(0, 0.1f);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Wall")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            collision.gameObject.GetComponent<Enemy>().DecreaseHP();
            Destroy(gameObject);
        }
    }
}