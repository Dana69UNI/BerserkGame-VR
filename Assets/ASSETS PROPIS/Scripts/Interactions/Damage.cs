using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int swordSpeed;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        swordSpeed=Random.Range(1, 10);
        rb=GetComponent<Rigidbody>();
        rb.velocity=transform.right * swordSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Le ha dado");

        if (other.CompareTag("Player"))
        {
            var health = other.GetComponent<Health>();
            if (health != null) health.TakeDamage(1);
        }

        // Empalmar el objeto a lo que colisiona (si no es la espada)
        //if (!other.CompareTag("Sword"))
        //{
        //    transform.SetParent(other.transform);
        //    Destroy(rb);
        //    GetComponent<Collider>().enabled = false;
        //}
    }
}
