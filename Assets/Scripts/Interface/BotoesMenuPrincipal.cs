using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotoesMenuPrincipal : MonoBehaviour
{
    public GameObject InterfaceMenuPrincipal;
    public GameObject InterfaceConfig;
    public static bool salvarConfigs = false;

    public void Iniciar()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        OutrasAcoes.EstaPausado = false;
        string cena = PlayerPrefs.GetString("Cena");
        string res = PlayerPrefs.GetString("Res");
        SceneManager.LoadScene(cena);
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
        salvarConfigs = true;
    }

    public void Sair()
    {
        Application.Quit();
    }

}
