using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class FadeController : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;

    private void Awake()
    {
        if(fadeImage == null)
        {
            Debug.LogError("Fade Image is not assigned in the FadeController.");
        }

        else
        {
            //Ens assegurem que comenci sent transparent la imatge
            var c = fadeImage.color;
            c.a = 0f;
            fadeImage.color = c;
        }
    }

    //funció per començar el fade i quan acabi que carregui la DeathScene
    public void FadeToScene(string sceneName)
    {
        Debug.Log("Starting fade to scene: " + sceneName);
        StartCoroutine(FadeOutAndLoad("DeathScene"));
    }

    private IEnumerator FadeOutAndLoad(string sceneName)
    {
        Debug.Log("Fading out...");
        //passar de Alpha 0 a alpha 1
        float elpased = 0f;
        Color c = fadeImage.color;
        while (elpased < fadeDuration)
        {
            elpased += Time.deltaTime;
            float alpha = Mathf.Clamp01(elpased / fadeDuration);
            c.a = alpha;
            fadeImage.color = c;
            yield return null; //espera un frame
        }

        c.a = 1f; //Assegurem que al final estigui completament opac
        fadeImage.color = c;

        //carreguem l'escena DeathScene
        SceneManager.LoadScene("DeathScene");
    }
}
