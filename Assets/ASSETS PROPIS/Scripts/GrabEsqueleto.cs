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
            grab.enabled = false; 
    }

    void Update()
    {
        if (!grabEnabled && joint == null)
        {
            grab.enabled = true;
            grabEnabled = true;
            /*else if (!joint.connectedBody)
            {
                // Opcional: si el joint encara existeix però s'ha "trencat" (sense connexió)
                Destroy(joint); // Opcional: el treus i deixes que s'activi el grab a la propera iteració
            }*/ //aixo m'ho ha dit el chat ns jo crec que no cal
        }
    }
}
