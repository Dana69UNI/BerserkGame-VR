using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
public class EsqueletoHitSound : MonoBehaviour
{
    private EventInstance GolpeSueloEsqueleto;
    private EventInstance GolpeEspadaEsqueleto;
    private EventInstance EsqueletoRes;
    public bool Cabeza= false;
    // Start is called before the first frame update
    void Awake()
    {
        GolpeSueloEsqueleto = AudioManager.instance.CreateEventInstanceObj(FMODEvents.instance.espadaHitSuelo, gameObject.transform);
        GolpeEspadaEsqueleto = AudioManager.instance.CreateEventInstanceObj(FMODEvents.instance.esqueletoGolpe, gameObject.transform);
        EsqueletoRes = AudioManager.instance.CreateEventInstanceObj(FMODEvents.instance.esqueletoCaminando, gameObject.transform);
        if(Cabeza)
        {
            EsqueletoRes.start();
            Debug.Log("empece");
        }
    }

    public void StopRes()
    {
        EsqueletoRes.stop(STOP_MODE.ALLOWFADEOUT);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Suelo"))
        {
            GolpeSueloEsqueleto.start();
        }

        if (collision.collider.CompareTag("Espada"))
        {
            GolpeEspadaEsqueleto.start();
        }
    }

    private void OnDisable()
    {
        EsqueletoRes.stop(STOP_MODE.ALLOWFADEOUT);
    }

    private void OnDestroy()
    {
        EsqueletoRes.stop(STOP_MODE.ALLOWFADEOUT);
    }
}
