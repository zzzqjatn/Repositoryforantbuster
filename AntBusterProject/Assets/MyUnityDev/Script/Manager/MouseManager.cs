using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,
    IDragHandler
{
    /*
    *  IsType ����
    *  0 : None
    *  1 : ��ž ��ġ on
    */

    private GameObject BgObj;
    private Canvas mainCanvas;

    private TowerTile towerTile_;
    private TowerObjPool towerobjs_;

    public int IsType;
    private bool isClicked;

    void Start()
    {
        BgObj = GFunc.FindRootObj(GFunc.GAMEOBJ_ROOT_NAME).FindChildObj("BgObjs");
        mainCanvas = GFunc.FindRootObj(GFunc.GAMEOBJ_ROOT_NAME).GetComponent<Canvas>();

        towerTile_ = gameObject.GetComponent<TowerTile>();

        GameObject obj = gameObject.FindChildObj("TowerObjPool");

        towerobjs_ = obj.GetComponent<TowerObjPool>();

        IsType = 1;
        isClicked = false;
    }

    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isClicked = true;

        float MouseX = eventData.position.x / mainCanvas.scaleFactor;
        float MouseY = eventData.position.y / mainCanvas.scaleFactor;

        //Debug.Log($" ���� ���콺 ��ġ Ȯ�� : ({MouseX} , {MouseY})");

        float offsetX = (BgObj.RectranSize().x - gameObject.RectranSize().x) / 2;
        float offsetY = (BgObj.RectranSize().y - gameObject.RectranSize().y);

        float PosOffsetX = gameObject.RectranSize().x / 2;
        float PosOffsetY = gameObject.RectranSize().y / 2;

        float LocalOffsetX = gameObject.RectranLocalPos().x * (-1);
        float LocalOffsetY = gameObject.RectranLocalPos().y * (-1);

        float RightX = MouseX - (offsetX + PosOffsetX) + LocalOffsetX;
        float RightY = MouseY - (offsetY + PosOffsetY - 1.5f);

        //Debug.Log($" ���콺 ������ ��ġ Ȯ�� : ({RightX} , {RightY})");

        switch (IsType)
        {
            case 1:
                Tile temp = towerTile_.GetTile(new Vector2(RightX, RightY));
                towerobjs_.SetTower(temp.GetPos());
                break;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isClicked = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isClicked == true)
        {

        }
    }
}
