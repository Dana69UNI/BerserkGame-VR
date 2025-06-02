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
        GolpeSuelo = AudioManager.instance.CreateInstance(FMODEvents.instance.espadaHitSuelo);
        GolpeEspada = AudioManager.instance.CreateInstance(FMODEvents.instance.espadaHitMetal);
    }

    // Update is called once per frame
    void Update()
    {
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(GolpeSuelo, GetComponent<Transform>(), GetComponent<Rigidbody>());
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(GolpeEspada, GetComponent<Transform>(), GetComponent<Rigidbody>());
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
