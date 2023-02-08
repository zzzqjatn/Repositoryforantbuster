using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerObjPool : MonoBehaviour
{
    private const int TOWER_MAX = 30;

    private GameObject towerPrefab;
    private List<GameObject> towerPool;

    private int towerindex;

    void Start()
    {
        towerPool = new List<GameObject>();
        towerPrefab = gameObject.FindChildObj("Tower");
        towerindex = 0;

        for (int i = 0; i < TOWER_MAX; i++)
        {
            GameObject obj = Instantiate(towerPrefab, gameObject.transform);
            obj.name = string.Format($"Tower_{i}");
            obj.RectranLocalPos(new Vector3(-500.0f, -500.0f, 1.0f));
            obj.SetActive(false);
            towerPool.Add(obj);
        }
        towerPrefab.SetActive(false);
    }

    void Update()
    {
        
    }

    public void SetTower(Vector2 pos_)
    {
        for(int i = towerindex; i < towerPool.Count; i++)
        {
            if (towerPool[i].activeSelf == false)
            {
                towerPool[i].SetActive(true);
                towerPool[i].GetComponent<TowerInfo>().TowerSet(pos_);
                towerindex++;
                if (towerindex >= towerPool.Count) towerindex = 0;
                break;
            }
            else
            {
                towerindex++;
                if (towerindex >= towerPool.Count) towerindex = 0;
            }
        }
    }
}
