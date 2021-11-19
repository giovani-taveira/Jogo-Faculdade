using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public int NivelUpVida = 1, NivelUpStamina = 1, NivelUpArma = 1;
    int PrecoV1 = 150, PrecoV2 = 300, PrecoSt1 = 150, PrecoSt2 = 300;

    void Start()
    {
        
    }

 
    void Update()
    {
        
    }

    public void UpgradeVida()
    {
        if(NivelUpVida == 1 && Materiais.MateriaisAtuais >= PrecoV1)
        {
            ControlaVida.VidaInicial += 100;
            ControlaVida.Vida = ControlaVida.VidaInicial;
            Materiais.MateriaisAtuais -= PrecoV1;
            NivelUpVida += 1;
        }
        else if(NivelUpVida == 2 && Materiais.MateriaisAtuais >= PrecoV2)
        {
            ControlaVida.VidaInicial += 200;
            ControlaVida.Vida = ControlaVida.VidaInicial;
            Materiais.MateriaisAtuais -= PrecoV2;
            NivelUpVida += 1;
        }
    }

    public void UpgradeStamina()
    {
        if(NivelUpStamina == 1 && Materiais.MateriaisAtuais >= PrecoSt1)
        {
            Jogador.MaxStamina += 100;
            Materiais.MateriaisAtuais -= PrecoSt1;
            NivelUpStamina += 1;
        }
        else if(NivelUpStamina == 2 && Materiais.MateriaisAtuais >= PrecoSt2)
        {
            Jogador.MaxStamina += 200;
            Materiais.MateriaisAtuais -= PrecoSt2;
            NivelUpStamina += 1;
        }
    }
}
