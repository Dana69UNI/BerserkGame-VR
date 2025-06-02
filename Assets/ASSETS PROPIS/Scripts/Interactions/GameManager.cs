using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public FadeController fadeController;

    void Awake()
    {
        // Singleton básico
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToGameOver()
    {
        if(fadeController!=null)
        {
            fadeController.FadeToScene("DeathScene");
        }
        else
        {
            Debug.LogError("FadeController is not assigned in GameManager.");
            SceneManager.LoadScene("DeathScene");
        }
        
    }
}
