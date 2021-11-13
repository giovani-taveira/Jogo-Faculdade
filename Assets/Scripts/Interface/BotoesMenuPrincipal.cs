using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotoesMenuPrincipal : MonoBehaviour
{
    public GameObject InterfaceMenuPrincipal;
    public GameObject InterfaceConfig;

    public void Iniciar()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        OutrasAcoes.EstaPausado = false;
    }

    public void Config()
    {
        InterfaceMenuPrincipal.SetActive(false);
        InterfaceConfig.SetActive(true);
    }

    public void ConfigVoltar()
    {
        InterfaceConfig.SetActive(false);
        InterfaceMenuPrincipal.SetActive(true);
    }

    public void Sair()
    {
        Application.Quit();
    }

}
