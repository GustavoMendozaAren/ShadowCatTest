using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoOcultoSpawn : MonoBehaviour
{
    [SerializeField] private GameObject prefab1;  // Primer prefab
    [SerializeField] private GameObject prefab2;  // Segundo prefab
    [SerializeField] private bool usarPrefab1 = true; // Variable para elegir cuál prefab usar

    [SerializeField] private Transform spawnPoint; // Punto donde se instanciará el prefab

    private void Start()
    {
        SpawnPrefab();
    }

    void SpawnPrefab()
    {
        if (spawnPoint == null) return; // Evita errores si no hay punto de spawn

        GameObject prefabSeleccionado = usarPrefab1 ? prefab1 : prefab2;

        if (prefabSeleccionado != null)
        {
            Instantiate(prefabSeleccionado, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("No se ha asignado un prefab en el Inspector.");
        }
    }
}
