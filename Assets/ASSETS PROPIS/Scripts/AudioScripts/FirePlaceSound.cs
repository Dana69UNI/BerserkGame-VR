using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using UnityEngine.SceneManagement;

public class FirePlaceSound : MonoBehaviour
{
    private EventInstance Fireplace;
    void Start()
    {
        Fireplace = AudioManager.instance.CreateEventInstanceObj(FMODEvents.instance.fuegoCamp, gameObject.transform);
        Fireplace.start();
    }


    private void OnDisable()
    {
        Fireplace.stop(STOP_MODE.ALLOWFADEOUT);
    }

    private void OnDestroy()
    {
        Fireplace.stop(STOP_MODE.ALLOWFADEOUT);
    }
}
