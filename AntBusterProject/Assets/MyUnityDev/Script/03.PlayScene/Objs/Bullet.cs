using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D bulletRig;
    private int Damage;

    private Vector2 EndDistance;
    private Vector2 Dir;
    void Start()
    {

    }

    void Update()
    {
        AutoDie();
    }

    public void bulletFire(Vector2 pos_, Vector2 dir_, int speed, int Damage_, float Distance_)
    {
        if(bulletRig == null || bulletRig == default)
        { bulletRig = gameObject.GetComponent<Rigidbody2D>(); }

        gameObject.RectranLocalPos(new Vector3(pos_.x, pos_.y, 0.0f));
        Dir = dir_;
        bulletRig.velocity = new Vector2(Dir.x * speed * Time.deltaTime, Dir.y * speed * Time.deltaTime);
        Damage = Damage_;

        //종료거리          (시작지점)                      
        EndDistance.x = gameObject.RectranLocalPos().x + (dir_.x * Distance_);
        EndDistance.y = gameObject.RectranLocalPos().y + (dir_.y * Distance_);
    }

    private void AutoDie()
    {
        if (gameObject.RectranLocalPos().z == 0.0f)
        {
            if(Dir.x < 0)   // 방향이 음수이면 내려가는 것이기 때문에
            {
                if(gameObject.RectranLocalPos().x < EndDistance.x)  //목표값보다 낮아지면
                {
                    bulletDie();
                }
            }
            else if (Dir.x > 0) // 방향이 양수이면 올라가는 것이기 때문에
            {
                if (gameObject.RectranLocalPos().x > EndDistance.x) //목표값보다 높아지면
                {
                    bulletDie();
                }
            }

            if (Dir.y < 0)   // 방향이 음수이면 내려가는 것이기 때문에
            {
                if (gameObject.RectranLocalPos().y < EndDistance.y)  //목표값보다 낮아지면
                {
                    bulletDie();
                }
            }
            else if (Dir.y > 0) // 방향이 양수이면 올라가는 것이기 때문에
            {
                if (gameObject.RectranLocalPos().y > EndDistance.y) //목표값보다 높아지면
                {
                    bulletDie();
                }
            }
        }
    }

    public void bulletDie()
    {
        bulletRig.velocity = Vector2.zero;
        gameObject.RectranLocalPos(new Vector3(-500.0f, -500.0f, 1.0f));
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
