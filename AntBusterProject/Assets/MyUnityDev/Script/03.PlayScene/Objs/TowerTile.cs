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
    private float TILE_SIZE;  //정사각형

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
        //4방향으로 나눠서 찾기
        TempTile = FindSelectTile(MousePos, TILEX, TILEY);

        if (TempTile == null || TempTile == default) { /* Pass */}
        else
        {
            return TempTile;
        }
        return TempTile;
    }

    //이진트리
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
            //좌우 탐색
            if (findPos.x < (Target.GetPos().x - TILE_SIZE / 2))   // 목표가 좌측에 있다는 뜻
            {
                TargetMaxNumX = MiddleNum - 1;
            }
            else if ((Target.GetPos().x + TILE_SIZE / 2) < findPos.x) // 목표가 우측에 있다는 뜻
            {
                TargetMinNumX = MiddleNum + 1;
            }
            else// 목표가 범위 안에 있다는 뜻
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
            //상하
            if (findPos.y < (Target.GetPos().y - TILE_SIZE / 2))   // 목표가 아래쪽에 있다는 뜻
            {
                TargetMinNumY = MiddleNum + 1;
            }
            else if ((Target.GetPos().y + TILE_SIZE / 2) < findPos.y) // 목표가 위쪽에 있다는 뜻
            {
                TargetMaxNumY = MiddleNum - 1;
            }
            else // 목표가 범위 안에 있다는 뜻
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
     * isBuild 설명
     * 0 = 원래 설치 안되는 지형
     * 1 = 주변 설치된 타워 범위에 걸려 설치 안되는 지형 (타워 당 3x3)
     * 2 = 설치가능 지형
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