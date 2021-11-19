using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private CanvasGroup LoadingOverlay;
    [SerializeField] Canvas CanvasLoading;
    [Range(0.01f, 3f)]
    [SerializeField] private float FadeTime = 0.5f;
    
    public static SceneLoader Instance{get; private set;}
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadSceneAsync(string sceneName)
    {
        //corrotina função que pode ser executada ao longo de varias frames
        StartCoroutine(PerfomeLoadSeneAsync(sceneName));
        CanvasLoading.sortingOrder = 100;
    }

    private IEnumerator PerfomeLoadSeneAsync(string sceneName)
    { 
        yield return StartCoroutine(FadeIn());

        var operation = SceneManager.LoadSceneAsync(sceneName);
        while(operation.isDone == false)
        {
            yield return null;
        }

        yield return StartCoroutine(FadeOut());
    }

    private IEnumerator FadeIn()
    {
        float start = 0;
        float end = 1;
        float speed = (end - start) / FadeTime;

        LoadingOverlay .alpha = start;
        while(LoadingOverlay.alpha < end)
        {
            LoadingOverlay.alpha += speed * Time.deltaTime;
            yield return null;
        }

        LoadingOverlay .alpha = end;
    }

    private IEnumerator FadeOut()
    {
        float start = 1;
        float end = 0;
        float speed = (end - start) / FadeTime;

        LoadingOverlay .alpha = start;
        while(LoadingOverlay.alpha > end)
        {
            LoadingOverlay.alpha += speed * Time.deltaTime;
            yield return null;
        }
        LoadingOverlay .alpha = end;
        CanvasLoading.sortingOrder = 0;
    }
}
