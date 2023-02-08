using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class AntObjPool : MonoBehaviour
{
    private const int BASIC_ANT_MAX = 20;
    private const int CAKEANT_MAX = 8; 
    private GameObject antPrefab;
    private List<GameObject> basicAntObjPool;
    private List<GameObject> cakeAntObjPool;
    void Start()
    {
        antPrefab = gameObject.FindChildObj("Ant");

        basicAntObjPool = new List<GameObject>();
        cakeAntObjPool = new List<GameObject>();

        //기본 개미
        for (int i = 0; i < BASIC_ANT_MAX; i++)
        {
            GameObject obj = Instantiate(antPrefab, gameObject.transform);
            obj.RectranLocalPos(new Vector3(-500.0f, -500.0f, 1.0f));
            obj.name = string.Format($"Ant_{i}");
            obj.SetActive(false);

            basicAntObjPool.Add(obj);
        }

        //케이크든 개미
        for (int i = 0; i < CAKEANT_MAX; i++)
        {
            GameObject obj = Instantiate(antPrefab, gameObject.transform);
            obj.RectranLocalPos(new Vector3(-500.0f, -500.0f, 1.0f));
            obj.name = string.Format($"CakeAnt_{i}");
            obj.SetActive(false);

            cakeAntObjPool.Add(obj);
        }

        antPrefab.SetActive(false);
    }

    void Update()
    {
        
    }
}
