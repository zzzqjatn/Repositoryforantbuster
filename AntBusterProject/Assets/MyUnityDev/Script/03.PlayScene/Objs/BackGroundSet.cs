using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundSet : MonoBehaviour
{
    public GameObject TowerPrefabs;
    private GameObject BackGround;
    private GameObject BackGround_nullsize;

    void Start()
    {
        BackGround = GFunc.FindRootObj("GameObjs").FindChildObj("BackGround");
        BackGround_nullsize = GFunc.FindRootObj("GameObjs").FindChildObj("FIndTemp");

        float StartPosX = BackGround.RectranLeftTop().x;
        float StartPosY = BackGround.RectranLeftTop().y;

        float P_offsetX = TowerPrefabs.RectranSize().x / 2;
        float P_offsetY = TowerPrefabs.RectranSize().y / 2;

        float StartX = StartPosX + P_offsetX;
        float StartY = StartPosY + P_offsetY + BackGround_nullsize.RectranSize().y / 2;

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 25; j++)
            {
                GameObject temp = Instantiate(TowerPrefabs,gameObject.transform);
                temp.RectranLocalPos(new Vector3(StartX + (TowerPrefabs.RectranSize().x * j),
                                                    StartY + (TowerPrefabs.RectranSize().y * i),
                                                    0.0f));
            }
        }
    }

    void Update()
    {
        
    }
}
