using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D bulletRig;
    void Start()
    {
        bulletRig = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    public void bulletFire(Vector2 pos, Vector2 dir, int speed)
    {
        gameObject.RectranLocalPos(new Vector3(pos.x, pos.y, 0.0f));
        gameObject.
    }

    public void bulletDie()
    {
        bulletRig.velocity = Vector2.zero;
        gameObject.RectranLocalPos(new Vector3(-500.0f, -500.0f, 0.0f));
        gameObject.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("enemy"))
        {
            bulletDie();
        }
    }
}
