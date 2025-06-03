using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using UnityEngine.SceneManagement;

public class MusicStarter : MonoBehaviour
{
    private EventInstance MusicaMenu;
    private int Escena;
    void Start()
    {
        Escena = SceneManager.GetActiveScene().buildIndex;
        if (Escena == 0)
        {
            MusicaMenu = AudioManager.instance.CreateInstance(FMODEvents.instance.music);
        }
        if (Escena == 1)
        {
            MusicaMenu = AudioManager.instance.CreateInstance(FMODEvents.instance.musicCombate);
            Debug.Log("musica");

        }
        if (Escena == 2)
        {
            MusicaMenu = AudioManager.instance.CreateInstance(FMODEvents.instance.musicaMuerte);
        }

        MusicaMenu.start();
    }

   
    private void OnDisable()
    {
        MusicaMenu.stop(STOP_MODE.ALLOWFADEOUT);
    }

    private void OnDestroy()
    {
        MusicaMenu.stop(STOP_MODE.ALLOWFADEOUT);
    }
}
