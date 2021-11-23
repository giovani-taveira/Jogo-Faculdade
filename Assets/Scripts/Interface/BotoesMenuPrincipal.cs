using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotoesMenuPrincipal : MonoBehaviour
{
    public GameObject InterfaceMenuPrincipal;
    public GameObject InterfaceConfig;
    public static bool salvarConfigs = false;
    //public GameObject VerificacaoSave;
    //public GameObject Aviso;

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
            //SceneManager.LoadScene(cena);
        }
        else
        {    
            SceneLoader.Instance.LoadSceneAsync("CasaJeffrey1");
            //VerificacaoSave.SetActive(true);
            //SceneManager.LoadScene("Casa-Frank");
        }
    }

    public void NovoJogo()
    {
        //Aviso.SetActive(true);
        PlayerPrefs.DeleteAll();

        if(PlayerPrefs.HasKey("Cena"))
        {
            string cena = PlayerPrefs.GetString("Cena");
            SceneManager.LoadScene(cena);
        }
        else
        {    
            SceneManager.LoadScene("CasaJeffrey1");
        }
    }

    public void Config()
    {
        InterfaceMenuPrincipal.SetActive(false);
        InterfaceConfig.SetActive(true);
    }

    public void ConfigVoltar()
    {
        //VerificacaoSave.SetActive(false);
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

    }
}
