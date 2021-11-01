using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaracteristicasArmas : MonoBehaviour
{
    #region "Variaveis"
    public GameObject Bala;
    public GameObject ReferenciaBala;
    //public Text ContadorMunição;

    [Space]
    [Header("Munição")]
    public int MaxMunicaoNoPente;
    public int MunicaoNoPente;
    public int Municao;
    public int MaxMunicao;
    public int TempoRecarregar;
    private bool Recarregavel = true;
    private int TimeTr;
    public static int DanoArma;
    public Text ContadorMunicao;
    public int Dano;
    public bool ArmaAutomatica;
    public float CadenciaDeTiro;
    private float ProximoTiro;
    #endregion

    void Start()
    {
        DanoArma = Dano; 
    }

    void Update()
    {
        if(Municao > MaxMunicao)
        {
            Municao = MaxMunicao;
        }
        RecarregaArma();
        atirar();
        ContadorMunicao.text = $"{MunicaoNoPente.ToString()}/{Municao.ToString()}";

        if(CaixaMunicao.PegouMunicao == true)
        {
            Municao += MaxMunicaoNoPente;
            CaixaMunicao.PegouMunicao = false;
        }
    }

    void RecarregaArma()
    { 
        if(Input.GetKeyDown("r") && MunicaoNoPente != MaxMunicaoNoPente && Municao != 0 && Recarregavel == true)
        {
            Recarregavel = false;
        }

        if(Recarregavel == false)
        {
            if(TimeTr > TempoRecarregar)
            {
                for(int i = 0; i < MaxMunicaoNoPente; i++)
                {
                    if(MunicaoNoPente < MaxMunicaoNoPente && Municao > 0)
                    {
                        Municao -= 1;
                        MunicaoNoPente += 1;
                    }
                    else
                    {
                        break;
                    }
                    Recarregavel = true;
                    TimeTr = 0;
                }
            }
            else
            {
                TimeTr += 1;
            }
        }
    }

    void atirar()
    {
        if(ArmaAutomatica == false)
        {
            if((Input.GetMouseButtonDown(0)) && OutrasAcoes.EstaPausado == false && MunicaoNoPente > 0 && Time.time > ProximoTiro)
            {
                ProximoTiro = Time.time + CadenciaDeTiro;
                //O Instantiate Cria objetos no caso a Bala da arma;
                Instantiate(Bala,ReferenciaBala.transform.position, ReferenciaBala.transform.rotation);
                MunicaoNoPente -= 1;
            }
        }
        else
        {
            if((Input.GetMouseButton(0)) && OutrasAcoes.EstaPausado == false && MunicaoNoPente > 0 && Time.time > ProximoTiro)
            {
                ProximoTiro = Time.time + CadenciaDeTiro;
                Instantiate(Bala,ReferenciaBala.transform.position, ReferenciaBala.transform.rotation);
                MunicaoNoPente -= 1;
            }
        }
    }
}
