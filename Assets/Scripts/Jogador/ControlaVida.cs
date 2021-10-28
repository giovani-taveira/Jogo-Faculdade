using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ControlaVida : MonoBehaviour
{
    public static int VidaInicial = 400;
    public static int Vida;
    public Image barraVida;
    public GameObject InterfaceMorte;
    public Text Txt_Vida;
    public Animator animacao;
 
    void Start()
    {
        Vida = VidaInicial; 
        barraVida.fillAmount = 1;
    }

    void Update()
    {
        ControladorVida();
        if(KitMedico.PegouKit == true && Vida < VidaInicial)
        {
            Vida += 30;
            KitMedico.PegouKit = false;
            if(Vida > VidaInicial)
            {
                Vida = VidaInicial;
            }
        }
        Txt_Vida.text = $"{Vida} / {VidaInicial}";
        barraVida.fillAmount = (1/(float)VidaInicial) * Vida;
    }

    void OnCollisionEnter(Collision colisor)
    {
        if(colisor.gameObject.tag == "Inimigo")
        {
            animacao.SetInteger("Transition", 4);
            Vida -= 10;
        }
    }

    void ControladorVida()
    {
        if(Vida <= 0) 
        {
            Vida = 0;
            Time.timeScale = 0;
            InterfaceMorte.SetActive(true); 
        }
    } 
}
