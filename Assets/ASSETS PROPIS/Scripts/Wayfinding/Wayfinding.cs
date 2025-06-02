using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wayfinding : MonoBehaviour
{
    //  SINGLETON 
    public static Wayfinding Instance { get; private set; }

    //  Referències UI 
    [Header("Referències als panells (assigna’ls des de l’Inspector)")]
    public GameObject leftPanel;
    public GameObject rightPanel;

    [Header("Paràmetres de detecció")]
    public float detectionRange = 15f;
    public float sideThreshold = 0.1f;

    //  Llista d'enemics registrats 
    private readonly List<Transform> enemiesList = new List<Transform>();

    private Transform player;

    private void Awake()
    {
        // Implementació senzilla de singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        // Busquem el jugador pel tag "Player"
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("WayfindingManager: no troba cap GameObject amb Tag 'Player'.");
            enabled = false;
            return;
        }

        // Desactivem els panells a l'inici
        if (leftPanel) leftPanel.SetActive(false);
        if (rightPanel) rightPanel.SetActive(false);
    }

    private void Update()
    {
        if (player == null) return;

        //  PRIMER: netegem la llista d'enemics que ja no existeixen o que ja no tenen ConfigurableJoint 
        // (Iterem de darrere cap endavant per poder fer RemoveAt sense problemes)
        for (int i = enemiesList.Count - 1; i >= 0; i--)
        {
            Transform enemyT = enemiesList[i];

            // Si el Transform ha estat destruït (enemyT == null), el traiem directament
            if (enemyT == null)
            {
                enemiesList.RemoveAt(i);
                continue;
            }

            // Comprovem si li falta el ConfigurableJoint (s'ha “mort”)
            ConfigurableJoint joint = enemyT.GetComponent<ConfigurableJoint>();
            if (joint == null)
            {
                // L'enemic ja no té joint: el traiem de la llista
                enemiesList.RemoveAt(i);
                continue;
            }
        }

        //  DESPRÉS: fem la detecció només sobre els enemics “vius” que han quedat a la llista 
        bool leftAlert = false;
        bool rightAlert = false;

        foreach (Transform enemyT in enemiesList)
        {
            if (enemyT == null)
                continue; // (per seguretat, encara que ja ho vam netejar abans)

            Vector3 dirToEnemy = (enemyT.position - player.position).normalized;
            float distance = Vector3.Distance(player.position, enemyT.position);

            if (distance <= detectionRange)
            {
                float dotForward = Vector3.Dot(player.forward, dirToEnemy);

                // Si està darrere (dotForward < 0), comprovem esquerra/dreta
                if (dotForward < 0f)
                {
                    float dotRight = Vector3.Dot(player.right, dirToEnemy);

                    if (dotRight > sideThreshold)
                    {
                        // Darrere‐dreta
                        rightAlert = true;
                    }
                    else if (dotRight < -sideThreshold)
                    {
                        // Darrere‐esquerra
                        leftAlert = true;
                    }
                }
            }
        }

        //  Finalment: activem/desactivem els panells segons els flags 
        if (leftPanel) leftPanel.SetActive(leftAlert);
        if (rightPanel) rightPanel.SetActive(rightAlert);
    }

    //  Mètodes públics de registre 
    /// <summary>
    /// Crida-ho just després de fer Instantiate(o spawn) de l'enemic
    /// perquè l'afegeixi a la llista interna.
    /// </summary>
    public void RegisterEnemy(Transform enemyTransform)
    {
        if (enemyTransform == null) return;
        if (!enemiesList.Contains(enemyTransform))
            enemiesList.Add(enemyTransform);
    }

    /// <summary>
    /// Pots seguir usant aquesta funció si vols fer unregister manualment, 
    /// però no és obligatori perquè el `Update()` ja neteja per joint == null.
    /// </summary>
    public void UnregisterEnemy(Transform enemyTransform)
    {
        if (enemyTransform == null) return;
        enemiesList.Remove(enemyTransform);
    }

}
