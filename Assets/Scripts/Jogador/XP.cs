﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XP : MonoBehaviour
{
    public float XPNivel = 100;
    public float XPAtual;
    public float xpNecessario;
    public int Nivel;
    public Image BarraXP;
    private int velocidade = 2;
    public Text TextoNivel;

    void Start()
    {
        BarraXP.fillAmount = 0;
    }

    void Update()
    {
        if(BarraXP.fillAmount >= 1)
            BarraXP.fillAmount =  0 + (1/xpNecessario) * XPAtual;
        
        AdicionaXP();
        AtualizaXP();              
    }

    public void AdicionaXP()
    {
        if (MovimentaBala.DestruiuInimigo == true)
        {
            XPAtual += 23;
            BarraXP.fillAmount = (1/xpNecessario) * XPAtual;
            MovimentaBala.DestruiuInimigo = false;
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
            TextoNivel.text = Nivel.ToString();    
        }
    }
}
