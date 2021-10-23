using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutrasAcoes : MonoBehaviour
{
    public static bool EstaPausado = false;
    public GameObject InterfaceMenu;
    public GameObject InterfaceGameplay;

    void Update()
    {
        PausaJogo();
    }

    void PausaJogo()
    {   
        if(Input.GetKeyDown(KeyCode.Escape) && EstaPausado == false)
        {
            Time.timeScale = 0;
            InterfaceMenu.SetActive(true);
            InterfaceGameplay.SetActive(false);
            EstaPausado = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && EstaPausado == true)
        {
            Time.timeScale = 1;
            InterfaceMenu.SetActive(false);
            InterfaceGameplay.SetActive(true);
            EstaPausado = false;
        }
    }
}
