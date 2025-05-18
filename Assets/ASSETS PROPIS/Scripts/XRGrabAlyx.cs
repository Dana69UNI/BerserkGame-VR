using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class XRGrabAlyx : XRGrabInteractable
{
    public float velocityThreshold = 2;

    private XRRayInteractor rayInteractor;
    private Vector3 previousPos;
    private Rigidbody interactableRigibody;

    protected override void Awake()
    {
        base.Awake();
        interactableRigibody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(isSelected && firstInteractorSelecting is XRRayInteractor)
        {
            Vector3 velocity = (rayInteractor.transform.position - previousPos) / Time.deltaTime;
            previousPos = rayInteractor.transform.position;

            if(velocity.magnitude > velocityThreshold)
            {
                Drop();//
                interactableRigibody.velocity = Vector3.up;
            }
        }    
    }
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if(args.interactableObject is XRRayInteractor)
        {
            trackPosition = false;
            trackPosition = false;
            trackPosition = false;

            rayInteractor = (XRRayInteractor)args.interactableObject;
            previousPos = rayInteractor.transform.position;
        }
        else
        {
            trackPosition = true;
            trackPosition = true;
            trackPosition = true;
        }
        base.OnSelectEntered(args);
    }


}
