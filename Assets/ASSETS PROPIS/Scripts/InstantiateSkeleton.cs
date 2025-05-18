using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSkeleton : MonoBehaviour
{
    public GameObject prefab;         // El prefab a instanciar
    public float spawnInterval = 10f; // Intervalo de tiempo en segundos
    public Transform spawnPoint;      // Punto donde se instanciará el prefab

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnPrefab();
            timer = 0f;
        }
    }

    void SpawnPrefab()
    {
        if (prefab != null)
        {
            Vector3 position = spawnPoint != null ? spawnPoint.position : transform.position;
            Quaternion rotation = spawnPoint != null ? spawnPoint.rotation : Quaternion.identity;

            Instantiate(prefab, position, rotation);
        }
        else
        {
            Debug.LogWarning("No se ha asignado el prefab.");
        }
    }
}
