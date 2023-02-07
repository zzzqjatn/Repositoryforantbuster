using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

using UnityEngine.UI;

public class TowerTile : MonoBehaviour
{
    private int TILEX;
    private int TILEY;
    private float TILE_SIZE;  //���簢��

    private List<Tile> researchTiles;

    //private List<GameObject> GAtiles;
    
    public GameObject prefabObj;    // �׽�Ʈ�� ������
    public GameObject prefabTower;

    private GameObject TileTempObj;
    private GameObject TowerParent;

    void Start()
    {
        TILEX = TileSetting.TILEX;
        TILEY = TileSetting.TILEY;
        TILE_SIZE = TileSetting.TILE_SIZE;

        researchTiles = new List<Tile>();
        //GAtiles = new List<GameObject>();

        TileTempObj = gameObject.FindChildObj("TileTemp");

        TowerParent = gameObject.FindChildObj("TowerSet");

        float StartPosX = 0.0f - gameObject.RectranSize().x / 2;
        float StartPosY = 0.0f + gameObject.RectranSize().y / 2;

        for (int i = 0; i < TILEY; i++)
        {
            for(int j = 0; j < TILEX; j++)
            {
                //GameObject forTemp = Instantiate(prefabObj, TileTempObj.transform);
                //if ((j + (TILEX * i)) % 2 == 0) { forTemp.GetComponent<Image>().color = Color.white; }
                //else { forTemp.GetComponent<Image>().color = Color.black; }
                //forTemp.RectranLocalPos(new Vector3((StartPosX + TILE_SIZE / 2) + TILE_SIZE * j,
                //                                    (StartPosY - TILE_SIZE / 2) - TILE_SIZE * i, 0.0f));
                //forTemp.FindChildObj("indexTxt").SetText(string.Format($"{j + (TILEX * i)}"));
                //forTemp.name = string.Format($"TILE_{j + (TILEX * i)}");
                //GAtiles.Add(forTemp);

                Tile tempTile = new Tile();
                tempTile.TowerInit(j + (TILEX * i),
                    (StartPosX + TILE_SIZE / 2) + TILE_SIZE * j,
                    (StartPosY - TILE_SIZE / 2) - TILE_SIZE * i, 2);

                researchTiles.Add(tempTile);
            }
        }

        TileTempObj.SetActive(false);
    }

    void Update()
    {
        
    }
    public List<Tile> GetTileList()
    {
        if(researchTiles == null || researchTiles == default)
        {
            return null;
        }
        return researchTiles;
    }

    public void TowerBuild(Vector2 MousePos)
    {
        Tile TempTile = default;
        //4�������� ������ ã��
        TempTile = FindSelectTile(MousePos.x, MousePos.y, TILEX / 2, TILEY / 2, TILEX, TILEY);

        if (TempTile == null || TempTile == default) { /* Pass */}
        else
        {
            GameObject towerTemp = Instantiate(prefabTower, TowerParent.transform);
            Vector2 TempPos = researchTiles[TempTile.GetNum()].GetPos();
            towerTemp.RectranLocalPos(new Vector3(TempPos.x, TempPos.y, 0.0f));
        }
    }

    //����Ʈ��
    public Tile FindSelectTile(float fixPosX, float fixPosY, int numX, int numY, int MaxNumX, int MaxNumY)
    {
        int TargetNumX = default;
        int TargetNumY = default;

        bool isXright = false;
        bool isYright = false;

        Tile Result = default;
        Tile Target = default;

        Target = researchTiles[numX];
        //�¿� Ž��
        if (fixPosX < (Target.GetPos().x - TILE_SIZE / 2))   // ��ǥ�� ������ �ִٴ� ��
        {
            TargetNumX = numX - (MaxNumX - numX) / 2;
        }
        else if ((Target.GetPos().x + TILE_SIZE / 2) < fixPosX) // ��ǥ�� ������ �ִٴ� ��
        {
            TargetNumX = numX + (MaxNumX - numX) / 2;
        }
        else // ��ǥ�� ���� �ȿ� �ִٴ� ��
        {
            TargetNumX = numX;
            isXright = true;
        }

        Target = researchTiles[TILEX * numY];
        //����
        if (fixPosY < (Target.GetPos().y - TILE_SIZE / 2))   // ��ǥ�� �Ʒ��ʿ� �ִٴ� ��
        {
            TargetNumY = numY - (MaxNumY - numY) / 2;
        }
        else if ((Target.GetPos().y + TILE_SIZE / 2) < fixPosY) // ��ǥ�� ���ʿ� �ִٴ� ��
        {
            TargetNumY = numY + (MaxNumY - numY) / 2;
        }
        else // ��ǥ�� ���� �ȿ� �ִٴ� ��
        {
            TargetNumY = numY;
            isYright = true;
        }

        if (isXright == true && isYright == true)
        {
            Result = Target;
            return Result;
        }
        else
        {
            Result = FindSelectTile(fixPosX, fixPosY, TargetNumX, TargetNumY, numX, numY);
            if (Result == null || Result == default) { /* Pass */ }
            else { return Result; }
        }
        return Result;
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

    public void TowerInit(int number_,float posx_,float posy_,int isbuild_)
    {
        Number = number_;
        PosX = posx_;
        PosY = posy_;
        isBuild = isbuild_;
    }

    public Vector2 GetPos()
    {
        return new Vector2(PosX, PosY);
    }

    public int GetNum() { return Number; }
}

public class Tower
{

}