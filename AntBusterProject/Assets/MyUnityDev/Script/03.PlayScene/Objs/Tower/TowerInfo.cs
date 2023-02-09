using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TowerInfo : MonoBehaviour
{
    private GameObject towerTop;
    private BulletObjPool bulletPool;
    private AntObjPool antPool;
    private int[] TowerLevel = new int[6];
    float bulletDistance;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            bulletSetting();
        }
    }

    public void TowerSet(Vector2 pos)
    {
        if (bulletPool == null || bulletPool == default)
        {
            bulletPool = GFunc.FindRootObj(GFunc.GAMEOBJ_ROOT_NAME)
                .FindChildObj("TowerBulletPool").GetComponent<BulletObjPool>();
        }

        if (towerTop == null || towerTop == default)
        {
            towerTop = gameObject.FindChildObj("Tower_Top");
        }

        if(antPool == null || antPool == default)
        {
            antPool = GFunc.FindRootObj(GFunc.GAMEOBJ_ROOT_NAME).FindChildObj("EnemyObjs").GetComponent<AntObjPool>();
        }

        gameObject.RectranLocalPos(new Vector3(pos.x, pos.y, 0.0f));
    }

    public void bulletSetting()
    {
        bulletDistance = 150.0f;

        Vector2 dir = antPool.FindCrossAntToDIR(gameObject, bulletDistance);

        //��ǥ���� ���� ���ϱ� [�ڽ��� ��ġ���� �����ϴ�]
        Vector3 EndDir = new Vector3(
            gameObject.RectranLocalPos().x + dir.x, gameObject.RectranLocalPos().y + dir.y, 0.0f);
        Vector3 StartDir = new Vector3(gameObject.RectranLocalPos().x, gameObject.RectranLocalPos().y, 0.0f);
        Vector3 Resultdir = EndDir - StartDir;

        //��ž ���� �Ѿ� ��� ���� �ٶ󺸱�
        float angle = Mathf.Atan2(Resultdir.y, Resultdir.x) * Mathf.Rad2Deg;
        towerTop.Rectran().rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        //float targetRotation = Mathf.Atan((EndDir.y - StartDir.y) / (EndDir.x - StartDir.x));
        //towerTop.Rectran().rotation = Quaternion.Euler(0, 0, targetRotation);

        //Ÿ���� �Ѿ˹�ġ�� �̰� �Ÿ�
        float distance = 2.0f;
        
        //�Ѿ� ��ġ
        Vector3 ResultPos = new Vector3(
            gameObject.RectranLocalPos().x + Resultdir.x * distance,
            gameObject.RectranLocalPos().y + Resultdir.y * distance,
            0.0f);

        bulletPool.Setbullet(ResultPos, Resultdir.normalized,100,1, (int)bulletDistance); 
    }
}
