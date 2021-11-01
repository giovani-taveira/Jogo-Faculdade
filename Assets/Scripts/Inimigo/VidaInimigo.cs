using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class VidaInimigo : MonoBehaviour
{
    public static int vidaInimigo = 100;
    public static int vidaAtualInimigo;
    public Image barraVidaInimigo;


    void Start()
    {
        vidaAtualInimigo = vidaInimigo;
        barraVidaInimigo.fillAmount = 1;
    }


    void LateUpdate()
    {
        Vector3 lookAtTarget = transform.position + Camera.main.transform.forward;
        transform.LookAt(lookAtTarget, Camera.main.transform.up);

        
    }

    void Update()
    {
        if(MovimentaBala.AcertouInimigo == true && vidaAtualInimigo > 0)
        {
            vidaAtualInimigo -= CaracteristicasArmas.DanoArma;
            barraVidaInimigo.fillAmount = (1/(float)vidaInimigo) * vidaAtualInimigo;
            // barraVidaInimigo.fillAmount -= 0.25f;
            MovimentaBala.AcertouInimigo = false;
        }

        //barraVidaInimigo.fillAmount = (1/vidaInimigo) * vidaAtualInimigo;
    }
}
