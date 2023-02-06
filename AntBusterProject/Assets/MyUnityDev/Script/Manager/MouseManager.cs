using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,
    IDragHandler
{
    /*
     *  IsType 상태
     *  0 : None
     *  1 : 포탑 설치 on
     *  
     */

    private Canvas mainCanvas;
    private int IsType;
    public bool isClicked;

    void Start()
    {
        mainCanvas = GFunc.FindRootObj(GFunc.GAMEOBJ_ROOT_NAME).GetComponent<Canvas>();
        IsType = 1; //강제값

        isClicked = false;
    }

    void Update()
    {
        if(isClicked)
        {
            Debug.Log("들어오나?");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("들어오나? OnPointerDown");
        isClicked = true;
        if(IsType == 1)
        {
            //gameObject.AddAnchoredPos(eventData.delta / mainCanvas.scaleFactor);

            Debug.Log($"마우스의 포지션을 확인 : ({eventData.position.x} , {eventData.position.y})");
        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isClicked = false;
        Debug.Log("들어오나? OnPointerUp");

        // 여기서 레벨이 가지고 있는 퍼즐 리스트를 순회해서
        // 가장 가까운 퍼즐을 찾아온다.
        //PuzzleLvPart closeLvPuzzle =
        //playLevel.GetCloseSameTypePuzzle(puzzleType, transform.position);

        //if (closeLvPuzzle == null || closeLvPuzzle == default)
        //{
        //    return;
        //}

        //transform.position = closeLvPuzzle.transform.position;
    }

    //! 마우스를 드래그 중 일때 동작하는 함수
    public void OnDrag(PointerEventData eventData)
    {
        if (isClicked == true)
        {
            Debug.Log("들어오나? OnDrag");
        }
        //{
        //    //gameObject.SetLocalPos(eventData.position.x, eventData.position.y, 0f);
        //    //gameObject.AddAnchoredPos(eventData.delta / puzzleInitZone.parentCanvas.scaleFactor);

        //    //GFunc.Log($"마우스의 포지션을 확인 : ({eventData.position.x} , {eventData.position.y})");
        //}   // if: 현재 오브젝트를 선택한 경우
    }
}