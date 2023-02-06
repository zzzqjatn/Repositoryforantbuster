using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;


using UnityEngine.UI;

public class TowerTile : MonoBehaviour
{
    public int TILEX;
    public int TILEY;
    public float TILE_SIZE;  //정사각형

    private List<Tile> researchTiles;
    
    public GameObject prefabObj;    // 테스트용 프리펩
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
        //4방향으로 나눠서 찾기
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
        //좌우 탐색
        if (fixPosX < (Target.GetPos().x - TILE_SIZE / 2))   // 목표가 좌측에 있다는 뜻
        {
            TargetNumX = numX / 2;
        }
        else if ((Target.GetPos().x + TILE_SIZE / 2) < fixPosX) // 목표가 우측에 있다는 뜻
        {
            TargetNumX = numX + numX / 2;
        }
        else // 목표가 범위 안에 있다는 뜻
        {
            TargetNumX = numX;
            isXright = true;
        }

        Target = researchTiles[numY];
        //상하
        if (fixPosY < (Target.GetPos().y - TILE_SIZE / 2))   // 목표가 아래쪽에 있다는 뜻
        {
            TargetNumY = numY + numY / 2;
        }
        else if ((Target.GetPos().y + TILE_SIZE / 2) < fixPosY) // 목표가 위쪽에 있다는 뜻
        {
            TargetNumY = numY / 2;
        }
        else // 목표가 범위 안에 있다는 뜻
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
}

public class Tower
{

}