using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;

    public int bulletTermCount = 0;
    public int bulletTerm = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) 
        {
            transform.position = transform.position + new Vector3(-0.1f, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + new Vector3(0.1f, 0);
        }
        if(bulletTermCount++ >= bulletTerm)
        {
            Fire(0.3f);
            Fire(-0.3f);
            bulletTermCount = 0;
        }
    }

    private void Fire(float x = 0)
    {
        var bulletObject = Instantiate(bullet);
        bulletObject.transform.position = transform.position + new Vector3(x, 0);
    }
}
