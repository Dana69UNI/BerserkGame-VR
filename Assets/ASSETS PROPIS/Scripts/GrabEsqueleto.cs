using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GrabEsqueleto : MonoBehaviour
{
    private XRGrabInteractable grab;
    private EsqueletoHitSound EsqueletoSound;
    private ConfigurableJoint joint;
    private bool grabEnabled = false;
    private Damage dmg;

    void Start()
    {
        grab = GetComponent<XRGrabInteractable>();
        joint = GetComponent<ConfigurableJoint>();
        dmg = GetComponent<Damage>();

        if (grab != null)
            grab.enabled = false; 
    }

    void Update()
    {
        if (!grabEnabled && joint == null)
        {
            grab.enabled = true;
            grabEnabled = true;
            dmg.enabled = false;
            EsqueletoSound.StopRes();
            /*else if (!joint.connectedBody)
            {
                // Opcional: si el joint encara existeix per� s'ha "trencat" (sense connexi�)
                Destroy(joint); // Opcional: el treus i deixes que s'activi el grab a la propera iteraci�
            }*/ //aixo m'ho ha dit el chat ns jo crec que no cal
        }
    }
}
