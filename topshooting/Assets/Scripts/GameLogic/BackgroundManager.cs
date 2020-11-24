using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public List<GameObject> BackgroundSprites;
    public float MovementSpeed = 0.01f;

    private float startY;
    private float spriteHeight;

    // Start is called before the first frame update
    private void Start()
    {
        startY = BackgroundSprites[0].transform.position.y;
        spriteHeight = BackgroundSprites[0].GetComponent<SpriteRenderer>().bounds.size.y;

        for (int i = 1; i < BackgroundSprites.Count; ++i)
        {
            var prevBack = BackgroundSprites[i - 1];
            var curBack = BackgroundSprites[i];
            curBack.transform.position = new Vector2(0, prevBack.transform.position.y + spriteHeight);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < BackgroundSprites.Count; ++i)
        {
            var background = BackgroundSprites[i];

            if (background.transform.position.y < startY - spriteHeight)
            {
                var prevIndex = i - 1;

                if (prevIndex == -1)
                    prevIndex = BackgroundSprites.Count - 1;

                var prevBack = BackgroundSprites[prevIndex];

                background.transform.position = new Vector2(0, prevBack.transform.position.y + spriteHeight);
            }
            background.transform.Translate(new Vector2(0, -MovementSpeed));
        }
    }
}
