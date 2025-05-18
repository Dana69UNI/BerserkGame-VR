using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonDying : MonoBehaviour
{
    public ConfigurableJoint CraniumJoint;
    public ConfigurableJoint TorsoJoint;
    public ConfigurableJoint PelvisJoint;
    public ConfigurableJoint StabilizerJoint;
    public ConfigurableJoint Arma;

    private IAEnemigo IAEnemigo;
    public Animator Animator;
    private float deathTime = 0f;
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
            Destroy(Arma);
            StartCoroutine(Fade());
        }
        if(TorsoJoint == null)
        {
            Destroy(PelvisJoint);
            Destroy(StabilizerJoint);
            Destroy(Arma);
            Destroy(IAEnemigo);
            Destroy(Animator);
            StartCoroutine(Fade());
        }
    }

    IEnumerator Fade()
    {
       if(deathTime < 60f)
        {
            deathTime += Time.deltaTime;
            yield return null;
        }
       else
        {
            Destroy(gameObject);
        }
    }
}
