﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arma : MonoBehaviour
{
    #region "Variaveis"
    public GameObject ArmaLonga;
    public GameObject ArmaCurta;
    public Animator animacao; 
    public GameObject KitMedico;
    public static bool KitEquipado;
   
    #endregion
    void Start()
    {
        ArmaCurta.SetActive(false);
        ArmaLonga.SetActive(false);
        KitMedico.SetActive(false);
        animacao.SetInteger("Transition", 0);
    }

    void Update()
    {
        TrocaArma();
    }

    void TrocaArma()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            ArmaCurta.SetActive(false);
            ArmaLonga.SetActive(false);
            KitMedico.SetActive(false);
            animacao.SetInteger("Transition", 0);
            KitEquipado = false;
            //ContadorMunição.enabled = false;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            ArmaCurta.SetActive(true);
            ArmaLonga.SetActive(false);
            KitMedico.SetActive(false);
            animacao.SetInteger("Transition", 2);
            KitEquipado = false;
            //ContadorMunição.enabled = true;
        }
        if(Input.GetKey(KeyCode.Alpha3))
        {
            ArmaCurta.SetActive(false);
            ArmaLonga.SetActive(true);
            KitMedico.SetActive(false);
            animacao.SetInteger("Transition", 1);
            KitEquipado = false;
            //ContadorMunição.enabled = true;
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            ArmaCurta.SetActive(false);
            ArmaLonga.SetActive(false);
            KitMedico.SetActive(true);
            animacao.SetInteger("Transition", 0);
            KitEquipado = true;
        }
    }
}
