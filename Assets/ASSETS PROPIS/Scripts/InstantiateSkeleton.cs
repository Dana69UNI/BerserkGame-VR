//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class InstantiateSkeleton : MonoBehaviour
//{
//    public GameObject prefab;         
//    public float spawnInterval = 10f;


//    [field: Header("SpawnPoint")]
//    [field: SerializeField] public Transform spawnPoint1 { get; private set; }
//    [field: Header("SpawnPoint")]
//    [field: SerializeField] public Transform spawnPoint2 { get; private set; }
//    [field: Header("SpawnPoint")]
//    [field: SerializeField] public Transform spawnPoint3 { get; private set; }
//    [field: Header("SpawnPoint")]
//    [field: SerializeField] public Transform spawnPoint4 { get; private set; }
//    [field: Header("SpawnPoint")]
//    [field: SerializeField] public Transform spawnPoint5 { get; private set; }
//    [field: Header("SpawnPoint")]
//    [field: SerializeField] public Transform spawnPoint6 { get; private set; }

//    private Transform[] spawnPoints;

//    private int selectedSpawn;

//    private float timer;
//    private void Start()
//    {
//        spawnPoints = new Transform[] { spawnPoint1, spawnPoint2, spawnPoint3, spawnPoint4, spawnPoint5, spawnPoint6 };
//    }
//    void Update()
//    {
//        timer += Time.deltaTime;

//        if (timer >= spawnInterval)
//        {
//            SpawnPrefab();
//            timer = 0f;
//        }
//    }

//    void SpawnPrefab()
//    {
//        if (prefab != null)
//        {
//            selectedSpawn = UnityEngine.Random.Range(0, 6);

//            Instantiate(prefab, spawnPoints[selectedSpawn]);
//        }
//        else
//        {
//            Debug.LogWarning("No se ha asignado el prefab.");
//        }
//    }
//}











//using System.Collections.Generic;
//using System.Collections;
//using UnityEngine;

//public class InstantiateSkeleton : MonoBehaviour
//{
//    public GameObject prefab;

//    [field: Header("SpawnPoint")]
//    [field: SerializeField] public Transform spawnPoint1 { get; private set; }
//    [field: Header("SpawnPoint")]
//    [field: SerializeField] public Transform spawnPoint2 { get; private set; }
//    [field: Header("SpawnPoint")]
//    [field: SerializeField] public Transform spawnPoint3 { get; private set; }
//    [field: Header("SpawnPoint")]
//    [field: SerializeField] public Transform spawnPoint4 { get; private set; }
//    [field: Header("SpawnPoint")]
//    [field: SerializeField] public Transform spawnPoint5 { get; private set; }
//    [field: Header("SpawnPoint")]
//    [field: SerializeField] public Transform spawnPoint6 { get; private set; }

//    private Transform[] spawnPoints;
//    private int currentWave = 0;
//    private float waveTimer = 0f;

//    // Control para evitar spawns simultáneos en un mismo spawnpoint
//    private bool[] spawnBusy;

//    private void Start()
//    {
//        spawnPoints = new Transform[] {
//            spawnPoint1, spawnPoint2, spawnPoint3,
//            spawnPoint4, spawnPoint5, spawnPoint6
//        };

//        spawnBusy = new bool[spawnPoints.Length];

//        OleadaUno();  // Empezar con la primera oleada
//    }

//    void Update()
//    {
//        waveTimer += Time.deltaTime;

//        if (waveTimer >= 10f)
//        {
//            waveTimer = 0f;
//            currentWave++;

//            if (currentWave > 5)
//            {
//                currentWave = 5; // Para que no pase de la última oleada
//                return;
//            }

//            switch (currentWave)
//            {
//                case 1: OleadaDos(); break;
//                case 2: OleadaTres(); break;
//                case 3: OleadaCuatro(); break;
//                case 4: OleadaCinco(); break;
//                case 5: OleadaSeis(); break;
//            }
//        }
//    }

//    void SpawnAtInstant(int index)
//    {
//        Instantiate(prefab, spawnPoints[index].position, Quaternion.identity);
//    }

//    IEnumerator SpawnWithDelay(int index, int cantidad, float delayBetweenSpawns)
//    {
//        if (spawnBusy[index]) yield break; // Spawnpoint ocupado
//        spawnBusy[index] = true;

//        for (int i = 0; i < cantidad; i++)
//        {
//            SpawnAtInstant(index);
//            yield return new WaitForSeconds(delayBetweenSpawns);
//        }

//        spawnBusy[index] = false;
//    }

//    void OleadaUno()
//    {
//        // 2 esqueletos en spawn 0 y 1
//        SpawnAtInstant(0);
//        SpawnAtInstant(1);
//    }

//    void OleadaDos()
//    {
//        // 3 esqueletos en spawn 0, 1 y 2
//        SpawnAtInstant(0);
//        SpawnAtInstant(1);
//        SpawnAtInstant(2);
//    }

//    void OleadaTres()
//    {
//        // 4 esqueletos en spawn 0, 1, 2 y 3
//        for (int i = 0; i < 4; i++)
//        {
//            SpawnAtInstant(i);
//        }
//    }

//    void OleadaCuatro()
//    {
//        // 5 esqueletos en spawn 0 a 4
//        for (int i = 0; i < 5; i++)
//        {
//            SpawnAtInstant(i);
//        }
//    }

//    void OleadaCinco()
//    {
//        // 6 esqueletos en cada spawn, uno por spawnpoint
//        for (int i = 0; i < spawnPoints.Length; i++)
//        {
//            SpawnAtInstant(i);
//        }
//    }

//    void OleadaSeis()
//    {
//        // 2 esqueletos en cada spawn, con 3 segundos de diferencia entre primer y segundo spawn
//        for (int i = 0; i < spawnPoints.Length; i++)
//        {
//            StartCoroutine(SpawnWithDelay(i, 2, 3f));
//        }
//    }
//}










//using System.Collections.Generic;
//using System.Collections;
//using UnityEngine;

//public class InstantiateSkeleton : MonoBehaviour
//{
//    public GameObject prefab;

//    [field: Header("SpawnPoint")]
//    [field: SerializeField] public Transform spawnPoint1 { get; private set; }
//    [field: Header("SpawnPoint")]
//    [field: SerializeField] public Transform spawnPoint2 { get; private set; }
//    [field: Header("SpawnPoint")]
//    [field: SerializeField] public Transform spawnPoint3 { get; private set; }
//    [field: Header("SpawnPoint")]
//    [field: SerializeField] public Transform spawnPoint4 { get; private set; }
//    [field: Header("SpawnPoint")]
//    [field: SerializeField] public Transform spawnPoint5 { get; private set; }
//    [field: Header("SpawnPoint")]
//    [field: SerializeField] public Transform spawnPoint6 { get; private set; }

//    private Transform[] spawnPoints;
//    private int currentWave = 0;
//    private float waveTimer = 0f;

//    // Control para evitar spawns simultáneos en un mismo spawnpoint
//    private bool[] spawnBusy;

//    private void Start()
//    {
//        spawnPoints = new Transform[] {
//            spawnPoint1, spawnPoint2, spawnPoint3,
//            spawnPoint4, spawnPoint5, spawnPoint6
//        };

//        spawnBusy = new bool[spawnPoints.Length];

//        OleadaUno();  // Empieza la primera oleada
//    }

//    void Update()
//    {
//        waveTimer += Time.deltaTime;

//        if (waveTimer >= 15f)
//        {
//            waveTimer = 0f;
//            currentWave++;

//            if (currentWave > 5)
//            {
//                currentWave = 5; // No pasar de la última oleada
//                return;
//            }

//            switch (currentWave)
//            {
//                case 1: OleadaDos(); break;
//                case 2: OleadaTres(); break;
//                case 3: OleadaCuatro(); break;
//                case 4: OleadaCinco(); break;
//                case 5: OleadaSeis(); break;
//            }
//        }
//    }

//    void SpawnAtInstant(int index)
//    {
//        Instantiate(prefab, spawnPoints[index].position, Quaternion.identity);
//    }

//    IEnumerator SpawnWithDelay(int index, int cantidad)
//    {
//        if (spawnBusy[index]) yield break; // Ya está ocupado este spawnpoint
//        spawnBusy[index] = true;

//        for (int i = 0; i < cantidad; i++)
//        {
//            SpawnAtInstant(index);
//            yield return new WaitForSeconds(1f);
//        }

//        spawnBusy[index] = false;
//    }

//    void OleadaUno()
//    {
//        SpawnAtInstant(0);
//        SpawnAtInstant(2);
//        SpawnAtInstant(4);
//    }

//    void OleadaDos()
//    {
//        for (int i = 0; i < spawnPoints.Length; i++)
//        {
//            SpawnAtInstant(i);
//        }
//    }

//    void OleadaTres()
//    {
//        for (int i = 0; i < spawnPoints.Length; i++)
//        {
//            SpawnAtInstant(i);
//        }

//        StartCoroutine(SpawnWithDelay(1, 1));
//        StartCoroutine(SpawnWithDelay(4, 1));
//    }

//    void OleadaCuatro()
//    {
//        for (int i = 0; i < spawnPoints.Length; i++)
//        {
//            StartCoroutine(SpawnWithDelay(i, 2));
//        }
//    }

//    void OleadaCinco()
//    {
//        for (int i = 0; i < spawnPoints.Length; i++)
//        {
//            SpawnAtInstant(i);
//        }

//        StartCoroutine(SpawnWithDelay(0, 2));
//        StartCoroutine(SpawnWithDelay(2, 2));
//        StartCoroutine(SpawnWithDelay(5, 2));
//    }

//    void OleadaSeis()
//    {
//        for (int i = 0; i < spawnPoints.Length; i++)
//        {
//            StartCoroutine(SpawnWithDelay(i, 3));
//        }
//    }
//}
