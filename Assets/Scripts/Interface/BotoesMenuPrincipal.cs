using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotoesMenuPrincipal : MonoBehaviour
{
    public GameObject InterfaceMenuPrincipal;
    public GameObject InterfaceConfig;
    public static bool salvarConfigs = false;


    void Start()
    {
        //PlayerPrefs.DeleteAll();
    }
    public void Iniciar()
    {

        Time.timeScale = 1;
        OutrasAcoes.EstaPausado = false;

        if(PlayerPrefs.HasKey("Cena"))
        {
            string cena = PlayerPrefs.GetString("Cena");
            SceneManager.LoadScene(cena);
        }
        else
        {    
            SceneManager.LoadScene("Casa-Frank");
        }
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
