using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSkeleton : MonoBehaviour
{
    public GameObject prefab;         
    public float spawnInterval = 10f;
   

    [field: Header("SpawnPoint")]
    [field: SerializeField] public Transform spawnPoint1 { get; private set; }
    [field: Header("SpawnPoint")]
    [field: SerializeField] public Transform spawnPoint2 { get; private set; }
    [field: Header("SpawnPoint")]
    [field: SerializeField] public Transform spawnPoint3 { get; private set; }
    [field: Header("SpawnPoint")]
    [field: SerializeField] public Transform spawnPoint4 { get; private set; }
    [field: Header("SpawnPoint")]
    [field: SerializeField] public Transform spawnPoint5 { get; private set; }
    [field: Header("SpawnPoint")]
    [field: SerializeField] public Transform spawnPoint6 { get; private set; }

    private Transform[] spawnPoints;

    private int selectedSpawn;

    private float timer;
    private void Start()
    {
        spawnPoints = new Transform[] { spawnPoint1, spawnPoint2, spawnPoint3, spawnPoint4, spawnPoint5, spawnPoint6 };
    }
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
            selectedSpawn = UnityEngine.Random.Range(0, 6);

            Instantiate(prefab, spawnPoints[selectedSpawn]);
        }
        else
        {
            Debug.LogWarning("No se ha asignado el prefab.");
        }
    }
}
