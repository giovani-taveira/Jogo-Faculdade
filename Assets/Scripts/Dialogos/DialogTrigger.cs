using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public DialogContainer dialogContainer;
    public GameObject InterfaceDialogos;

    void Update()
    {
        if(ControlaEventos.AtivaDialogos && Input.GetKeyDown("e"))
        {
            InterfaceDialogos.SetActive(true);
            DialogManager.Instance.StartConversation(dialogContainer);
            ControlaEventos.AtivaDialogos = false;
        }
    }
}
