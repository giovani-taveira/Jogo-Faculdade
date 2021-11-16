using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Video : MonoBehaviour
{
    public Dropdown ddpResolution;
    public Dropdown ddpQuality;
    private List<string> resolucoes = new List<string>();
    private List<string> graficos = new List<string>();
    public Button TelaCheia;
    public Button ModoJanela;
    public int Tela;

     void awake()
     {
        //  ddpResolution.onValueChanged.AddListener(new UnityAction<int>(index =>
        //  {
        //      PlayerPrefs.SetInt("Res", ddpResolution.value);
        //      PlayerPrefs.Save();
        //  }));
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        if(PlayerPrefs.HasKey("Res"))
        {
            LoadPrefs();
            Debug.Log("Pegaeijhidjiwejdowe");
            ddpQuality.value = PlayerPrefs.GetInt("Graficos");
        }
        else
        {
            SavePrefs();
        }


        Resolution[] ArrayResolucoes = Screen.resolutions;

        foreach(Resolution r in ArrayResolucoes)
        {
            resolucoes.Add(string.Format("{0} X {1}", r.width, r.height));
            Debug.Log(r);
        }

        ddpResolution.AddOptions(resolucoes);
        ddpResolution.value = (resolucoes.Count -1);

        graficos = QualitySettings.names.ToList<String>();
        ddpQuality.AddOptions(graficos);
        //ddpQuality.value = QualitySettings.GetQualityLevel();

        if(Tela == 0)
        {
            TelaCheia.GetComponent<Image>().color = Color.white;
            ModoJanela.GetComponent<Image>().color = Color.gray;
        }
        else
        {
            TelaCheia.GetComponent<Image>().color = Color.gray;
            ModoJanela.GetComponent<Image>().color = Color.white;
        }
    }

    void Update()
    {
        if(BotoesMenuPrincipal.salvarConfigs)
        {
            SavePrefs();
            Debug.Log("Salvei A Config");
            BotoesMenuPrincipal.salvarConfigs = false;
        }
    }

    public void ModoTelaCheia()
    {
        Tela = 0;
        if(Tela == 0)
        {
            TelaCheia.GetComponent<Image>().color = Color.white;
            ModoJanela.GetComponent<Image>().color = Color.gray;
            Screen.fullScreen = true;
        }
        PlayerPrefs.Save();
    }

    public void ModoModoJanela()
    {
        Tela = 1;
        if(Tela == 1)
        {
            TelaCheia.GetComponent<Image>().color = Color.gray;
            ModoJanela.GetComponent<Image>().color = Color.white;
            Screen.fullScreen = false;
        }
    }

    public void SetaResolucao()
    {
        string[] res = resolucoes[ddpResolution.value].Split('X');
        int w = Convert.ToInt16(res[0].Trim());
        int h = Convert.ToInt16(res[1].Trim());
        Screen.SetResolution(w, h, Screen.fullScreen); 
    }

    public void SetaGrafico()
    {
        QualitySettings.SetQualityLevel(ddpQuality.value, true);
    }

    public void SavePrefs()
    {
        PlayerPrefs.SetInt("Tela", 0); 
        PlayerPrefs.SetInt("Tela", 1);
        PlayerPrefs.SetInt("Resolucao", ddpResolution.value);
        PlayerPrefs.SetInt("Graficos", ddpQuality.value);
        PlayerPrefs.Save();
        
    }

    public void LoadPrefs()
    {
        int tela = (PlayerPrefs.GetInt("Tela"));
        int resolution = PlayerPrefs.GetInt("Res", 0);
        int value = PlayerPrefs.GetInt("Graficos", ddpQuality.value);

        //ddpResolution.value = resolution;

        if(tela == 0)
        {
            TelaCheia.GetComponent<Image>().color = Color.white;
            ModoJanela.GetComponent<Image>().color = Color.gray;
        }
        else
        {
            TelaCheia.GetComponent<Image>().color = Color.gray;
            ModoJanela.GetComponent<Image>().color = Color.white;
        }
    }
}
