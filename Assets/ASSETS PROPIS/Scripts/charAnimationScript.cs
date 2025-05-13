using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class charAnimationScript : MonoBehaviour
{
    public Transform target;
    public ConfigurableJoint joint;

    private Quaternion startingRotation;

    private void Start()
    {
        startingRotation = transform.rotation;
    }

    private void Update()
    {
        joint.SetTargetRotationLocal(target.rotation, startingRotation);
    }
}
