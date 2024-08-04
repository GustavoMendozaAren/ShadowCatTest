using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinIDScript : MonoBehaviour
{
    public string coinID; // Un identificador único para esta moneda

    void Start()
    {
        // Comprobar si la moneda ya ha sido recogida
        if (PlayerPrefs.GetInt(coinID, 0) == 1)
        {
            // Si la moneda ha sido recogida, la desactivamos
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
