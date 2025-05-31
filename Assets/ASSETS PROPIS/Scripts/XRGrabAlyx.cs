using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class XRGrabAlyx : XRGrabInteractable
{
    public float velocityThreshold = 2;

    private NearFarInteractor rayInteractor;
    private Vector3 previousPos;
    private Rigidbody interactableRigibody;

    protected override void Awake()
    {
        base.Awake();
        interactableRigibody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(isSelected && firstInteractorSelecting is NearFarInteractor)//calcular la velocitat del ray
        {
            Vector3 velocity = (rayInteractor.transform.position - previousPos) / Time.deltaTime;
            previousPos = rayInteractor.transform.position;

            if(velocity.magnitude > velocityThreshold)
            {
                Drop();
                interactableRigibody.velocity = Vector3.up;//aixo dps ho canviarem
            }
        }
    }
    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        
        if (args.interactorObject is NearFarInteractor)
        {
            trackPosition = false;
            trackRotation = false;
            throwOnDetach = false;

            rayInteractor = (NearFarInteractor)args.interactorObject;
            previousPos = rayInteractor.transform.position;
        }
        else
        {
            trackPosition = true;
            trackRotation = true;
            throwOnDetach = true;
        }
        base.OnSelectEntering(args);
    }


}
