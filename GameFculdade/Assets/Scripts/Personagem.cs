using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{

    public float Velocidade = 10;
    //Movimentos do personagem
    //Rigidbody = corpo do objeto
    //public Rigidbody rb;
    //private float maxAltura = 5;
    //private float velocidade = 3;

    //Status Personagem -vida
    //public Image barraVida;
    //[Range(1,100)]
    //public float vida = 100;
    //public static float vidaAtual = 100;

    //Status Personagem -XP
    //public Text textoXP;
    //public Text textoXPFaltante;
    //public Text textoNivel;
    //private int xp = 0;
    //private int nivel;
    //private int xpNecessario;
    //private int xpPorNivel = 100;

    // Start is called before the first frame update



    void Start()
    {
       //Cria uma instância de Rigidbody
       //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(eixoX, 0, eixoZ);

        transform.Translate(direcao * Velocidade * Time.deltaTime);
    }

    //void MovimentaPersonagem()
    //{
    //    //GetAxis captura comandos daqs setas do teclado em um eixo
    //    //GetKey captura teclas epecíficas através do KeyCode
    //    float horizontal = Input.GetAxis("Horizontal"); 
    //    float vertical = Input.GetAxis("Vertical");
    //    float pulo = 0;

    //    if(Input.GetKey(KeyCode.Space) && (rb.position.y < maxAltura))
    //    {
    //        pulo = 2.5f;
    //    }

    //    //Atribuição de forças
    //    //Vector3 usado para aplicação de forças
    //    Vector3 forca = new Vector3(horizontal, pulo, vertical);
        
    //    if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d") || Input.GetKey(KeyCode.Space))
    //    {
    //        rb.AddForce(forca * velocidade);
    //    }
    //    else
    //    {
    //        rb.velocity = Vector3.zero;
    //    }
    //}
    //void ControladorVida()
    //{
    //    if(vida >= vidaAtual)
    //    {
    //        vida = vidaAtual;
    //    }
    //    else if(vida <= 0) 
    //    {
    //        vida = 0;
    //        Debug.Log("Morreu");
    //    }
    //} 

    //void AtualizaXP()
    //{
    //    xpNecessario = xpPorNivel * nivel;

    //    if(xp >= xpNecessario)
    //    {
    //        nivel = nivel + 1;
    //        xp = 0;
    //    }
        
    //    textoXP.text = "XP " + xp.ToString();
    //    textoXPFaltante.text = "Faltam " + xpNecessario.ToString() + " para o proximo nível";
    //    textoNivel.text = "Nível: " + nivel.ToString();
    //}   

    //void BarraVida()
    //{
    //    //Formula para diminuir ou aumentar a barra de vida
    //    barraVida.fillAmount = ((1 / vida) * vidaAtual);   
    //}
}
