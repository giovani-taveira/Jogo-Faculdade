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
    // public bool ApareceInteface = false;
    public GameObject InterfaceGameplay;
    public bool ComZoom;

    void Start()
    {
        ComZoom = false;

        offset.y = 30;
        offset.x = 16;
        offset.z = -2;
        velocidade = 2;
        InterfaceGameplay.SetActive(true);

    }
    void FixedUpdate()
    {
        Vector3 playerPos = player.position;
        float posX = Mathf.Clamp(playerPos.x, xClamp[0], xClamp[1]);
        float posZ = Mathf.Clamp(playerPos.z, zClamp[0], zClamp[1]);
        transform.position = Vector3.Lerp(transform.position, new Vector3(posX , 0, posZ) + offset, velocidade * Time.deltaTime);

        ControlaZoom();
    }

    void ControlaZoom()
    {
        if(ControlaEventos.Zoom && ComZoom)
        {
            offset.y = 20;
            offset.x = 10;
            velocidade = 3;
            ComZoom = false;
            ControlaEventos.Zoom = false;
        }
        if(ControlaEventos.Zoom && !ComZoom)
        {
            offset.y = 30;
            offset.x = 16;
            offset.z = -2;
            velocidade = 2;
            ComZoom = true;
            ControlaEventos.Zoom = false;
        } 

        if(DialogManager.MenosZoom)
        {
            offset.y = 55;
            offset.x = 30;
            offset.z = -20;
        }  
    }
}
