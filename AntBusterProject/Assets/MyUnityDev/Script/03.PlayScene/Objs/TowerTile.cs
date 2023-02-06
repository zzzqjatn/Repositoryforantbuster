using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;


using UnityEngine.UI;

public class TowerTile : MonoBehaviour
{
    public int TILEX;
    public int TILEY;
    public float TILE_SIZE;  //���簢��

    private List<Tile> researchTiles;
    
    public GameObject prefabObj;    // �׽�Ʈ�� ������
    public GameObject prefabTower;

    void Start()
    {
        TILEX = TileSetting.TILEX;
        TILEY = TileSetting.TILEY;
        TILE_SIZE = TileSetting.TILE_SIZE;

        researchTiles = new List<Tile>();

        float StartPosX = 0.0f - gameObject.RectranSize().x / 2;
        float StartPosY = 0.0f + gameObject.RectranSize().y / 2;

        Tile tempTile = new Tile();
        for (int i = 0; i < TILEY; i++)
        {
            for(int j = 0; j < TILEX; j++)
            {
                //GameObject forTemp = Instantiate(prefabObj, gameObject.transform);
                //if ((j + (TILEX * i)) % 2 == 0) { forTemp.GetComponent<Image>().color = Color.white; }
                //else { forTemp.GetComponent<Image>().color = Color.black; }
                //forTemp.RectranLocalPos(new Vector3((StartPosX + TILE_SIZE / 2) + TILE_SIZE * j,
                //                                    (StartPosY - TILE_SIZE / 2) - TILE_SIZE * i, 0.0f));

                tempTile.TowerInit(j + (TILEX * i),
                    (StartPosX + TILE_SIZE / 2) + TILE_SIZE * j,
                    (StartPosY - TILE_SIZE / 2) - TILE_SIZE * i, 2);

                researchTiles.Add(tempTile);
            }
        }
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

    public Tile TowerBuildTime(Vector3 MousePos)
    {
        Tile TempTile = default;
        //4�������� ������ ã��
        TempTile = FindSelectTile(TILEX / 2, TILEY / 2, MousePos.x, MousePos.y);

        if (TempTile == null || TempTile == default) { /* Pass */}
        else
        {
            return TempTile;
        }
        return TempTile;
    }

    public Tile FindSelectTile(int numX, int numY, float fixPosX, float fixPosY)
    {
        int TargetNumX = -1;
        int TargetNumY = -1;

        bool isXright = false;
        bool isYright = false;

        Tile Result = default;
        Tile Target = default;

        Target = researchTiles[numX];
        //�¿� Ž��
        if (fixPosX < (Target.GetPos().x - TILE_SIZE / 2))   // ��ǥ�� ������ �ִٴ� ��
        {
            TargetNumX = numX / 2;
        }
        else if ((Target.GetPos().x + TILE_SIZE / 2) < fixPosX) // ��ǥ�� ������ �ִٴ� ��
        {
            TargetNumX = numX + numX / 2;
        }
        else // ��ǥ�� ���� �ȿ� �ִٴ� ��
        {
            TargetNumX = numX;
            isXright = true;
        }

        Target = researchTiles[numY];
        //����
        if (fixPosY < (Target.GetPos().y - TILE_SIZE / 2))   // ��ǥ�� �Ʒ��ʿ� �ִٴ� ��
        {
            TargetNumY = numY + numY / 2;
        }
        else if ((Target.GetPos().y + TILE_SIZE / 2) < fixPosY) // ��ǥ�� ���ʿ� �ִٴ� ��
        {
            TargetNumY = numY / 2;
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
            Result = FindSelectTile(TargetNumX, TargetNumY, fixPosX, fixPosY);
            if (Result == null || Result == default) { /* Pass */ }
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
}

public class Tower
{

}