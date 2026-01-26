using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Sse4_2;

public class CoinIDScript : MonoBehaviour
{
    [SerializeField] private string coinID; // Un identificador único para esta moneda

    void Start()
    {
        //PlayerPrefs.SetInt(coinID, 0);

        if (PlayerPrefs.GetInt(coinID, 0) == 1)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Guardar el estado de la moneda como recogida
            PlayerPrefs.SetInt(coinID, 1);
            PlayerPrefs.Save();
        }
    }
}
