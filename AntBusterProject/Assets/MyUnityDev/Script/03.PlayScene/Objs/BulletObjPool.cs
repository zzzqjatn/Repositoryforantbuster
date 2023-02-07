using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BulletObjPool : MonoBehaviour
{
    private const int BULLET_MAX = 200;

    private GameObject bulletPrefab;
    private List<GameObject> bulletPool;

    private float currenttime;
    private int bulletindex;


    void Start()
    {
        bulletPool = new List<GameObject>();
        bulletPrefab = gameObject.FindChildObj("Bullet");

        currenttime = 0.0f;
        bulletindex = 0;

        for (int i = 0; i < BULLET_MAX; i++)
        {
            GameObject obj = Instantiate(bulletPrefab,gameObject.transform);
            obj.name = string.Format($"Bullet_{i}");
            obj.RectranLocalPos(new Vector3(-500.0f, -500.0f, 0.0f));
            obj.SetActive(false);
            bulletPool.Add(obj);
        }
        bulletPrefab.SetActive(false);
    }

    void Update()
    {
        
    }

    public void shotTheTriger(Vector2 pos_,Vector2 dir_, int speed_)
    {
        while (true)
        {
            if (bulletPool[bulletindex].activeSelf == false)
            {
                bulletPool[bulletindex].SetActive(true);
                bulletPool[bulletindex].GetComponent<Bullet>().bulletFire(pos_, dir_, speed_);
                break;
            }
            bulletindex++;
            if (bulletindex > bulletPool.Count) bulletindex = 0;
        }
    }
}
