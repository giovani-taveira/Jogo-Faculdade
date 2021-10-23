using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaXP : MonoBehaviour
{
    public float nivelAtual = 1, nivelMax = 100, XpNivel = 100, XpMultiplicar = 1.2f; 
    private float  XpNivelAtual;
    public static float XpAtual;
    private Text nivel;
    private Slider slider;


    void Start()
    {
        nivel = transform.GetComponentInChildren<Text>();
        slider = transform.GetComponentInChildren<Slider>();

        if(XpNivelAtual == 0)
        {
            XpNivelAtual = XpNivel;
        }

        Atualizar();
    }

    void Update()
    {
        if(MovimentaBala.DestruiuInimigo == true)
        {
            AddXP(20);
            MovimentaBala.DestruiuInimigo = false;
        }
    }

    public void AddXP(float xp)
    {   
        float soma = XpAtual + xp;
        float sub = soma - XpNivelAtual;

        if(soma < XpNivelAtual)
        {
            XpAtual += xp;

        }
        else if(soma == XpNivelAtual)
        {
            Upar(0);
            XpAtual = 0;
        }
        else if(soma > XpNivelAtual)
        {
            XpAtual = 0;
            Upar(sub);
        }

        Atualizar();
    }

    public void Upar(float xp)
    {
        if(nivelAtual >= nivelMax)
        {
            XpAtual = XpNivelAtual;
            Atualizar();
            return;
        }

        float NextNivel = XpNivelAtual * XpMultiplicar;
        nivelAtual++;
        XpNivelAtual = NextNivel;

        AddXP(xp);
    }

    public void Atualizar()
    {
        nivel.text = "Nivel:" + nivelAtual;
        slider.maxValue = XpNivelAtual;
        slider.value = XpAtual;
    }
}
