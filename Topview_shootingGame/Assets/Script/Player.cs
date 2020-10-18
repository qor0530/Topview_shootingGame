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
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + new Vector3(-0.1f, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + new Vector3(0.1f, 0);
        }
        if(bulletTermCount++ >= bulletTerm)
        {
            var bulletObject = Instantiate(bullet);
            bulletObject.transform.position = transform.position;
            bulletTermCount = 0;
        }
    }
}
