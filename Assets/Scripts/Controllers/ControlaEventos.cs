using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaEventos : MonoBehaviour
{
    #region "Variaveis"
    public GameObject Spawn1, Spawn2, Spawn3, CanvasDialogo, InterfaceUpgrade, InterfaceGameplay;
    public static bool Zoom, SalvaXP, SalvaVida, SalvaMunicao, SalvaPosicao, SalvaMateriais;
    public Animator animacao;
    public Text Txt_PegarItem;
    public static bool AtivaDialogos = false, DialogoAutomatico = false,  SpawnaBoss = false;
    public DialogContainer dialogContainer;
    public static bool DesativaText = false, AtivaMusica1, AtivaMusica2, AtivaMusica3, DesativaMusica, ZoomBoss; 
    
   
    #endregion
    void Start()
    {     
        Spawn1.SetActive(false);
        Spawn2.SetActive(false);
        Spawn3.SetActive(false);
        //Txt_PegarItem.enabled = false;
    }

    void Update()
    {
        if(ControlaEventos.DesativaText)
        {
            Txt_PegarItem.enabled = false;
            ControlaEventos.DesativaText = false;
        }

        if(VidaDoInimigo.Dialogo)
        {
            CanvasDialogo.SetActive(true);
            VidaDoInimigo.Dialogo = false;
            DialogManager.Instance.StartConversation(dialogContainer);
        }
    }

    void OnTriggerEnter(Collider colider)
    {
        if(colider.gameObject.tag == "ZoomCamera")
            Zoom = true;

        if(colider.gameObject.tag == "TriggerFL1")
        {
            animacao.SetBool("CaiArvore", true);
            Spawn1.SetActive(true);
            AtivaMusica1 = true;
        }

        if(colider.gameObject.tag == "Trigger2")
        {
            //animacao.SetBool("CaiArvore", true);
            Spawn2.SetActive(true);
            AtivaMusica2 = true;
        }

        if(colider.gameObject.tag == "Trigger3")
        {
            //animacao.SetBool("CaiArvore", true);
            Spawn3.SetActive(true);
            SpawnaBoss = true;
            AtivaMusica3 = true;
            ZoomBoss = true;
        }

        if(colider.gameObject.tag == "Item")
        {
            Txt_PegarItem.enabled = true;
            Txt_PegarItem.text = "Aperte (e) para pegar o item";
        }

        if(colider.gameObject.tag == "Frank")
        {
            Txt_PegarItem.enabled = true;
            Txt_PegarItem.text = "Aperte (e) para interagir";
            AtivaDialogos = true;

            if(Input.GetKeyDown("e"))        
                Txt_PegarItem.enabled = false;      
        }

        if(colider.gameObject.tag == "TriggerCJ2-1")
        { 
            DialogoAutomatico = true;
            AtivaDialogos = true;
            DialogTrigger.DialogoAutomatico = true;
        }

        if(colider.gameObject.tag == "TriggerCJ3-1")
        { 
            DialogoAutomatico = true;
            AtivaDialogos = true;
            DialogTrigger.DialogoAutomatico = true;
        }

        if(colider.gameObject.tag == "CheckPoint")
        {  
            SalvaXP = true;
            SalvaVida = true;
            SalvaMunicao = true;
            SalvaPosicao = true;
            SalvaMateriais = true;
            DesativaMusica = true;
            AtivaMusica1 = false;
            AtivaMusica2 = false;
            AtivaMusica3 = false;
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.tag == "MesaUpgrade")
        {
            Txt_PegarItem.text = "Aperte (e) para acessar a mesa";

            if(Input.GetKeyDown("e"))
            {
                PlayerShoot.PodeAtirar = false;
                InterfaceUpgrade.SetActive(true);
                InterfaceGameplay.SetActive(false);    
                Time.timeScale = 0;
            }
        }
    }
    void OnTriggerExit()
    {
        Txt_PegarItem.enabled = false;
        AtivaDialogos = false;
    }
}
