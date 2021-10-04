using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    //public GameObject jogador;
    public float velocidade;
    //private Vector3 cameraMovimento;
    [Space(10)]
    public Vector3 offset = Vector3.up;
    public Transform player;
    [Space(15)]
    public float[] xClamp = new float[2];
    public float[] zClamp = new float[2];
    //public float[] yClamp = new float[2];
   // void Start()
    //{
        //cameraMovimento = transform.position - jogador.transform.position;
    //}

    void FixedUpdate()
    {
        Vector3 playerPos = player.position;
        //Vector3 posicao = new Vector3(jogador.transform.position.x , jogador.transform.position.y , jogador.transform.position.z);
        //transform.position = posicao + cameraMovimento;

        float posX = Mathf.Clamp(playerPos.x, xClamp[0], xClamp[1]);
        float posZ = Mathf.Clamp(playerPos.z, zClamp[0], zClamp[1]);

        transform.position = Vector3.Lerp(transform.position, new Vector3(posX , 0, posZ) + offset, velocidade * Time.deltaTime);

        if(posZ > -54 )
        {
            offset.y = 30;
            offset.x = 16;
            offset.z = -2;
            velocidade = 2;
        }
        if(posZ < -54 || posZ > 48 && posX > 61 && posZ < 170)
        {
            offset.y = 20;
            offset.x = 10;
            velocidade = 3;
        }
    }
}
