using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;
    public static event System.Action<Dialog> NewTalker;
    public static event System.Action ResetText;
    public static event System.Action<string> ShowMessage;
    public static event System.Action<bool> UIState;
    private DialogContainer CurrentDialog;
    private bool EndCurrentTalk = true, ButtonClicked = false, AtivarBotao;
    public Animator anim, anim2, anim3, anim4;
    public static bool MenosZoom = false, MenosZoom2 = false, MenosZoom3 = false, MenosZoom4 = false, MenosZoom5=false, TerminouDialogo = true;
    public static bool AtivaTutorial = false;
    
    public Image BotaoNext;
    int d = 0;
    string CenaAtual; 
    SceneLoader sceneLoader = new SceneLoader();


    void Awake()
    {
        Instance = this;
        CenaAtual = SceneManager.GetActiveScene().name;
        PlayerShoot.PodeAtirar = true;
    }

    void Update()
    {
        if(CenaAtual == "Casa-Frank")
            DialogoCasaFrank1();

        if(CenaAtual == "CasaFrank2")
            DialogoCasaFrank2();
        
        if(CenaAtual == "CasaJeffrey1")
            DialogoCasaJeffrey1();

        if(CenaAtual == "CasaJeffrey2")
        {
            DialogoCasaJeffrey2();
        }

        if(CenaAtual == "CasaJeffrey3")
            DialogoCasaJeffrey3();
            

        if(CenaAtual == "Fase2-Floresta")
            DialogoFloresta();

        if(!EndCurrentTalk)
        {
            PlayerShoot.PodeAtirar = false;
            Jogador.PodeMovimentar = false;
        }

        if(EndCurrentTalk)
        {
            PlayerShoot.PodeAtirar = true;
            Jogador.PodeMovimentar = true;
        }   
    }

    public IEnumerator AtivaBotao(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        BotaoNext.enabled = true;
        StopCoroutine(AtivaBotao(0f));

    }
    public void StartConversation(DialogContainer container)
    {
        ControlaEventos.DesativaText = true;
        CurrentDialog = container;
        StartCoroutine(StartDialogue());
        UIState?.Invoke(true);
    }

    private IEnumerator StartDialogue()
    {  
        for(int i = 0; i < CurrentDialog.Dialogos.Length; i++)
        {
            ResetText?.Invoke();
            NewTalker?.Invoke(CurrentDialog.Dialogos[i]);
            StartCoroutine(ShowDialog(CurrentDialog.Dialogos[i].Dialogo));
        
            //espera o EndCurrentTalk se tornar verdadeiro para poder trocar de personagem
            yield return new WaitUntil(() => EndCurrentTalk);
        }
        UIState?.Invoke(false);
    }

    private IEnumerator ShowDialog(string[] messages)
    {
        EndCurrentTalk = false;

        foreach(var message in messages)
        {
            ShowAllMessage(message);
            yield return new WaitUntil(() => ButtonClicked);
            
            d++;
        }
        EndCurrentTalk = true;
    }

    //gerencia a exibição dos dialogos
    private void ShowAllMessage(string message)
    {
        ShowMessage?.Invoke(message);
        ButtonClicked = false;
    }
    public void ButtonWasClicked() => ButtonClicked = true;

    public void ResetaPosicao()
    {
        PlayerPrefs.DeleteKey("PosX");
        PlayerPrefs.DeleteKey("PosY");
        PlayerPrefs.DeleteKey("PosZ");
        
    }

    void DialogoCasaFrank2()
    {
        if(d == 2  && TerminouDialogo == true  && CenaAtual == "CasaFrank2")
        {
            anim.SetInteger("trigger", 1);
            BotaoNext.enabled = false;
            StartCoroutine(AtivaBotao(2.5f));
            var cena = PlayerPrefs.GetString("Cena");
            Debug.Log(cena);
        }

        if(d == 10  && TerminouDialogo == true  && CenaAtual == "CasaFrank2")
        {
            MenosZoom4 = true;
            anim.SetInteger("trigger", 2);
            anim2.SetInteger("trigger", 1);
            anim3.SetInteger("trigger", 1);
            anim4.SetInteger("trigger", 1);
            BotaoNext.enabled = false;
            StartCoroutine(AtivaBotao(7f));
        }

        if(d == 11  && TerminouDialogo == true  && CenaAtual == "CasaFrank2")
        {
            anim.SetInteger("trigger", 3);
            MenosZoom4 = false;
        }

        if(d == 26  && TerminouDialogo == true  && CenaAtual == "CasaFrank2")
        {
            ResetaPosicao();
            SceneLoader.Instance.LoadSceneAsync("Fase2-Floresta");
        }
    }

    void DialogoCasaFrank1()
    {
        if(d == 15 && TerminouDialogo == true  && CenaAtual == "Casa-Frank")
        {
            ResetaPosicao();
            //SceneLoader.Instance.LoadSceneAsync("CasaJeffrey3");
            //TerminouDialogo = false;
            SceneManager.LoadScene("CasaJeffrey3");
        }
    }

    void DialogoCasaJeffrey1()
    {
        if(d == 9 && TerminouDialogo == true  && CenaAtual == "CasaJeffrey1")
        {
            ResetaPosicao();
            CenaAtual = "CasaJeffrey2";
            //SceneLoader.Instance.LoadSceneAsync("CasaJeffrey2");
            SceneManager.LoadScene("CasaJeffrey2");
            
            //TerminouDialogo = false;
        }
    }

    void DialogoCasaJeffrey2()
    {  
        if(d == 1  && TerminouDialogo == true )
        {
            //Debug.Log("Entrei no IF");
            MenosZoom2 = true;
            BotaoNext.enabled = false;
            anim.SetInteger("trigger", 1);
            anim2.SetInteger("trigger", 1);
            anim3.SetInteger("trigger", 1);

            StartCoroutine(AtivaBotao(8f));
        }
        if(d == 2  && TerminouDialogo == true  && CenaAtual == "CasaJeffrey2")
        {
            ResetaPosicao();
            //SceneLoader.Instance.LoadSceneAsync("Casa-Frank");
            SceneManager.LoadScene("Casa-Frank");
            MenosZoom2 = false;
        }
    }

    void DialogoCasaJeffrey3()
    {
        if(d == 3 && TerminouDialogo == true)
        {
            AtivaTutorial = true;
            MenosZoom3 = false;
        } 

        if(d == 1 && TerminouDialogo == true)
        {
            MenosZoom3 = true;
            BotaoNext.enabled = false;
            anim.SetInteger("trigger", 1);

            StartCoroutine(AtivaBotao(5f));
        }
    } 

    void DialogoFloresta()
    {
        Debug.Log("TEstee");
        if(d == 3  && TerminouDialogo == true  && CenaAtual == "Fase2-Floresta")
        {
            Debug.Log("TEstee222");
            ResetaPosicao();
            //SceneLoader.Instance.LoadSceneAsync("Cena-Milton");
            SceneManager.LoadScene("Cena-Milton");
            TerminouDialogo = false;
        }
    }
}
