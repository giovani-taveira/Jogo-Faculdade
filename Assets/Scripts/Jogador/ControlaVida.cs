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
    public GameObject Kit;
    public Text Txt_Kit;
    public int ContadorKit;
    public bool TemKit;
 
    void Start()
    {
        Vida = 200; 
        barraVida.fillAmount = 1;
    }

    void Update()
    {
        Txt_Kit.text = ContadorKit.ToString();

        if(KitMedico.PegouKit == true)
        {
            ContadorKit += 1;   
            KitMedico.PegouKit = false;
        }
        if(ContadorKit > 0)
        {
            TemKit = true;
        }
        else
        {
            TemKit = false;
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            Kit.SetActive(true);
            animacao.SetInteger("Transition", 0);
            if(TemKit == true && Vida < VidaInicial)
            {
                ContadorKit -= 1;
                Vida += KitMedico.QuantidadeCura;
                KitMedico.PegouKit = false;
                if(Vida > VidaInicial)
                {
                    Vida = VidaInicial;
                }
            }
        }
        ControladorVida();

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
