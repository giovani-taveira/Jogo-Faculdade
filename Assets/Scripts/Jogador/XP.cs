using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XP : MonoBehaviour
{
    #region "Variaveis"
    public float XPNivel = 100;
    public static float XPAtual;
    public float xpNecessario;
    public int Nivel;
    public Image BarraXP;
    private int velocidade = 2;
    public Text TextoNivel;
    public Text Txt_XP;
    #endregion


    void Start()
    {
        BarraXP.fillAmount = 0;

        if(PlayerPrefs.HasKey("XpNecesessario") && PlayerPrefs.HasKey("Nivel"))
        {
            LoadPrefs();
        }
        else
        {
            SavePrefs();
        }     
    }

    void Update()
    {
        if(BarraXP.fillAmount >= 1)
            BarraXP.fillAmount =  0 + (1/xpNecessario) * XPAtual;

        BarraXP.fillAmount = (1/xpNecessario) * XPAtual;
        
        //AdicionaXP();
        AtualizaXP();   
        TextoNivel.text = Nivel.ToString(); 
        Txt_XP.text = $"XP: {XPAtual.ToString("0")}/{XPNivel.ToString("0")}"; 

        if(ControlaEventos.SalvaXP)
        {
            SavePrefs();
            ControlaEventos.SalvaXP = false;
        }    
    }

    public void AdicionaXP()
    {
        if (VidaDoInimigo.DestruiuInimigo == true)
        {
            //BarraXP.fillAmount = (1/xpNecessario) * XPAtual;
            VidaDoInimigo.DestruiuInimigo = false;
        }
    }

    public void AtualizaXP()
    {
        xpNecessario = XPNivel;
        if(XPAtual >= xpNecessario)
        {         
            Nivel += 1;
            XPNivel *= 1.2f;
            XPAtual =  XPAtual - xpNecessario;
               
        }
    }

    void SavePrefs()
    {
        PlayerPrefs.SetFloat("XpAtual", XPAtual);
        PlayerPrefs.SetFloat("XpNivel", XPNivel);
        PlayerPrefs.SetFloat("XpNecesessario", xpNecessario);
        PlayerPrefs.SetInt("Nivel", Nivel);
        PlayerPrefs.Save();
    }

    void LoadPrefs()
    {
        float xpa = PlayerPrefs.GetFloat("XpAtual");
        float xpn = PlayerPrefs.GetFloat("XpNecesessario");
        float xpnv = PlayerPrefs.GetFloat("XpNivel");
        int n = PlayerPrefs.GetInt("Nivel");

        XPAtual = xpa;
        XPNivel = xpnv;
        xpNecessario = xpn;
        Nivel = n;
    }
}
