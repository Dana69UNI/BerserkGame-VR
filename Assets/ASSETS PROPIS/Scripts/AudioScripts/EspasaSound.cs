using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EspasaSound : MonoBehaviour
{
    private EventInstance GolpeSuelo;
    private EventInstance GolpeEspada;
    // Start is called before the first frame update
    void Start()
    {
        GolpeSuelo = AudioManager.instance.CreateEventInstanceObj(FMODEvents.instance.espadaHitSuelo, gameObject.transform);
        GolpeEspada = AudioManager.instance.CreateEventInstanceObj(FMODEvents.instance.espadaHitMetal, gameObject.transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Suelo"))
        {
            GolpeSuelo.start();
        }

        if (collision.collider.CompareTag("Sword"))
        {
            GolpeEspada.start();
        }
    }
}
