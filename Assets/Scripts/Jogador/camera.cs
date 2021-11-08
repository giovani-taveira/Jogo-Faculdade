using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public float velocidade;
    [Space(10)]
    public Vector3 offset = Vector3.up;
    public Transform player;
    [Space(15)]
    public float[] xClamp = new float[2];
    public float[] zClamp = new float[2];
    public bool ApareceInteface = false;
    public GameObject InterfaceGameplay;

    void FixedUpdate()
    {
        Vector3 playerPos = player.position;
        float posX = Mathf.Clamp(playerPos.x, xClamp[0], xClamp[1]);
        float posZ = Mathf.Clamp(playerPos.z, zClamp[0], zClamp[1]);
        transform.position = Vector3.Lerp(transform.position, new Vector3(posX , 0, posZ) + offset, velocidade * Time.deltaTime);

        if(ApareceInteface == true)
        {
            InterfaceGameplay.SetActive(true);
        }
        else
        {
            InterfaceGameplay.SetActive(false);
        }

        if(posZ > -54 )
        {
            offset.y = 30;
            offset.x = 16;
            offset.z = -2;
            velocidade = 2;
            ApareceInteface = true;
            
        }
        if(posZ < -54 || posZ > 48 && posX > 61 && posZ < 170)
        {
            offset.y = 20;
            offset.x = 10;
            velocidade = 3;
            ApareceInteface = false;
        }
        if(posZ > 267 && posX < 16&& posX > -135.2 )
        {
            offset.y = 20;
            offset.x = 10;
            velocidade = 3;
            ApareceInteface = false;
        }
    }
}
