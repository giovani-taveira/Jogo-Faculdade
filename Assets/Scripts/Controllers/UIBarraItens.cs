using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBarraItens : MonoBehaviour
{

    public Image Item1, Item2, Item3, Item4;
    void Start()
    {
        Item1.enabled = false;
        Item2.enabled = true;
        Item3.enabled = true;
        Item4.enabled = true;
    }


    void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            Item1.enabled = false;
            Item2.enabled = true;
            Item3.enabled = true;
            Item4.enabled = true;
        }
        if(Input.GetKeyDown("2"))
        {
            Item1.enabled = true;
            Item2.enabled = false;
            Item3.enabled = true;
            Item4.enabled = true;
        }
        if(Input.GetKeyDown("3"))
        {
            Item1.enabled = true;
            Item2.enabled = true;
            Item3.enabled = false;
            Item4.enabled = true;
        }
        if(Input.GetKeyDown("4"))
        {
            Item1.enabled = true;
            Item2.enabled = true;
            Item3.enabled = true;
            Item4.enabled = false;
        }
    }
}
