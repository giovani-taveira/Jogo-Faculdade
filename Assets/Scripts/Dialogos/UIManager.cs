using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject UIContainer;
    public Image ImagemDoPersonagem;
    public TMP_Text NomePersonagem;
    public Text Dialogo;

    void Awake()
    {
        DialogManager.NewTalker += TrocaPersonagem;
        DialogManager.ShowMessage += MensagemExibida;
        DialogManager.ResetText += ResetText;
        DialogManager.UIState += UIContainerEstado;
    }

    void OnDestroy()
    {
        DialogManager.NewTalker -= TrocaPersonagem;
        DialogManager.ShowMessage -= MensagemExibida;
        DialogManager.ResetText -= ResetText;
        DialogManager.UIState -= UIContainerEstado;
    }

    private void MensagemExibida(string message) => Dialogo.text = message;
    private void ResetText() => Dialogo.text = string.Empty;
    private void UIContainerEstado(bool estado) => UIContainer.SetActive(estado);
    //Recebe as informacoes do script Dialog do persoagem que vai falar 
    private void TrocaPersonagem(Dialog TalkerInformations)
    {
        ImagemDoPersonagem.sprite = TalkerInformations.Talker.ImgemPersonagem;
        NomePersonagem.text = TalkerInformations.Talker.name;     
    }
}
