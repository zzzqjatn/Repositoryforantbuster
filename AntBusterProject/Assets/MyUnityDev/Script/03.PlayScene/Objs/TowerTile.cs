using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;

public class TowerTile : MonoBehaviour
{
    private const int TILEX = 25;
    private const int TILEY = 9;
    private const float TILE_SIZE = 20.0f;  //���簢��

    private List<Tile> tiles;

    public GameObject prefabObj;

    void Start()
    {
        tiles = new List<Tile>();

        float StartPosX = gameObject.RectranLeftTop().x;
        float StartPosY = gameObject.RectranLeftTop().y;

        Debug.Log(StartPosX + " , " + StartPosY);

        Debug.Log(gameObject.RectranSize().x + " , " + gameObject.RectranSize().y);

        GameObject DebugTemp = Instantiate(prefabObj, gameObject.transform);
        DebugTemp.RectranLocalPos(new Vector3(StartPosX, StartPosY, 0.0f));
        DebugTemp.name = "thisPoint";

        Tile tempTile = default;
        for (int i = 0; i < TILEY; i++)
        {
            for(int j = 0; j < TILEX; j++)
            {
                GameObject forTemp = Instantiate(prefabObj, gameObject.transform);

                if ((j + (j * i)) % 2 == 0) { forTemp.GetComponent<Image>().color = Color.white; }
                else { forTemp.GetComponent<Image>().color = Color.black; }

                forTemp.RectranLocalPos(new Vector3((StartPosX + TILE_SIZE / 2) + TILE_SIZE * j,
                                                    (StartPosY + TILE_SIZE / 2) + TILE_SIZE * i, 0.0f));
            }
        }

        prefabObj.SetActive(false);
    }

    void Update()
    {
        
    }
}

public class Tile
{
    /*
     * isBuild ����
     * 0 = ���� ��ġ �ȵǴ� ����
     * 1 = �ֺ� ��ġ�� Ÿ�� ������ �ɷ� ��ġ �ȵǴ� ���� (Ÿ�� �� 3x3)
     * 2 = ��ġ���� ����
     */

    private int Number;
    private float PosX;
    private float PosY;
    private int isBuild;
    //private Tower inTower;

    public void TowerInit(int number_,int posx_,int posy_,int isbuild_)
    {
        Number = number_;
        PosX = posx_;
        PosY = posy_;
        isBuild = isbuild_;
    }
}

public class Tower
{

}