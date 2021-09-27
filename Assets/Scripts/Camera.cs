using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject jogador;
    private Vector3 cameraMovimento;

    void Start()
    {
        cameraMovimento = transform.position - jogador.transform.position;
    }

    void Update()
    {
        Vector3 posicao = new Vector3(jogador.transform.position.x , jogador.transform.position.y , jogador.transform.position.z);
        transform.position = posicao + cameraMovimento;
    }
}
