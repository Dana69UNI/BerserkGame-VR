using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;


public class HapticInteractable : MonoBehaviour
{
    [Range(0, 1)]
    public float hapticIntensity = 0.5f;
    public float hapticDuration = 0.1f;

    //Tag que han de portar els esquelets
    public string targetTag = "Skeleton";

    private XRBaseController _holdingController = null;
    private XRGrabInteractable _grabInteractable;

    // Start is called before the first frame update  
    void Awake()
    {
        _grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void OnEnable()
    {
        //Quan alg� agafi l'arma guardem el seu XRBaseCOntroller
        _grabInteractable.selectEntered.AddListener(OnGrabbed);

        //Quan deixin anar l'arma, esborrem aquesta refer�ncia
        _grabInteractable.selectExited.AddListener(OnReleased);
    }

    void OnDisable()
    {
        _grabInteractable.selectEntered.RemoveListener(OnGrabbed);
        _grabInteractable.selectExited.RemoveListener(OnReleased);
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        if (args.interactorObject is XRBaseInputInteractor controllerInteractor)
        {
            _holdingController = controllerInteractor.xrController;
        }
        else
        {
            Debug.LogWarning("Interactor is not a controller-based interactor.");
        }
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        _holdingController = null;
    }

    //Per a que funcioni la resposta h�ptica tant si fem servir trigger o collisions
    private void OnCollisionEnter(Collision collision)
    {
        TrySendHaptic(collision.collider);
    }

    private void OnTriggerEnter(Collider other)
    {
        TrySendHaptic(other);
    }

    private void TrySendHaptic(Collider hitColider)
    {
        //Si el collider t� el tag correcte
        if (_holdingController == null)
        {
            //No hi ha ning� agafant l'objecte
            Debug.LogWarning("No controller is holding the interactable.");
            return;
        }

        if (hitColider.CompareTag(targetTag))
        {
            //Si el tag del collider �s el correcte
            Debug.Log("Sending haptic feedback to controller: " + _holdingController.name);
            _holdingController.SendHapticImpulse(hapticIntensity, hapticDuration);
        }
        else
        {
            Debug.Log("Collider does not have the correct tag: " + hitColider.tag);
        }
    }

    //public void TriggerHaptic(BaseInteractionEventArgs eventArgs)
    //{
    //    if (eventArgs.interactorObject is UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInputInteractor inputInteractor)
    //    {
    //        TriggerHaptic(inputInteractor.xrController);
    //    }
    //}

    //public void TriggerHaptic(XRBaseController controller)
    //{
    //    if(intensity>0)
    //    {
    //        controller.SendHapticImpulse(intensity, duration);
    //    }
    //}

}
