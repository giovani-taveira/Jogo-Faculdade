using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipaArma : MonoBehaviour
{
    public GameObject Pistola, Uzi, Shotgun, RifleDeAssalto, LMG;
    bool UziDesbloqueada = false, ShotgunDesbloqueada = false, LMGDesbloqueada = false;
    int CustoUZI = 200, CustoShotgun = 300, CustoLMG = 800;
    public GameObject Btn_DesblockUZI;
    public GameObject Btn_DesblockShotgun, Btn_DesblockLMG;
    public GameObject InterfaceUpgrade, InterfaceGameplay;
 
    void Start()
    {
        Pistola.SetActive(true);
        RifleDeAssalto.SetActive(true);
    }
    void Update()
    {
        DesativaBtns();  
    }

    public void EquipaPistola()
    {
        Pistola.SetActive(true);
        Uzi.SetActive(false);

    }
    public void EquipaUzi()
    {
        if(UziDesbloqueada)
        {
            Pistola.SetActive(false);
            Uzi.SetActive(true);
        }
    }

    public void EquipaRifleDeAssalto()
    {
        RifleDeAssalto.SetActive(true);
        LMG.SetActive(false);
        Shotgun.SetActive(false);
    }

    public void EquipaShotgun()
    {
        if(ShotgunDesbloqueada)
        {
            RifleDeAssalto.SetActive(false);
            LMG.SetActive(false);
            Shotgun.SetActive(true);
        }
    }

    public void EquipaLMG()
    {
        if(LMGDesbloqueada)
        {
            RifleDeAssalto.SetActive(false);
            LMG.SetActive(true);
            Shotgun.SetActive(false);
        }
    }

    public void DesbloqueiaUZI()
    {
        if(Materiais.MateriaisAtuais >= CustoUZI)
        {
            Materiais.MateriaisAtuais -= CustoUZI;
            UziDesbloqueada = true;     
        }
    }

    public void DesbloaqueiaShotgun()
    {
        if(Materiais.MateriaisAtuais >= CustoShotgun)
        {
            Materiais.MateriaisAtuais -= CustoShotgun;
            ShotgunDesbloqueada = true;
        }
    }

    public void DesbloqueiaLMG()
    {
        if(Materiais.MateriaisAtuais >= CustoLMG)
        {
            Materiais.MateriaisAtuais -= CustoLMG;
            LMGDesbloqueada = true;
        }
    }

    public void DesativaBtns()
    {
        if(UziDesbloqueada)
            Btn_DesblockUZI.SetActive(false);

        if(ShotgunDesbloqueada)
            Btn_DesblockShotgun.SetActive(false);

        if(LMGDesbloqueada)
            Btn_DesblockLMG.SetActive(false); 
    }

    public void Voltar()
    {
        InterfaceUpgrade.SetActive(false);
        Time.timeScale = 1;
        InterfaceGameplay.SetActive(true);
        PlayerShoot.PodeAtirar = false;
    }
}
