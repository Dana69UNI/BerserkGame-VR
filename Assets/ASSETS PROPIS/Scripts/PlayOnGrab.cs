using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class PlayOnGrab : XRGrabInteractable
{
    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        base.OnSelectEntering(args);
        //canvi d'escena (ns si directament aqui o fer una funcio fora del override)
        //Anastasia fes el que vulguis o ho poses aqu� o a la funci� que t'he posat aqu� abaix! 

        CanviEscena();
    }

    private void CanviEscena()
    {
        //crec que es millor que ho posis aqui, sembla mes ordenat
        Debug.Log("Canvi d'escena!");
    }
}
