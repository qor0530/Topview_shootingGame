using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CollisionObject
{
    public GameObject bullet;

    public int bulletTermCount = 0;
    public int bulletTerm = 20;
    private float MovementSpeed = 0.1f;
    private float defaultY;

    private void Start()
    {
        defaultY = transform.position.y;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        MovementVector = Vector2.zero;

        if (Input.GetMouseButton(0))
        {
            var worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var diff = worldPosition.x - transform.position.x;  //천천히 따라오게 만드는 변수
            if (Mathf.Abs(diff) < 0.05f)
            {
                transform.position = new Vector3(worldPosition.x, defaultY, 0);
            }
            else
            {
                MovementVector = new Vector2(diff / 10, 0);
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            MovementVector = new Vector2(-MovementSpeed, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            MovementVector = new Vector2(MovementSpeed, 0);
        }
        if (bulletTermCount++ >= bulletTerm)
        {
            Fire(0.3f);
            Fire(-0.3f);
            bulletTermCount = 0;
        }
    }

    private void Fire(float x = 0)
    {
        var bulletObject = Instantiate(bullet);
        bulletObject.transform.position = transform.position + new Vector3(x, 0.4f);
    }

    protected override void OnCollisionEnter(Collision collision)
    {
    }
}