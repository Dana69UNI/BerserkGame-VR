//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class IAEnemigo : MonoBehaviour
//{

//    public int rutina;
//    public float cronometro;
//    public Animator ani;
//    public Quaternion angulo;
//    public float grado;


//    public GameObject target;
//    public bool atacando;


//    // Start is called before the first frame update
//    void Start()
//    {
//        ani = GetComponent<Animator>();
//        target = GameObject.Find("Player");
//    }

//    public void Comportamiento_Enemigo()
//    {
//        if (Vector3.Distance(transform.position, target.transform.position) > 5)
//        {
//            cronometro += 1 * Time.deltaTime;
//            if (cronometro >= 4)
//            {
//                rutina = Random.Range(0, 2);
//                cronometro = 0;
//            }
//            switch (rutina)
//            {
//                case 0:
//                    ani.SetBool("Caminar", false);
//                    break;

//                case 1:
//                    grado = Random.Range(0, 360);
//                    angulo = Quaternion.Euler(0, grado, 0);
//                    rutina++;
//                    break;

//                case 2:
//                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
//                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
//                    ani.SetBool("Caminar", true);
//                    break;

//            }
//        }
//        else
//        {
//            if(Vector3.Distance(transform.position, target.transform.position)>1 && !atacando)
//            {
//                var lookPos = target.transform.position = transform.position;
//                lookPos.y = 0;
//                var rotation = Quaternion.LookRotation(lookPos);
//                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
//                ani.SetBool("Caminar", true);
//                transform.Translate(Vector3.forward * 2 * Time.deltaTime);

//                ani.SetBool("Ataque", false);

//            }
//            else
//            {
//                ani.SetBool("Caminar", false);

//                ani.SetBool("Ataque", true);
//                atacando = true;


//            }

//        }




//    }

//    public void Final_Ani()
//    {
//        ani.SetBool("Ataque", false);
//        atacando = false;
//    }

//    void Update()
//    {
//        Comportamiento_Enemigo();
//    }
//}














//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class IAEnemigo : MonoBehaviour
//{
//    public int rutina;
//    public float cronometro;
//    public Animator ani;
//    public Quaternion angulo;
//    public float grado;
//    public float tiempoMovimiento;

//    void Start()
//    {
//        ani = GetComponent<Animator>();
//        cronometro = 0f;
//        rutina = 0;
//        tiempoMovimiento = 0f;
//    }

//    public void Comportamiento_Enemigo()
//    {
//        cronometro += Time.deltaTime;

//        switch (rutina)
//        {
//            case 0:
//                // Espera máximo 2 segundos
//                ani.SetBool("Caminar", false);
//                if (cronometro >= Random.Range(1f, 2f))
//                {
//                    rutina = 1;
//                    cronometro = 0;
//                }
//                break;

//            case 1:
//                // Elige nueva dirección aleatoria
//                grado = Random.Range(0, 360);
//                angulo = Quaternion.Euler(0, grado, 0);
//                rutina = 2;
//                tiempoMovimiento = Random.Range(2f, 4f); // Tiempo de movimiento antes de detenerse
//                break;

//            case 2:
//                // Se mueve en esa dirección
//                transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 100 * Time.deltaTime);
//                transform.Translate(Vector3.forward * 1 * Time.deltaTime);
//                ani.SetBool("Caminar", true);

//                if (cronometro >= tiempoMovimiento)
//                {
//                    rutina = 0;
//                    cronometro = 0;
//                }
//                break;
//        }
//    }

//    void Update()
//    {
//        Comportamiento_Enemigo();
//    }
//}










//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class IAEnemigo : MonoBehaviour
//{
//    public int rutina;
//    public float cronometro;
//    public Animator ani;
//    public Quaternion angulo;
//    public float grado;

//    public GameObject target;
//    public bool atacando;

//    void Start()
//    {
//        ani = GetComponent<Animator>();
//        // Apunta a la cámara principal (la cabeza del jugador en VR)
//        target = Camera.main.gameObject;
//    }

//    public void Comportamiento_Enemigo()
//    {
//        if (Vector3.Distance(transform.position, target.transform.position) > 5)
//        {
//            cronometro += 1 * Time.deltaTime;
//            if (cronometro >= 4)
//            {
//                rutina = Random.Range(0, 2);
//                cronometro = 0;
//            }
//            switch (rutina)
//            {
//                case 0:
//                    ani.SetBool("Caminar", false);
//                    break;

//                case 1:
//                    grado = Random.Range(0, 360);
//                    angulo = Quaternion.Euler(0, grado, 0);
//                    rutina++;
//                    break;

//                case 2:
//                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
//                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
//                    ani.SetBool("Caminar", true);
//                    break;
//            }
//        }
//        else
//        {
//            if (Vector3.Distance(transform.position, target.transform.position) > 1 && !atacando)
//            {
//                Vector3 lookPos = target.transform.position - transform.position;
//                lookPos.y = 0;
//                Quaternion rotation = Quaternion.LookRotation(lookPos);
//                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);

//                ani.SetBool("Caminar", true);
//                transform.Translate(Vector3.forward * 2 * Time.deltaTime);

//                ani.SetBool("Ataque", false);
//            }
//            else
//            {
//                ani.SetBool("Caminar", false);

//                ani.SetBool("Ataque", true);
//                atacando = true;
//            }
//        }
//    }

//    public void Final_Ani()
//    {
//        ani.SetBool("Ataque", false);
//        atacando = false;
//    }

//    void Update()
//    {
//        Comportamiento_Enemigo();
//    }
//}






//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class IAEnemigo : MonoBehaviour
//{
//    public int rutina;
//    public float cronometro;
//    public Animator ani;
//    public Quaternion angulo;
//    public float grado;
//    public float tiempoMovimiento;

//    public GameObject target;  // Target jugador
//    public bool atacando;      // Para controlar si está atacando

//    void Start()
//    {
//        ani = GetComponent<Animator>();
//        cronometro = 0f;
//        rutina = 0;
//        tiempoMovimiento = 0f;

//        // Asignamos la cámara principal como target (VR)
//        target = Camera.main.gameObject;
//    }

//    public void Comportamiento_Enemigo()
//    {
//        float distanciaJugador = Vector3.Distance(transform.position, target.transform.position);

//        // Si el jugador está lejos (>5m), patrulla
//        if (distanciaJugador > 5)
//        {
//            cronometro += Time.deltaTime;

//            switch (rutina)
//            {
//                case 0:
//                    ani.SetBool("Caminar", false);
//                    if (cronometro >= Random.Range(1f, 2f))
//                    {
//                        rutina = 1;
//                        cronometro = 0;
//                    }
//                    break;

//                case 1:
//                    grado = Random.Range(0, 360);
//                    angulo = Quaternion.Euler(0, grado, 0);
//                    rutina = 2;
//                    tiempoMovimiento = Random.Range(2f, 4f);
//                    cronometro = 0;
//                    break;

//                case 2:
//                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 100 * Time.deltaTime);
//                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
//                    ani.SetBool("Caminar", true);

//                    if (cronometro >= tiempoMovimiento)
//                    {
//                        rutina = 0;
//                        cronometro = 0;
//                    }
//                    break;
//            }

//            atacando = false;  // No está atacando mientras patrulla
//        }
//        else
//        {
//            // Si jugador está cerca (<=5m), persigue
//            if (distanciaJugador > 1)
//            {
//                Vector3 direccion = target.transform.position - transform.position;
//                direccion.y = 0; // Solo girar en el eje Y
//                Quaternion rotacion = Quaternion.LookRotation(direccion);
//                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacion, 200 * Time.deltaTime);

//                ani.SetBool("Caminar", true);
//                transform.Translate(Vector3.forward * 1.5f * Time.deltaTime);

//                ani.SetBool("Ataque", false);
//                atacando = false;
//            }
//            else
//            {
//                // Si está muy cerca (<=1m), atacar
//                ani.SetBool("Caminar", false);
//                ani.SetBool("Ataque", true);
//                atacando = true;
//            }
//        }
//    }

//    void Update()
//    {
//        Comportamiento_Enemigo();
//    }
//}












using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEnemigo : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;
    public float tiempoMovimiento;

    public GameObject target;
    public bool atacando;

    public float campoVision = 90f; // grados totales del campo de visión (45° a cada lado)

    void Start()
    {
        ani = GetComponent<Animator>();
        cronometro = 0f;
        rutina = 0;
        tiempoMovimiento = 0f;

        // Buscar jugador en la escena (ajusta el nombre al de tu XR Origin o jugador)
        target = Camera.main.gameObject;
    }

    public void Comportamiento_Enemigo()
    {
        Vector3 direccionJugador = target.transform.position - transform.position;
        direccionJugador.y = 0; // ignorar diferencia de altura

        float distanciaJugador = direccionJugador.magnitude;

        // Calcular ángulo entre el frente del enemigo y la dirección al jugador
        float anguloJugador = Vector3.Angle(transform.forward, direccionJugador.normalized);

        bool jugadorEnCampoVision = anguloJugador <= campoVision / 2f;

        if (distanciaJugador <= 5 && jugadorEnCampoVision)
        {
            // Jugador detectado en rango y campo de visión

            if (distanciaJugador > 1)
            {
                // Perseguir jugador
                Quaternion rotacion = Quaternion.LookRotation(direccionJugador);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacion, 200 * Time.deltaTime);

                ani.SetBool("Caminar", true);
                transform.Translate(Vector3.forward * 2 * Time.deltaTime);

                ani.SetBool("Ataque", false);
                atacando = false;
            }
            else
            {
                // Atacar jugador
                ani.SetBool("Caminar", false);
                ani.SetBool("Ataque", true);
                atacando = true;
            }
        }
        else
        {
            // Patrullar

            cronometro += Time.deltaTime;

            switch (rutina)
            {
                case 0:
                    ani.SetBool("Caminar", false);
                    if (cronometro >= Random.Range(1f, 2f))
                    {
                        rutina = 1;
                        cronometro = 0;
                    }
                    break;

                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina = 2;
                    tiempoMovimiento = Random.Range(2f, 4f);
                    cronometro = 0;
                    break;

                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 100 * Time.deltaTime);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    ani.SetBool("Caminar", true);

                    if (cronometro >= tiempoMovimiento)
                    {
                        rutina = 0;
                        cronometro = 0;
                    }
                    break;
            }

            ani.SetBool("Ataque", false);
            atacando = false;
        }
    }

    void Update()
    {
        Comportamiento_Enemigo();
    }
}
