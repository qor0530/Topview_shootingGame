using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    public Transform player;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        transform.Translate(x * speed * Time.deltaTime, y * speed * Time.deltaTime, 0);
        Vector2 v2 = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.position;
        player.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg);
    }
}