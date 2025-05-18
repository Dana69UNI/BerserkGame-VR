using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GrabEsqueleto : MonoBehaviour
{
    private XRGrabInteractable grab;
    private ConfigurableJoint joint;
    private bool grabEnabled = false;

    void Start()
    {
        grab = GetComponent<XRGrabInteractable>();
        joint = GetComponent<ConfigurableJoint>();

        if (grab != null)
            grab.enabled = false; // Ens assegurem que comenci desactivat
    }

    void Update()
    {
        if (!grabEnabled)
        {
            if (joint == null)
            {
                // Potser s'ha destru�t a runtime
                grab = GetComponent<XRGrabInteractable>();
                if (grab != null)
                {
                    grab.enabled = true;
                    grabEnabled = true;
                }
            }
            else if (!joint.connectedBody)
            {
                // Opcional: si el joint encara existeix per� s'ha "trencat" (sense connexi�)
                Destroy(joint); // Opcional: el treus i deixes que s'activi el grab a la propera iteraci�
            }
        }
    }
}
