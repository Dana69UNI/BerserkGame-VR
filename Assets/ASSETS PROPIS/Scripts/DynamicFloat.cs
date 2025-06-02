using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DynamicFloat : MonoBehaviour
{
    public float floatHeight = 0.4f; // Altura de la espada respecto al suelo
    public float floatForce = 35.0f; // Intensidad de la oscilación
    public float damping = 0.6f; // Amortiguación
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void FixedUpdate()
    {
        // Calcula la diferencia entre la altura objetivo y la posición actual
        float displacement = floatHeight - transform.position.y;

        // Calcula la velocidad vertical actual
        float verticalVelocity = rb.velocity.y;

        // Fuerza restauradora (como un muelle)
        float restoringForce = displacement * floatForce;

        // Fuerza de amortiguamiento para evitar oscilaciones infinitas
        float dampingForce = -verticalVelocity * damping;

        // Aplica la suma de ambas fuerzas
        rb.AddForce(new Vector3(0f, restoringForce + dampingForce, 0f));
    }
}

