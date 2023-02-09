using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using Unity.Mathematics;
using UnityEngine;

using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.U2D;
using Unity.VisualScripting;

public static partial class GFunc
{
    public const string GAMEOBJ_ROOT_NAME = "GameObjs";
    public const string TileListObj_NAME = "InGameMapTile";

    public static SpriteAtlas allsprite;

    public static void OutImage(this GameObject obj)
    {
        Image tempImage = default;
        tempImage = obj.GetComponent<Image>();

        tempImage.sprite = null;

        Color tempAlpha = tempImage.color;
        tempAlpha.a = 0.0f;
        tempImage.color = tempAlpha;
    }
    public static void SetImage(this GameObject obj, string imageName)
    {
        if (allsprite == null || allsprite == default)
        {
            allsprite = Resources.Load<SpriteAtlas>("SpriteAtlas/SpriteAtlas");
        }
        Image tempImage = default;
        tempImage = obj.GetComponent<Image>();

        tempImage.sprite = allsprite.GetSprite(imageName);

        if(tempImage.color.a == 0.0f)
        {
            Color tempAlpha = tempImage.color;
            tempAlpha.a = 1.0f;
            tempImage.color = tempAlpha;
        }
    }

    public static void SetText(this GameObject obj,string text)
    {
        TMP_Text tempTxt = default;
        tempTxt = obj.GetComponent<TMP_Text>();

        tempTxt.text = text;
    }


    //! ������Ʈ�� ��Ŀ �������� �����ϴ� �Լ�
    public static Vector2 ReturnAnchoredPos(this GameObject obj_, Vector2 position2D)
    {
        Vector2 Result = obj_.Rectran().anchoredPosition;
        Result += position2D;
        return Result;
    }

    //! ������Ʈ�� ��Ŀ �������� �����ϴ� �Լ�
    public static void AddAnchoredPos(this GameObject obj_, Vector2 position2D)
    {
        obj_.Rectran().anchoredPosition += position2D;
    }

    public static Vector3 RectranLeftTop(this GameObject obj)
    {
        Vector3 Result = default;

        Vector3 tmepPos = obj.GetComponent<RectTransform>().localPosition;
        Vector3 tempSize = obj.GetComponent<RectTransform>().sizeDelta;

        Result = new Vector3((tmepPos.x - (tempSize.x / 2)),
                            (tmepPos.y + (tempSize.y / 2)), 
                            tmepPos.z);
        return Result;
    }
    public static Quaternion RectranLocalRot(this GameObject obj)
    {
        Quaternion Result = default;
        Result = obj.GetComponent<RectTransform>().localRotation;
        return Result;
    }

    public static void RectranLocalPos(this GameObject obj,Vector3 init)
    {
        obj.GetComponent<RectTransform>().localPosition = init;
    }

    public static Vector3 RectranLocalPos(this GameObject obj)
    {
        Vector3 Result = default;
        Result = obj.GetComponent<RectTransform>().localPosition;
        return Result;
    }

    public static Vector2 RectranSize(this GameObject obj)
    {
        Vector2 Result = default;
        Result = obj.GetComponent<RectTransform>().sizeDelta;
        return Result;
    }

    public static RectTransform Rectran(this GameObject obj)
    {
        RectTransform Result = default;
        Result = obj.GetComponent<RectTransform>();
        return Result;
    }

    public static GameObject FindChildObj(this GameObject rootObjs,string objName)
    {
        GameObject Result = default;
        GameObject Target = default;

        for(int i = 0; i < rootObjs.transform.childCount; i++)
        {
            Target = rootObjs.transform.GetChild(i).gameObject;
            if(Target.name.Equals(objName))
            {
                Result = Target;
                return Result;
            }
            else
            {
                Result = FindChildObj(Target, objName);
                if(Result == default || Result == null) { /* Pass */ }
                else { return Result; }
            }
        }

        return Result;
    }

    public static GameObject FindRootObj(string objName)
    {
        GameObject Result = default;
        GameObject[] RootObjs = GFunc.GetActiveScene().GetRootGameObjects();

        foreach(GameObject obj in RootObjs)
        {
            if(obj.name.Equals(objName))
            {
                Result = obj;
                return Result;
            }
            else { continue; }
        }

        return Result;
    }

    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static Scene GetActiveScene()
    {
        Scene Result = default;
        Result = SceneManager.GetActiveScene();
        return Result;
    }
}
