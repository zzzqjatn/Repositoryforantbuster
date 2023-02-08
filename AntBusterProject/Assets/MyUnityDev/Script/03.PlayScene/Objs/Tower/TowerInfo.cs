using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInfo : MonoBehaviour
{
    private BulletObjPool bulletPool;
    private int[] TowerLevel = new int[6];

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
        { bulletPool = GFunc.FindRootObj(GFunc.GAMEOBJ_ROOT_NAME).FindChildObj("TowerBulletPool").GetComponent<BulletObjPool>(); }

        gameObject.RectranLocalPos(new Vector3(pos.x, pos.y, 0.0f));
    }

    public void bulletSetting()
    {
        Vector2 dir = new Vector2(0, 1);

        //��ǥ���� ���� ���ϱ� [�ڽ��� ��ġ���� �����ϴ�]
        Vector3 Resultdir = new Vector3(
            gameObject.RectranLocalPos().x + dir.x, gameObject.RectranLocalPos().y + dir.y, 0.0f);
        Resultdir -= new Vector3(gameObject.RectranLocalPos().x, gameObject.RectranLocalPos().y,0.0f);

        //Ÿ���� �Ѿ˹�ġ�� �̰� �Ÿ�
        float distance = 2.0f;
        
        //�Ѿ� ��ġ
        Vector3 ResultPos = new Vector3(
            gameObject.RectranLocalPos().x + Resultdir.x * distance,
            gameObject.RectranLocalPos().y + Resultdir.y * distance,
            0.0f);

        bulletPool.Setbullet(ResultPos, Resultdir.normalized,100,1,150); 
    }
}
