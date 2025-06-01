using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Attachment;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ChangeGrabByDistance : MonoBehaviour
{
    public float switchRange = 2.0f;

    private GameObject XRorigin;
    private XRGrabInteractable grabInteractable;
    private XRGrabAlyx grabAlyx;

    private bool usingAlyxGrab = true;

    void Start()
    {
        XRorigin = GameObject.FindGameObjectWithTag("Player");
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabAlyx = GetComponent<XRGrabAlyx>();
        if (grabInteractable != null)
            grabInteractable.enabled = false; // per si de cas deixar desactivat el grabInteractable per aqui
    }

    void Update()
    {
        float distance = Vector3.Distance(XRorigin.transform.position, transform.position);
        if (distance < switchRange && usingAlyxGrab)
        {
            ChangeToInteractable();
        }
        else if (distance >= switchRange && !usingAlyxGrab)
        {
            ChangeToAlyx();
        }
    }

    private void ChangeToInteractable()
    {
        var alyx = GetComponent<XRGrabAlyx>();
        if (alyx != null)
        {
            Destroy(alyx); // perque es pugui posar el interactable
        }

        if (GetComponent<XRGrabInteractable>() == null)
        {
            var grab = gameObject.AddComponent<XRGrabInteractable>();
            grab.farAttachMode = InteractableFarAttachMode.Near;
        }

        usingAlyxGrab = false;
        Debug.Log("Canviat a Interactable");
    }

    private void ChangeToAlyx()
    {
        var interactable = GetComponent<XRGrabInteractable>();
        if (interactable != null)
        {
            Destroy(interactable); // perque es pugui posar el alyx
        }
        if (GetComponent<XRGrabAlyx>() == null)
        {
            gameObject.AddComponent<XRGrabAlyx>();
        }

        usingAlyxGrab = true;
        Debug.Log("Canviat a Alyx Grab");
    }

    /*void OnDrawGizmosSelected()
    {
        // Si estem en selecció, dibuixem una wire sphere de color verd
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, switchRange);
    }*/
}
