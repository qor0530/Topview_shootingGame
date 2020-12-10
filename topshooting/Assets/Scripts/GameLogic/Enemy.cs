using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CollisionObject
{
    // [SerializeField] //private 변수도 Inspector에 나오게 됨
    private int HP = 1;

    private int enemyDataKey;
    private EnemyData Data => EnemyData.Get(enemyDataKey);

    private void Start()
    {
        enemyDataKey = Random.Range(1, EnemyData.All.Length + 1);
        HP = Data.Hp;
        MovementVector = new Vector2(0, -0.05f);

        var sprite = Resources.Load<Sprite>($"Enemies/{ Data.ImageName }");
        GetComponent<SpriteRenderer>().sprite = sprite;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Destroy(collision.gameObject);
            GameScene.Instance.GameOver();
        }
        if (collision.gameObject.name == "EWall")
        {
            Destroy(gameObject);
        }
    }

    public void DecreaseHP(int value = 1)
    {
        HP -= value;

        if (HP == 0)
        {
            var destroyEffectPrefab = Resources.Load("Prefabs/Explosion") as GameObject;
            var destroyEffect = Instantiate(destroyEffectPrefab, transform);
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;

            GameHUD.Instance.AddScore(10);
            Invoke("DestroySelf", 1.0f);
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}