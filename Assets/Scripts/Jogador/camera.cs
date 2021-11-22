using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class camera : MonoBehaviour
{
    public float velocidade;
    [Space(10)]
    public Vector3 offset = Vector3.up;
    Quaternion quaternion;
    public Transform player;
    [Space(15)]
    public float[] xClamp = new float[2];
    public float[] zClamp = new float[2];
    // public bool ApareceInteface = false;
    public GameObject InterfaceGameplay;
    public bool ComZoom;
    string CenaAtual;

    void Start()
    {
        ComZoom = false;

        offset.y = 30;
        offset.x = 16;
        offset.z = -2;
        velocidade = 2;
        InterfaceGameplay.SetActive(true);
        CenaAtual = SceneManager.GetActiveScene().name;

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
            Debug.Log("ENTREI NO IF5");
        }
        if(ControlaEventos.Zoom && !ComZoom)
        {
            offset.y = 30;
            offset.x = 16;
            offset.z = -2;
            velocidade = 2;
            ComZoom = true;
            ControlaEventos.Zoom = false;
            Debug.Log("ENTREI NO IF5");
        } 

        if(DialogManager.MenosZoom)
        {
            offset.y = 100;
            offset.x = 30;
            offset.z = -20;
            Debug.Log("ENTREI NO IF6");
            
        } 
        else if(CenaAtual == "Fase2-Floresta")
        {
            offset.y = 30;
            offset.x = 16;
            offset.z = -2;
            Debug.Log("ENTREI NO IF18");
        }    

        if(DialogManager.MenosZoom2 && CenaAtual == "CasaJeffrey2")
        {
            offset.y = 50;
            offset.x = 50;
            offset.z = -100;
            Debug.Log("ENTREI NO IF");
        }
        else if(CenaAtual == "CasaJeffrey2")
        {
            offset.y = 30;
            offset.x = 16;
            offset.z = -2;
            Debug.Log("ENTREI NO IF16");
        }

        if(CenaAtual == "CasaJeffrey3")
        {
            offset.y = 55;
            offset.x = 5;
            offset.z = -30;
            Debug.Log("ENTREI NO IF2");
        }

        if(DialogManager.MenosZoom3)
        {
            offset.y = 55;
            offset.x = -45;
            offset.z = -40;
            Debug.Log("ENTREI NO IF3");
        }
                
                
        if(DialogManager.MenosZoom4)
        {
            offset.y = 55;
            offset.x = 30;
            offset.z = -20;
            Debug.Log("ENTREI NO IF4");
            //Debug.Log("ENTREI NO IF");
        } 
        else if (CenaAtual == "CasaFrank2")
        {
            offset.y = 30;
            offset.x = 16;
            offset.z = -2;
            Debug.Log("ENTREI NO IF666");
        }  

        if(CenaAtual == "Cena-Milton")
        {
            offset.y = 55;
            offset.x = 8;
            offset.z = -20;
        }
    }
}
