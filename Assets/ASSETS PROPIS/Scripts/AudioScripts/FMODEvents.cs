using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{

    [field: Header("Music")]
    [field: SerializeField] public EventReference music { get; private set; }
    [field: SerializeField] public EventReference musicaMuerte { get; private set; }

    [field: Header("Player SFX")]
    [field: SerializeField] public EventReference playerHit { get; private set; }

    [field: Header("Esqueletillos SFX")]
    [field: SerializeField] public EventReference esqueletoCaminando { get; private set; }

    [field: SerializeField] public EventReference esqueletoGolpe { get; private set; }

    [field: Header("Metalicos SFX")]
    [field: SerializeField] public EventReference espadaHitMetal { get; private set; }
    [field: SerializeField] public EventReference espadaHitSuelo { get; private set; }

    [field: SerializeField] public EventReference espadaHitEsqueleto { get; private set; }

    public static FMODEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one FMOD Events instance in the scene.");
        }
        instance = this;
    }
}