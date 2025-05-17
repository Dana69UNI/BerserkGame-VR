using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonDying : MonoBehaviour
{
    public ConfigurableJoint CraniumJoint;
    public ConfigurableJoint TorsoJoint;
    public ConfigurableJoint PelvisJoint;
    public ConfigurableJoint StabilizerJoint;
    private IAEnemigo IAEnemigo;
    public Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        IAEnemigo = GetComponent<IAEnemigo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CraniumJoint == null)
        {
            Destroy(PelvisJoint);
            Destroy(StabilizerJoint);
            Destroy(IAEnemigo);
            Destroy(Animator);
        }
        if(TorsoJoint == null)
        {
            Destroy(PelvisJoint);
            Destroy(StabilizerJoint);
            Destroy(IAEnemigo);
            Destroy(Animator);
        }
    }
}
