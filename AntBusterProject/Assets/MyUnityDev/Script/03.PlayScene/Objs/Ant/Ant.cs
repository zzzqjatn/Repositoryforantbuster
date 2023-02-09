using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Ant : MonoBehaviour
{
    private Rigidbody2D antRig;
    private Vector2 cakeDir;
    private float Speed;
    private int HP;
    private int Level;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void addHit(int damage_)
    {
        HP += damage_;
    }

    public void respawn(Vector2 repos_, Vector2 redir_, float speed_,int level_)
    {
        if(antRig == null || antRig == default)
        {
            antRig = gameObject.GetComponent<Rigidbody2D>();
        }

        cakeDir = redir_;
        Level = level_;
        Speed = speed_;
        HP = Level * 30;

        gameObject.RectranLocalPos(new Vector3(repos_.x, repos_.y, 0.0f));
        antRig.velocity = new Vector3(redir_.x * Speed, redir_.y * Speed, 0.0f);

        float angle = Mathf.Atan2(redir_.y, redir_.x) * Mathf.Rad2Deg;
        gameObject.Rectran().rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

    public void Die()
    {
        gameObject.RectranLocalPos(new Vector3(-500.0f, -500.0f, .0f));
        gameObject.SetActive(false);
    }
}