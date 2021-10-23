using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class VidaInimigo : MonoBehaviour
{
    public static float vidaInimigo = 100;
    public static float vidaAtualInimigo = 100;
    public Image barraVidaInimigo;
    // Start is called before the first frame update
    void Start()
    {
        
        //barraVidaInimigo.fillAmount = 1;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 lookAtTarget = transform.position + Camera.main.transform.forward;
        transform.LookAt(lookAtTarget, Camera.main.transform.up);
    }

    void Update()
    {
        if(MovimentaBala.AcertouInimigo == true && vidaInimigo > 0)
        {
            vidaAtualInimigo -= 35;
            barraVidaInimigo.fillAmount -= 0.25f;
            MovimentaBala.AcertouInimigo = false;
        }
    }
}
