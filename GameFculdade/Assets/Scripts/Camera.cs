using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject jogador;
    private Vector3 cameraMovimento;
    
    //Movimento da câmera com o mouse
    //private bool travaMouse = true;
    //private float mouseX = 0.0f;
    //private float mouseY = 0.0f;
    //private float sensibiliddade = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        cameraMovimento = transform.position - jogador.transform.position;
        //if (!travaMouse)
        //{
        //    return;
        //}
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Movientação nos eixos X, Y e Z
        Vector3 posicao = new Vector3(jogador.transform.position.x , jogador.transform.position.y , jogador.transform.position.z);
        transform.position = posicao + cameraMovimento;
        //mouseX += Input.GetAxis("Mouse X") * sensibiliddade;
        //mouseY += Input.GetAxis("Mouse Y") * sensibiliddade;
        //transform.eulerAngles = new Vector3(mouseY, mouseX, 0);
    }
}
