using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro.EditorUtilities;
using UnityEngine;

using UnityEngine.UI;

public class TowerTile : MonoBehaviour
{
    private int TILEX;
    private int TILEY;
    private float TILE_SIZE;  //���簢��

    private List<Tile> searchTiles;

    void Start()
    {
        TILEX = TileSetting.TILEX;
        TILEY = TileSetting.TILEY;
        TILE_SIZE = TileSetting.TILE_SIZE;

        searchTiles = new List<Tile>();

        float StartPosX = 0.0f - gameObject.RectranSize().x / 2;
        float StartPosY = 0.0f + gameObject.RectranSize().y / 2;

        for (int i = 0; i < TILEY; i++)
        {
            for(int j = 0; j < TILEX; j++)
            {
                Tile tempTile = new Tile();
                tempTile.TowerInit(j + (TILEX * i),
                    (StartPosX + TILE_SIZE / 2) + TILE_SIZE * j,
                    (StartPosY - TILE_SIZE / 2) - TILE_SIZE * i, 2);

                searchTiles.Add(tempTile);
            }
        }
    }

    void Update()
    {
        
    }

    public List<Tile> GetTileList()
    {
        if(searchTiles == null || searchTiles == default)
        {
            return null;
        }
        return searchTiles;
    }

    public Tile GetTile(Vector2 MousePos)
    {
        Tile TempTile = default;
        //4�������� ������ ã��
        TempTile = FindSelectTile(MousePos, TILEX, TILEY);

        if (TempTile == null || TempTile == default) { /* Pass */}
        else
        {
            return TempTile;
        }
        return TempTile;
    }

    //����Ʈ��
    public Tile FindSelectTile(Vector2 findPos, int MaxNumX, int MaxNumY)
    {
        int TargetMinNumX = 0;
        int TargetMaxNumX = MaxNumX;
        int TargetMinNumY = 0;
        int TargetMaxNumY = MaxNumY;

        int MiddleNum = 0;

        int ResultX = 0;
        int ResultY = 0;

        bool isXright = false;
        bool isYright = false;

        Tile Result = default;
        Tile Target = default;

        while (TargetMinNumX <= TargetMaxNumX)
        {
            MiddleNum = (TargetMinNumX + TargetMaxNumX) / 2;

            Target = searchTiles[MiddleNum];
            //�¿� Ž��
            if (findPos.x < (Target.GetPos().x - TILE_SIZE / 2))   // ��ǥ�� ������ �ִٴ� ��
            {
                TargetMaxNumX = MiddleNum - 1;
            }
            else if ((Target.GetPos().x + TILE_SIZE / 2) < findPos.x) // ��ǥ�� ������ �ִٴ� ��
            {
                TargetMinNumX = MiddleNum + 1;
            }
            else// ��ǥ�� ���� �ȿ� �ִٴ� ��
            {
                ResultX = MiddleNum;
                isXright = true;
                break;
            }
        }

        while (TargetMinNumY <= TargetMaxNumY)
        {
            MiddleNum = (TargetMinNumY + TargetMaxNumY) / 2;

            Target = searchTiles[TILEX * MiddleNum];
            //����
            if (findPos.y < (Target.GetPos().y - TILE_SIZE / 2))   // ��ǥ�� �Ʒ��ʿ� �ִٴ� ��
            {
                TargetMinNumY = MiddleNum + 1;
            }
            else if ((Target.GetPos().y + TILE_SIZE / 2) < findPos.y) // ��ǥ�� ���ʿ� �ִٴ� ��
            {
                TargetMaxNumY = MiddleNum - 1;
            }
            else // ��ǥ�� ���� �ȿ� �ִٴ� ��
            {
                ResultY = MiddleNum;
                isYright = true;
                break;
            }
        }

        if (isXright == true && isYright == true)
        {
            Target = searchTiles[ResultX + (TILEX * ResultY)];
            Result = Target;
            return Result;
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