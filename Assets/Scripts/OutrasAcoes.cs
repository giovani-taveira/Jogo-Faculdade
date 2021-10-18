using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutrasAcoes : MonoBehaviour
{
    bool EstaPausado = false;
    public GameObject InterfaceMenu;

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
            EstaPausado = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && EstaPausado == true)
        {
            Time.timeScale = 1;
            InterfaceMenu.SetActive(false);
            EstaPausado = false;
        }
    }
}
