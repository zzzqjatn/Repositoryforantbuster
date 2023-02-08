using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletObjPool : MonoBehaviour
{
    private const int BULLET_MAX = 300;

    private GameObject bulletPrefab;
    private List<GameObject> bulletPool;

    private int bulletindex;

    void Start()
    {
        bulletPool = new List<GameObject>();
        bulletPrefab = gameObject.FindChildObj("Bullet");
        bulletindex = 0;

        for (int i = 0; i < BULLET_MAX; i++)
        {
            GameObject obj = Instantiate(bulletPrefab, gameObject.transform);
            obj.name = string.Format($"Bullet_{i}");
            obj.RectranLocalPos(new Vector3(-500.0f, -500.0f, 1.0f));
            obj.SetActive(false);
            bulletPool.Add(obj);
        }
        bulletPrefab.SetActive(false);
    }

    void Update()
    {

    }

    public void Setbullet(Vector2 pos_, Vector2 dir_, int speed_, int damage_, int distance_)
    {
        for (int i = bulletindex; i < bulletPool.Count; i++)
        {
            if (bulletPool[i].activeSelf == false)
            {
                bulletPool[bulletindex].SetActive(true);
                bulletPool[bulletindex].GetComponent<Bullet>().bulletFire(pos_, dir_, speed_, damage_, distance_);
                bulletindex++;
                if (bulletindex >= bulletPool.Count) bulletindex = 0;
                break;
            }
            else
            {
                bulletindex++;
                if (bulletindex >= bulletPool.Count) bulletindex = 0;
            }
        }
    }
}
