using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderIntro : MonoBehaviour
{
    public Material colorGrade;
    public GameObject Behelith;
    private float timer = 0f;
    private bool transitioningToNegative = false;
    private bool returningToOriginal = false;
    private float returnStartTime;
    private float initialReturnValue;
    private Vector3 behelithStartPos;
    void Start()
    {
        colorGrade.SetFloat("_ADDController", 0.51f);
        behelithStartPos = Behelith.transform.position;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer <= 15f)
        {
            float progress = Mathf.Clamp01(timer / 15f);
            float height = Mathf.Lerp(0f, 3f, progress);
            Behelith.transform.position = behelithStartPos + new Vector3(0f, height, 0f);
        }

        if (timer >= 15f && !transitioningToNegative)
        {
            transitioningToNegative = true;
        }

       
        if (transitioningToNegative && timer < 32f)
        {
            
            float progress = (timer - 15f) / 1.5f; 
            float value = Mathf.Lerp(0.51f, -3f, Mathf.Clamp01(progress));
            colorGrade.SetFloat("_ADDController", value);
            Destroy(Behelith);
        }

        
        if (timer >= 32f && !returningToOriginal)
        {
            returningToOriginal = true;
            returnStartTime = Time.time;
            initialReturnValue = colorGrade.GetFloat("_ADDController");
        }

        
        if (returningToOriginal)
        {
            float lerpTime = 0.9f; // duración del retorno
            float elapsed = Time.time - returnStartTime;
            float t = Mathf.Clamp01(elapsed / lerpTime);
            float value = Mathf.Lerp(initialReturnValue, 0.51f, t);
            colorGrade.SetFloat("_ADDController", value);

            
            if (t >= 1f)
            {
                returningToOriginal = false;
            }
        }
    }
}
