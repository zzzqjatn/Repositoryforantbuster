using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
{
    private int cakeNum;

    void Start()
    {
        cakeNum = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            returnToCake();
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            goToAnt();
        }
    }

    public void returnToCake()
    {
        cakeNum += 1;
        if(cakeNum > 8 ) { cakeNum = 8; }

        if (cakeNum < 8)
        {
            gameObject.SetImage(string.Format($"cake_{cakeNum}"));
        }
        else
        {
            gameObject.OutImage();
        }
    }

    public void goToAnt()
    {
        cakeNum -= 1;
        if (cakeNum < 0) { cakeNum = 0; }

        gameObject.SetImage(string.Format($"cake_{cakeNum}"));
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.Equals("Ant"))
        {
            goToAnt();
        }
    }
}
