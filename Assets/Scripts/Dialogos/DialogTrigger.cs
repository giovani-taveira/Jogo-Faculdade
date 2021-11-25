﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTrigger : MonoBehaviour
{
    public DialogContainer dialogContainer, dialogContainer2;

    public GameObject InterfaceDialogos;
    public Text Txt_Interagir;
    public static bool DialogoAutomatico = false;

    void Update()
    {
        if(ControlaEventos.AtivaDialogos && Input.GetKeyDown("e"))
        {
            InterfaceDialogos.SetActive(true);
            Txt_Interagir.enabled = false;
            DialogManager.Instance.StartConversation(dialogContainer);
            ControlaEventos.AtivaDialogos = false;
        }

        if (ControlaEventos.DialogoAutomatico && ControlaEventos.AtivaDialogos && DialogoAutomatico)
        {
            InterfaceDialogos.SetActive(true);
            Txt_Interagir.enabled = false;
            DialogManager.Instance.StartConversation(dialogContainer);
            ControlaEventos.AtivaDialogos = false;
            DialogoAutomatico = false;
        } 

        if (ControlaEventos.DialogoImpedirProgresso)
        {
            InterfaceDialogos.SetActive(true);
            Txt_Interagir.enabled = false;
            DialogManager.Instance.StartConversation(dialogContainer2);
            ControlaEventos.AtivaDialogos = false;
            ControlaEventos.DialogoImpedirProgresso = false;
            //Time.timeScale = 0;
        } 
    }
}
