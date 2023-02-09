using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class AntObjPool : MonoBehaviour
{
    private const int BASIC_ANT_MAX = 20;
    private const int CAKEANT_MAX = 8;
    private Vector2 AntHome;
    private Vector2 CakeHome;
    private GameObject antPrefab;
    private List<GameObject> basicAntObjPool;
    private List<GameObject> cakeAntObjPool;

    private GameObject cakeInfo;

    private int antCurrentNum;
    private int cakeAntCurrentNum;

    private float currentTime;
    void Start()
    {
        AntHome = new Vector2(-240.0f, 190.0f);
        CakeHome = new Vector2(240.0f, -190.0f);

        antPrefab = gameObject.FindChildObj("Ant");
        cakeInfo = GFunc.FindRootObj(GFunc.GAMEOBJ_ROOT_NAME).FindChildObj("Cake");

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

        currentTime = 0.0f;
        antCurrentNum = 0;
        cakeAntCurrentNum = 0;
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= 1.0f)
        {
            AntRespawn();
            currentTime = 0.0f;
        }
    }

    public void AntRespawn()
    {
        for(int i = 0; i < basicAntObjPool.Count; i++)
        {
            if (basicAntObjPool[antCurrentNum].activeSelf == false)
            {
                basicAntObjPool[antCurrentNum].SetActive(true);
                basicAntObjPool[antCurrentNum].GetComponent<Ant>().respawn(
                    AntHome,(CakeHome - AntHome).normalized,(200.0f * Time.deltaTime),0);

                //(CakeHome - AntHome).normalized 랜덤방향 줘서 포탑 총알 방향 확인하기

                antCurrentNum++;
                if (antCurrentNum >= basicAntObjPool.Count) antCurrentNum = 0;
                break;
            }
            else
            {
                antCurrentNum++;
                if (antCurrentNum >= basicAntObjPool.Count) antCurrentNum = 0;
            }
        }
    }

    public Vector3 FindCrossAntToDIR(GameObject obj,float distance)
    {
        Vector3 Result = default;

        float SearchCross = distance;
        float TargetCross = 0.0f;

        for(int i = 0; i < basicAntObjPool.Count; i++)
        {
            TargetCross = Vector2.Distance(basicAntObjPool[i].RectranLocalPos(), obj.RectranLocalPos());
            if (SearchCross > TargetCross)
            {
                SearchCross = TargetCross;
                Result = basicAntObjPool[i].RectranLocalPos();
            }
        }
        Result = Result - obj.RectranLocalPos();

        return new Vector2(Result.x,Result.y).normalized;
    }

    //public void CakeAntRespawn()
    //{
    //    for (int i = 0; i < CAKEANT_MAX; i++)
    //    {
    //        if (basicAntObjPool[antCurrentNum].activeSelf == false)
    //        {
    //            basicAntObjPool[antCurrentNum].GetComponent<Ant>().respawn(AntHome, (CakeHome - AntHome).normalized, 5, 0);
    //            antCurrentNum++;
    //            if (antCurrentNum >= basicAntObjPool.Count) antCurrentNum = 0;
    //            break;
    //        }
    //        else
    //        {
    //            antCurrentNum++;
    //            if (antCurrentNum >= basicAntObjPool.Count) antCurrentNum = 0;
    //        }
    //    }
    //}
}
