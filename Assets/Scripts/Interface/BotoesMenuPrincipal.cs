using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotoesMenuPrincipal : MonoBehaviour
{
    public GameObject InterfaceMenuPrincipal, InterfaceConfig, AvisoSemSave, AvisoPerdaDeSave;
    public static bool salvarConfigs = false;

    void Start()
    {
        
    }
    public void Iniciar()
    {
        Time.timeScale = 1;
        OutrasAcoes.EstaPausado = false;

        if(PlayerPrefs.HasKey("Cena"))
        {
            string cena = PlayerPrefs.GetString("Cena");
            SceneLoader.Instance.LoadSceneAsync(cena);
        }
        else
        {    
            AvisoSemSave.SetActive(true);
        }
    }

    public void NovoJogo()
    {
        if(PlayerPrefs.HasKey("Cena"))
        {
            AvisoPerdaDeSave.SetActive(true);
        }
        else
        {
            PlayerPrefs.DeleteAll();
            SceneLoader.Instance.LoadSceneAsync("CasaJeffrey1");
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

    public void Creditos()
    {
        SceneLoader.Instance.LoadSceneAsync("Creditos");  
    }

    public void IniciarNewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneLoader.Instance.LoadSceneAsync("CasaJeffrey1");
    }

    public void PularCreditos()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void SairAviso()
    {
        AvisoSemSave.SetActive(false);
        AvisoPerdaDeSave.SetActive(false);
    }
}
