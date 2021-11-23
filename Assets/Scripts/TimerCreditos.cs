using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerCreditos : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Timer(50f));
    }

    void Update()
    {
        
    }

    public IEnumerator Timer(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        SceneManager.LoadScene("MenuPrincipal");
        StopCoroutine(Timer(0f));
    }
}
