using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaEventos : MonoBehaviour
{
    #region "Variaveis"
    public GameObject Spawn1, Spawn2, Spawn3, CanvasDialogo, InterfaceUpgrade;
    public static bool Zoom, SalvaXP, SalvaVida, SalvaMunicao, SalvaPosicao, SalvaMateriais;
    public Animator animacao;
    public Text Txt_PegarItem;
    public static bool AtivaDialogos = false, SpawnaBoss = false;
    public DialogContainer dialogContainer;
    public static bool DesativaText = false;
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
        {
            Zoom = true;
        }

        if(colider.gameObject.tag == "Trigger")
        {
            animacao.SetBool("CaiArvore", true);
            Spawn1.SetActive(true);
            //Debug.Log("Colidiu1");
        }

        if(colider.gameObject.tag == "Trigger2")
        {
            //animacao.SetBool("CaiArvore", true);
            Spawn2.SetActive(true);
            //Debug.Log("Colidiu2");
        }

        if(colider.gameObject.tag == "Trigger3")
        {
            //animacao.SetBool("CaiArvore", true);
            Spawn3.SetActive(true);
            SpawnaBoss = true;
            //Debug.Log("Colidiu3");
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
            {
                Txt_PegarItem.enabled = false;      
            }
        }

        if(colider.gameObject.tag == "CheckPoint")
        {  
            SalvaXP = true;
            SalvaVida = true;
            SalvaMunicao = true;
            SalvaPosicao = true;
            SalvaMateriais = true;
        }

        if(colider.gameObject.tag == "MesaUpgrade")
        {
            Txt_PegarItem.text = "Aperte (e) para fazer upgrade";

            if(Input.GetKeyDown("e"))
                InterfaceUpgrade.SetActive(true);
            
        }
    }
    void OnTriggerExit()
    {
        Txt_PegarItem.enabled = false;
        AtivaDialogos = false;
    }
}
