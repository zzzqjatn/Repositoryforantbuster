using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,
    IDragHandler
{
    /*
     *  IsType ����
     *  0 : None
     *  1 : ��ž ��ġ on
     *  
     */

    private Canvas mainCanvas;
    private int IsType;
    public bool isClicked;

    void Start()
    {
        mainCanvas = GFunc.FindRootObj(GFunc.GAMEOBJ_ROOT_NAME).GetComponent<Canvas>();
        IsType = 1; //������

        isClicked = false;
    }

    void Update()
    {
        if(isClicked)
        {
            Debug.Log("������?");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("������? OnPointerDown");
        isClicked = true;
        if(IsType == 1)
        {
            //gameObject.AddAnchoredPos(eventData.delta / mainCanvas.scaleFactor);

            Debug.Log($"���콺�� �������� Ȯ�� : ({eventData.position.x} , {eventData.position.y})");
        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isClicked = false;
        Debug.Log("������? OnPointerUp");

        // ���⼭ ������ ������ �ִ� ���� ����Ʈ�� ��ȸ�ؼ�
        // ���� ����� ������ ã�ƿ´�.
        //PuzzleLvPart closeLvPuzzle =
        //playLevel.GetCloseSameTypePuzzle(puzzleType, transform.position);

        //if (closeLvPuzzle == null || closeLvPuzzle == default)
        //{
        //    return;
        //}

        //transform.position = closeLvPuzzle.transform.position;
    }

    //! ���콺�� �巡�� �� �϶� �����ϴ� �Լ�
    public void OnDrag(PointerEventData eventData)
    {
        if (isClicked == true)
        {
            Debug.Log("������? OnDrag");
        }
        //{
        //    //gameObject.SetLocalPos(eventData.position.x, eventData.position.y, 0f);
        //    //gameObject.AddAnchoredPos(eventData.delta / puzzleInitZone.parentCanvas.scaleFactor);

        //    //GFunc.Log($"���콺�� �������� Ȯ�� : ({eventData.position.x} , {eventData.position.y})");
        //}   // if: ���� ������Ʈ�� ������ ���
    }
}