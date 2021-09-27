using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject jogador;
    private Vector3 cameraMovimento;
    // Start is called before the first frame update
    void Start()
    {
        cameraMovimento = transform.position - jogador.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posicao = new Vector3(jogador.transform.position.x , jogador.transform.position.y , jogador.transform.position.z);
        transform.position = posicao + cameraMovimento;
    }
}
